using System.ComponentModel.DataAnnotations;

namespace RessourcesRelationnellesAPI.Models
{
    public class Type_Relation
    {
        [Key]
        public int id_Type_Relation { get; set; }
        public string designation { get; set; }
    }
}
