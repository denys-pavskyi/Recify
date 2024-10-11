using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual Guid Id { get; set; }
}