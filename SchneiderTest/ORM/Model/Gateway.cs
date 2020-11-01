
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Model
{
    [Table("Gateway")]
    public class Gateway : Entity
    {
        [Column("ip")]
        [Required]
        public string Ip
        {
            get;
            set;
        }
        [Column("port")]
        public int? Port
        {
            get;
            set;
        }
    }
}
