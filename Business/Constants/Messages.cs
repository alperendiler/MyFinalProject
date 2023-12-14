using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenenceTime ="Sistem Bakımda";
        public static string ProductsListed  ="Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olmalıdır";

        public static string ProductNameAlreadyExist = "Aynı isimde ürün bulunmakta";

        public static string CategoryLimitExceded = "Kategori limiti aşıldı";
        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
