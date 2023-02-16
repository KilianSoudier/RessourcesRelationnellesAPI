using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Type_Utilisateurs
    {
        [Key]
        public int id_type_user { get; set; }
        public string nom { get; set; }
    }
}
