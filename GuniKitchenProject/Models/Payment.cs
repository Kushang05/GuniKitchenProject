using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GuniKitchenProject.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Customer Id")]
        [ForeignKey(nameof(Order.User))]
        public Guid UserId { get; set; }
        public MyIdentityUser User { get; set; }
        

        [Required]
        public String PaymentMode { get; set; }

    }
}
