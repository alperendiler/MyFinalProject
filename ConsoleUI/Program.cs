﻿using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


//Categories();

ProductTest();

//Orders();

static void Categories()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

    foreach (var category in categoryManager.GetAll())

    {
        Console.Write(category.CategoryId + "-) ");


        Console.WriteLine(category.CategoryName);


    }
}

static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());
    Console.WriteLine(productManager.GetProductDetails().IsSuccess);


}

static void Orders()
{
    OrderManager orderManager = new OrderManager(new EfOrderDal());

    foreach (var order in orderManager.GetAll())

    {
        Console.WriteLine(order.OrderId + "-) ");


    }
}