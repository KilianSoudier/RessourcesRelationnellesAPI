using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Relation_Utilisateurs
    {
        [Key]
        public uint id_Relation_Utilisateurs { get; set; }
        public Utilisateurs utilisateur { get; set; }
        public Utilisateurs utilisateur_voulu { get; set; }
        public Type_Relation Type_Relation { get; set; }
        public bool relation_Confirmee { get; set; }
    }
}
