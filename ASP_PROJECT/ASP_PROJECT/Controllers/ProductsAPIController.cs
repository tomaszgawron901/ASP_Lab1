using ASP_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsAPIController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsAPIController(IProductRepository repository) {
            this._repo = repository;
        }

        /// <summary>
        /// Get list of all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var result = this._repo.Products.ToList();
                return Ok(result);
            } 
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get product by its id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            try
            {
                var result = this._repo.Products.FirstOrDefault( x => x.ID == id);
                if (result is null) { return NotFound(); }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/{category}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute]string category)
        {
            try
            {
                var result = this._repo.Products.Where(x => x.Category == category);
                if (result is null) { return NotFound(); }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">product to add</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                var result = this._repo.AddProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Update existing product
        /// </summary>
        /// <param name="product">product to update</param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {
                this._repo.SaveProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete existing product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProduct([FromBody] Product product)
        {
            try
            {
                var result = this._repo.DeleteProduct(product.ID);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
