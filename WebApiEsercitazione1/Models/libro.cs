using System.ComponentModel.DataAnnotations;
namespace WebApiEsercitazione1.Models
{
    public class libro
    {
        [Key]
        public int codice { get; set; }

        public string? titolo { get; set; }
        public string?  editore { get; set; }
    }
}
