﻿using ECommerceServer.Domain.Entities.Common;

namespace ECommerceServer.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntitiy
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        Task<bool> Remove(string id);
        bool RemoveRange(List<T> datas);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
