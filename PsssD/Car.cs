using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PsssD
{
    public class Car
    {
         

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public string? Name{ get; set; }
        public string? Status { get; set; }
        public string? Delivery { get; set; }
          public int Mil { get; set; }

        public string? Model { get; set; }
        [Required]
        [StringLength(50)]
        public string? Specific { get; set; }
        [Required]
        public int? Zipcode { get; set; }
        
       // public int Id { get; set; }
        public int Price { get; set; }
      
       // public User? Users { get; set; }



    }
}
