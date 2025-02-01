using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueryCraft.Entities
{
    public class Transformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SelectedDatasetId { get; set; }

        [ForeignKey("SelectedDatasetId")]
        public virtual Dataset SelectedDataset { get; set; }
        public virtual ICollection<Dataset> Datasets { get; set; }
        public virtual ICollection<Field> SourceFields { get; set; }
        public virtual ICollection<Field> ResultFields { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }

        public Transformation()
        {
            Datasets = new HashSet<Dataset>();
            SourceFields = new HashSet<Field>();
            ResultFields = new HashSet<Field>();
            Operations = new HashSet<Operation>();
        }
    }
}