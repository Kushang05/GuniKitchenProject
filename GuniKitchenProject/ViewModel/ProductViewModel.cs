using GuniKitchenProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuniKitchenProject.ViewModel
{
    public class ProductViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Display(Name = "Item")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public string ProductName { get; set; }

        [Display(Name = "Category")]
        [ForeignKey(nameof(Product.Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public string ProductDescription { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public int ProductPrice { get; set; }

        [Display(Name = "Size")]
        public string ProductSize { get; set; }
    }
}
