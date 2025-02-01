using QueryCraft.Entities;

namespace QueryCraft.Services
{
    public interface IUtilities
    {
        public int GetNewId<T>(IEnumerable<T>? items, Func<T, int>? idSelector);
        public ICollection<Field> GetLastOperationFields(IEnumerable<Operation> operations);
    }

    public class Utilities : IUtilities
    {
        public int GetNewId<T>(IEnumerable<T>? items, Func<T, int>? id)
        {
            if (items == null) throw new NullReferenceException();
            if (!items.Any()) return 1;
            return items.Max(id) + 1;
        }

        public ICollection<Field> GetLastOperationFields(IEnumerable<Operation> operations)
        {
            var lastOperationId = operations.Max(o => o.Id);
            var lastOperation = operations.FirstOrDefault(o => o.Id == lastOperationId);
            var newFields = new List<Field>();

            if (lastOperation == null) throw new NullReferenceException();

            if (lastOperation.ResultFields.Any())
            {
                newFields = new List<Field>(lastOperation.ResultFields.Where(f => f.IsChecked));
            }
            else
            {
                newFields = new List<Field>(lastOperation.SourceFields.Where(f => f.IsChecked));
            }

            foreach (var f in newFields) { if (!string.IsNullOrEmpty(f.Rename)) f.Name = f.Rename; }

            return newFields;
        }
    }
}