using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Langue
    {
        [Key]
        public int id_langue { get; set; }
        public string nom { get; set; }
    }
}
