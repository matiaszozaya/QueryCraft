namespace QueryCraft.Entities
{
    public class DerivedColumnOperation : Operation
    {
        public void AddDerivedColumn(string expression, string newColumnName)
        {
            if (!string.IsNullOrEmpty(expression) && !string.IsNullOrEmpty(newColumnName))
            {
                Query = $"{newColumnName} = {expression}";

                var field = new Field()
                {
                    Name = newColumnName,
                    DataType = $"string"
                };

                if (!SourceFields.Select(x => x.Id).Contains(field.Id))
                {
                    var f = new Field()
                    {
                        Name = $"Derived.{field.Name}",
                        DataType = field.DataType,
                        IsChecked = field.IsChecked
                    };
                    SourceFields.Append(f);
                }
            }
        }
    }
}