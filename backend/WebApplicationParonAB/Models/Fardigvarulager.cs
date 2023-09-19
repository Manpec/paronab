using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationParonAB.Models
{ 
    
    
    public class Fardigvarulager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Lagernr { get; set; }

        [Required]
        [MaxLength(255)] // Adjust the maximum length as needed
       
        public string Stad { get; set; }

        public ICollection<Lagersaldo> Lagersaldo { get; set; }

        public ICollection<InOchUtLeverans> InOchUtLeverans { get; set; }

        public ICollection<Produkter> Produkter { get; set; }
    }
}
