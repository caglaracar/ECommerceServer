﻿using ECommerceServer.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ECommerceServer.Infrastructure.Services;

public class FileService : IFileService
{
    readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<List<(string fileName,string path)>> UploadAsync(string path, IFormFileCollection files)
    {
        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        List<(string fileName, string path)> datas = new();
        
        List<bool> results = new();
        foreach (IFormFile file in files)
        {
            string fileNewName = await FileRenameAsync(file.FileName);
            bool result=await CopyFileAsync($"{uploadPath}/{fileNewName}", file);
            datas.Add((fileNewName,$"{uploadPath}/{fileNewName}"));    
            results.Add(result);
        }

        if (results.TrueForAll(r => r.Equals(true)))
            return datas;
        
        //todo Eğerki yukaradaki  if geçerli değilse bir ex oluştur fırlat şimdilik null
        return null;
        
    }

    public Task<string> FileRenameAsync(string fileName)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CopyFileAsync(string path, IFormFile file)
    {
        try
        {
            await using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None,
                1024 * 1024, useAsync: false);

            await fileStream.CopyToAsync(fileStream);
            await fileStream.FlushAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    
    }
}