using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Partager
    {
        [Key]
        public uint id_Partager { get; set; }
        public Utilisateurs Utilisateur { get; set; }
        public Ressources ressources { get; set; }
    }
}
