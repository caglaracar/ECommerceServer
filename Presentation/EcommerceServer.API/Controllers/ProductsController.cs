using ECommerceServer.Application.Repositories;
using ECommerceServer.Application.ViewModels.Products;
using ECommerceServer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EcommerceServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        { 
            return Ok(await _productReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            if (ModelState.IsValid)
            {
                await Console.Out.WriteLineAsync("VALİDE");
            }
            else
            {
                await Console.Out.WriteLineAsync("Not WALİDE");
               
            }
            await _productWriteRepository.AddAsync(new()
            {
                Name=model.Name,
                Price=model.price,
                Stock=model.Stock,
            });

            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.name;
            product.Price = model.price;
            product.Stock = model.stock;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

           bool x= await _productWriteRepository.Remove(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
