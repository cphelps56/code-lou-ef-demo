using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ef_Demo.MVC.Models
{
    public class ProductVM
    {
        [Required]
        [MinLength(5)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Manufacturer")]
        public int ManufacturerId { get; set; }

        [Required]
        [DisplayName("Product Type")]
        public int ProductTypeId { get; set; }

        [DisplayName("Price")]
        [Required]
        public decimal Price { get; set; }
    }
}
