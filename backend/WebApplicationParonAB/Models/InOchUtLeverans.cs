using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationParonAB.Models
{
    public class InOchUtLeverans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Leveransnr { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        [MaxLength(255)] 
        [ForeignKey("Benamning")]
        public string Produkt { get; set; }

        [Required]
        [MaxLength(255)] 
        [ForeignKey("Stad")]
        public string Till_eller_fran { get; set; }

        [Required]
        public int Antal { get; set; }

        [Required]
        [MaxLength(255)] 
        public string Status { get; set; }

        
   

        
    
    }
}
