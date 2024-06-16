using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Entity
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
