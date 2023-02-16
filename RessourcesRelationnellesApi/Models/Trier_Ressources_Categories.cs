using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Trier_Ressources_Categories
    {
        [Key]
        public int id_trier_categories { get; set; }
        public Categorie_Ressource Categorie_Ressource { get; set; }
        public Ressources Ressources { get; set; }
    }
}
