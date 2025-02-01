using Microsoft.AspNetCore.Components;

namespace QueryCraft.Entities
{
    public class SelectOperation : Operation
    {
        public string? SourceDatasetName { get; set; }

        public void UpdateCheckbox(ChangeEventArgs e, int id)
        {
            var field = SourceFields.FirstOrDefault(f => f.Id == id);
            if (field != null)
            {
                field.IsChecked = (bool)e.Value;
            }
        }

        public async void BulkUpdateCheckboxes(bool flag)
        {
            if (SourceFields.Any())
            {
                foreach (var f in SourceFields)
                {
                    f.IsChecked = flag;
                }
            };
        }

        public string UpdateSelectQuery(IEnumerable<Field> fields, string datasetName)
        {
            var selectedFields = fields.Where(f => f.IsChecked).Select(f => f.Name);
            var queryFields = "";

            if (selectedFields.Any()) queryFields = $"{string.Join(", ", selectedFields)}";
            if (selectedFields.Count() == fields.Count()) queryFields = "*";

            var query = selectedFields.Any()
                ? $"SELECT {queryFields} FROM {datasetName}"
                : "";

            Query = query;

            return query;
        }
    }
}