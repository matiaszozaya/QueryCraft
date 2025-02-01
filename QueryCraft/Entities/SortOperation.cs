namespace QueryCraft.Entities
{
    public class SortOperation : Operation
    {
        public IEnumerable<SortDirective> Directives { get; set; }

        public void AddSortDirective(string fieldName, string direction)
        {
            int order = 0;
            if (Directives.Any()) order = Directives.Max(o => o.Id);
            var directive = new SortDirective() { Id = ++order, FieldName = fieldName, Direction = direction };

            if (!string.IsNullOrEmpty(directive.FieldName) && !string.IsNullOrEmpty(directive.Direction))
            {
                Query += $"SORT by [{directive.FieldName}] {directive.Direction} ";
                Directives.Append(directive);
            }
        }

        public class SortDirective
        {
            public int Id { get; set; }
            public string FieldName { get; set; }
            public string Direction { get; set; }
        }
    }
}