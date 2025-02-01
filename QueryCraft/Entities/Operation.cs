using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueryCraft.Entities
{
    public class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; } = true;
        public string? Query { get; set; }
        public virtual ICollection<Field> SourceFields { get; set; }
        public virtual ICollection<Field> ResultFields { get; set; }

        public int TransformationId { get; set; }

        [ForeignKey("TransformationId")]
        public virtual Transformation Transformation { get; set; }

        public Operation()
        {
            SourceFields = new HashSet<Field>();
            ResultFields = new HashSet<Field>();
        }
    }
}
