﻿using Business.Abstract;
using Business.Concrete;
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

        [HttpGet]   
        public List<Product> Get()
        {
            
            var result = _productService.GetAll();

            return result.Data;


        }

    }
}