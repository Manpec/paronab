using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationParonAB.Models
{
    public class Produkter
    {
        [Key]
        public string Produktnr { get; set; }

        [Required]
        public string Benamning { get; set; }

        public int Pris { get; set; }

        public ICollection<InOchUtLeverans> InOchUtLeverans { get; set; }

        public ICollection<Lagersaldo> Lagersaldo { get; set; }

        public ICollection<Fardigvarulager> Fardigvarulager { get; set; }
    }
}
