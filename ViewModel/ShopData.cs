using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridge.ViewModel
{
    public class ShopData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Product Price")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please Enter Product Description")]
        public string Descreption { get; set; }
        public string Imagepath { get; set; }
        [Required(ErrorMessage = "Please upload image")]
        public HttpPostedFileBase ImageData { get; set; }
        public Response objresponse { get; set; }
    }
}