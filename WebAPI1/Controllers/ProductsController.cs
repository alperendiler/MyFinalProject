using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //ATTRIBUTE c# = Bildirimsel etiket = ANNOTATION JAVA
    public class ProductsController : ControllerBase
    {  
        //Dependency injection
        IProductService _productService  ;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]   
        public IActionResult Get()
        {
            
            var result = _productService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            
            return BadRequest(result.Message);

        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id) 
        {
            var result = _productService.GetById(id);
            if (result.IsSuccess) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Post(Product product) 
        {
            var result = _productService.Add(product);
            if (result.IsSuccess) 
            {
                return Ok(result);
            }
            return BadRequest(result);

        }



    }
}
