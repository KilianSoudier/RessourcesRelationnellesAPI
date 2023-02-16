using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Utilisateurs
    {
        [Key]
        public uint id_user { get; set; }
        public string pseudo { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string mdp { get; set; }
        public DateTime date_naissance { get; set; }
        public string nom { get; set; }
        public string? nom_jeune_fille { get; set; }
        public string prenom { get; set; }
        public Langue langue { get; set; }
        public DateTime derniere_date_connexion { get; set; }
        public bool validation_rgpd { get; set; }
        public DateTime date_validation_rgpd { get; set; }
        public bool accord_confidentialite { get; set; }
        public DateTime date_accord_confidentialite { get; set; }
        public string numero_telephone { get; set; }
        public Type_Utilisateurs Type_Utilisateur { get; set; }
    }
}
