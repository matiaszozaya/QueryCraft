namespace QueryCraft.Entities
{
    public class JoinOperation : Operation
    {
        public Dataset? SourceDataset { get; set; }
        public IEnumerable<Dataset>? AvailableDatasets { get; set; }

        public void UpdateQuery(string sourceDatasetName, string targetDatasetName, string sourceField, string targetField, string joinType, string joinCondition)
        {
            string query = $@"{joinType} {targetDatasetName} AS Target ON {sourceDatasetName}.{sourceField} {joinCondition} {targetDatasetName}.{targetField}";
            Query = query;
        }

        public void LoadResultFields(IEnumerable<Field> targetFields, string targetDatasetName)
        {
            ResultFields = new List<Field>();

            foreach (var field in SourceFields)
            {
                if (!ResultFields.Contains(field))
                {
                    var f = new Field()
                    {
                        Name = field.Name,
                        DataType = field.DataType,
                        IsChecked = field.IsChecked
                    };
                    ResultFields.Add(f);
                }
            }

            foreach (var field in targetFields)
            {
                if (!ResultFields.Contains(field))
                {
                    var f = new Field()
                    {
                        Name = $"{targetDatasetName}.{field.Name}",
                        DataType = field.DataType,
                        IsChecked = field.IsChecked
                    };
                    ResultFields.Add(f);
                }
            }
        }
    }
}