using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace warehouse.Data.Models
{

    public abstract class BaseEntity<TPrimaryKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimaryKey Id { get; set; }

        public bool IsArchived { get; set; } = false;
    }
    public abstract class BaseEntity : BaseEntity<int>
    {

    }
}
