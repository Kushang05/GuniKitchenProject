using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GuniKitchenProject.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Display(Name ="Customer Id")]
        [ForeignKey(nameof(Order.User))]
        public Guid UserId { get; set; }
        public MyIdentityUser User { get; set; }


        [Display(Name = "Product Name")]
        [Required]
        [ForeignKey(nameof(Order.Product))]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public Product Product { get; set; }


        public int Quantity { get; set; }

        public int Prize { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime OrderDate { get; set; }




    }
}
