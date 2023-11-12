using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new EfProductDal());
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());


foreach (var category in categoryManager.GetAll())

{
    Console.Write(category.CategoryId + "-) ");


    Console.WriteLine(category.CategoryName);


}


foreach (var product in productManager.GetAllByCategoryId(1))

{
    Console.WriteLine(product.ProductName);
    Console.WriteLine(product.UnitPrice);
    Console.WriteLine(product.CategoryId);


}















