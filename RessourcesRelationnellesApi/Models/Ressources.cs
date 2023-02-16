using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Ressources
    {
        [Key]
        public uint id_ressource { get; set; }
        public string titre { get; set; }
        public Langue langue { get; set; }
        public DateTime date_moderation { get; set; }
        public bool validation_moderation { get; set; }
        public string description { get; set; }
        public int age_minimum { get; set; }
        public uint compteur_vues { get; set; }
    }
}
