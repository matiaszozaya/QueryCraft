using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueryCraft.Entities
{
    public class Dataset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public virtual ICollection<Field> Fields { get; set; }

        public Dataset()
        {
            Fields = new HashSet<Field>();
        }
    }

}
