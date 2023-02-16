using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Commentaire
    {
        [Key]
        public uint id_Commentaire { get; set; }
        public DateTime date_commentaire { get; set; }
        public string commentaire { get; set; }
        public Utilisateurs utilisateur { get; set; }
        public Ressources ressources { get; set; }
        public Commentaire commentaire_parent { get; set; }
    }
}
