using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Categorie_Ressource
    {
        [Key]
        public int id_categorie { get; set; }
        public string nom_categorie { get; set; }
    }
}
