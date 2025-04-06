using System.ComponentModel.DataAnnotations;

namespace TSDOblig1.Models
{
    public class Bruker
    {
        public int Id { get; set; }  // Primærnøkkel

        [Required]
        public string Navn { get; set; }

        public string KontaktInfo { get; set; }

        public int AntallSpill { get; set; }
    }
}
