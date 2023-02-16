using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Chat
    {
        [Key]
        public uint id_chat { get; set; }
        public Jeu jeu { get; set; }
        public Utilisateurs utilisateur { get; set; }
        public DateTime date_chat { get; set; }
        public string message_chat { get; set; }
    }
}
