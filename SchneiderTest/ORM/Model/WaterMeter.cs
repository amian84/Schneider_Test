using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Model
{
    [Table("WaterMeter")]
    public class WaterMeter : Entity
    {
    /*
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 0)]
        public int? Id
        {
            get;
            set;
        }
        [Key]
        [Column("serial", Order = 1)]
        [Required]
        public string SerialNumber
        {
            get;
            set;
        }
        [Column("brand")]
        public string Brand
        {
            get;
            set;
        }
        [Column("model")]
        public string Model
        {
            get;
            set;
        }
        */
    }
}
