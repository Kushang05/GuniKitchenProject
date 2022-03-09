using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GuniKitchenProject.Models
{ 
    [Table("Carts")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [Display(Name = "Customer Id")]
        [ForeignKey(nameof(Order.User))]
        public Guid UserId { get; set; }
        public MyIdentityUser User { get; set; }


        [Display(Name = "Product Name")]
        [Required]
        [ForeignKey(nameof(Order.Product))]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public Product Product { get; set; }
    

        [Required(ErrorMessage ="{0} cannot be zero")]
        public int Qualtity { get; set; }


        [Required(ErrorMessage ="{0} cannot be Zero!!")]
        public int Prize { get; set; }
    }
}
