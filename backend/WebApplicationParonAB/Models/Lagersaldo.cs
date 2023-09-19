using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationParonAB.Models
{
    
    public class Lagersaldo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]   
        [ForeignKey("Benamning")]
      
        public string Produkt { get; set; }

        [Required]
        [MaxLength(255)]
        [ForeignKey("Fardigvarulager")]
        public string Fardigvarulager { get; set; }

        [Required]
        public int Saldo { get; set; }

     
        public Produkter Produktref { get; set; }

       
       

        public int UniqueIndex { get; set; }
    }
}
