using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GuniKitchenProject.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        
        [Display(Name ="Category")]
        [Required]
        public String Name { get; set; }


        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
