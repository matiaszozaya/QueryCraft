namespace QueryCraft.Entities
{
    public class FilterOperation : Operation
    {
        public IEnumerable<string> Expressions { get; set; }

        public void UpdateExpressions(string sourceFieldName)
        {
            if (!string.IsNullOrEmpty(sourceFieldName))
            {
                var sourceField = SourceFields.FirstOrDefault(x => x.Name == sourceFieldName);

                if (sourceField.DataType != null)
                {
                    Expressions = [];

                    switch (sourceField.DataType.ToUpper())
                    {
                        case ("STRING"):
                            Expressions = ["==", "!=", "CONTAINS", "STARTSWITH", "ENDSWITH"];
                            break;
                        case ("BOOL"):
                            Expressions = ["==", "!="];
                            break;
                        case ("STRING?"):
                            Expressions = ["==", "!=", "CONTAINS", "STARTSWITH", "ENDSWITH"];
                            break;
                        case ("BOOL?"):
                            Expressions = ["==", "!="];
                            break;
                        default:
                            Expressions = ["==", "!=", "<", "<=", ">", ">="];
                            break;
                    }
                }
            }
        }

        public void UpdateQuery(string sourceFieldName, string expression, string targetField)
        {
            Query = $"Filter({sourceFieldName} {expression} {targetField})";
        }
    }
}