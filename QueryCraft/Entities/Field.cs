using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueryCraft.Entities
{
    public class Field
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Rename { get; set; }
        public string DataType { get; set; }
        public bool IsChecked { get; set; } = true;
        public int DatasetId { get; set; }

        [ForeignKey("DatasetId")]
        public virtual Dataset Dataset { get; set; }
    }

}