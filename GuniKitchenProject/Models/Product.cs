using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuniKitchenProject.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Display(Name = "Product Category")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public string ProductCategory { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [StringLength(20, ErrorMessage = "{0} cannot be more than {1} characters.")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters.")]
        public string ProductDescription { get; set; }

        [Display(Name = "Product Image")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public string ProductImage { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Product Size")]
        public string ProductSize { get; set; }
    }
}
