using QueryCraft.Data;
using QueryCraft.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace QueryCraft.Services
{
    public interface ITransformationService
    {
        IEnumerable<Transformation> GetAll();
        Transformation GetById(int id);
        IEnumerable<Transformation> GetWithIncludes();
        void AddTransformation(Transformation transformation);
        void UpdateTransformation(Transformation transformation);
        void RemoveTransformation(Transformation transformation);
        void RemoveAll(IEnumerable<Transformation> lTransformation);
        void LoadFields(int transformationId);
        void AddSelect(int transformationId);
        void AddJoin(int transformationId);
        void AddSort(int transformationId);
        void AddFilter(int transformationId);
        void AddDerivedColumn(int transformationId);
        void DeleteOperation(int transformationId, int id);
        public void RemoveAllOperations(int transformationId);
    }

    public class TransformationService : ITransformationService
    {
        private readonly AppDbContext _context;
        private readonly IUtilities _utilities;

        public TransformationService(AppDbContext context, IUtilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        public IEnumerable<Transformation> GetAll()
        {
            return _context.Transformations.AsEnumerable();
        }

        public Transformation GetById(int id)
        {
            return GetWithIncludes().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Transformation> GetWithIncludes()
        {
            var transformations = _context.Transformations
                .Include(t => t.Datasets)
                .Include(t => t.SourceFields)
                .Include(t => t.ResultFields)
                .Include(t => t.Operations);

            return transformations;
        }

        public void AddTransformation(Transformation transformation)
        {
            _context.Transformations.Add(transformation);
            _context.SaveChanges();
        }

        public void UpdateTransformation(Transformation transformation)
        {
            _context.Transformations.Update(transformation);
            _context.SaveChanges();
        }

        public void RemoveTransformation(Transformation transformation)
        {
            _context.Transformations.Remove(transformation);
            _context.SaveChanges();
        }

        public void RemoveAll(IEnumerable<Transformation> lTransformation)
        {
            _context.Transformations.RemoveRange(lTransformation);
            _context.SaveChanges();
        }

        public void LoadFields(int transformationId)
        {
            var transformation = GetById(transformationId);

            if (transformation?.SelectedDatasetId != null)
            {
                transformation.SourceFields = transformation.Datasets.FirstOrDefault(d => d.Id == transformation.SelectedDatasetId)?.Fields;
            }

            _context.SaveChanges();
        }

        public void AddSelect(int transformationId)
        {
            try
            {
                var transformation = GetById(transformationId);
                var operation = new SelectOperation
                {
                    Order = _utilities.GetNewId(transformation.Operations, o => o.Order),
                    Name = "SELECT",
                    IsValid = true,
                    SourceFields = transformation.Operations.Any()
                    ? _utilities.GetLastOperationFields(transformation.Operations)
                    : transformation.SourceFields,
                    SourceDatasetName = transformation.SelectedDataset.Name
                };

                if (transformation.SelectedDatasetId != null)
                {
                    _context.Operations.Add(operation);
                    transformation.Operations.Add(operation);

                    _context.Operations.OrderBy(o => o.Order);
                    transformation.Operations.OrderBy(o => o.Order);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddJoin(int transformationId)
        {
            try
            {
                var transformation = GetById(transformationId);
                var operation = new JoinOperation
                {
                    Order = _utilities.GetNewId(transformation.Operations, o => o.Order),
                    Name = "JOIN",
                    IsValid = true,
                    SourceFields = transformation.Operations.Any()
                    ? _utilities.GetLastOperationFields(transformation.Operations)
                    : transformation.SourceFields,
                    AvailableDatasets = transformation.Datasets,
                    SourceDataset = transformation.Datasets.FirstOrDefault(d => d.Id == transformation.SelectedDatasetId)
                };

                if (transformation.SelectedDatasetId != null)
                {
                    _context.Operations.Add(operation);
                    transformation.Operations.Add(operation);

                    _context.Operations.OrderBy(o => o.Order);
                    transformation.Operations.OrderBy(o => o.Order);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddSort(int transformationId)
        {
            try
            {
                var transformation = GetById(transformationId);
                var operation = new SortOperation
                {
                    Order = _utilities.GetNewId(transformation.Operations, o => o.Order),
                    Name = "SORT",
                    IsValid = true,
                    SourceFields = transformation.Operations.Any()
                    ? _utilities.GetLastOperationFields(transformation.Operations)
                    : transformation.SourceFields,
                    Directives = []
                };

                if (transformation.SelectedDatasetId != null)
                {
                    _context.Operations.Add(operation);
                    transformation.Operations.Add(operation);

                    _context.Operations.OrderBy(o => o.Order);
                    transformation.Operations.OrderBy(o => o.Order);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddFilter(int transformationId)
        {
            try
            {
                var transformation = GetById(transformationId);
                var operation = new FilterOperation
                {
                    Order = _utilities.GetNewId(transformation.Operations, o => o.Order),
                    Name = "FILTER",
                    IsValid = true,
                    SourceFields = transformation.Operations.Any()
                    ? _utilities.GetLastOperationFields(transformation.Operations)
                    : transformation.SourceFields,
                    Expressions = []
                };

                if (transformation.SelectedDatasetId != null)
                {
                    _context.Operations.Add(operation);
                    transformation.Operations.Add(operation);

                    _context.Operations.OrderBy(o => o.Order);
                    transformation.Operations.OrderBy(o => o.Order);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddDerivedColumn(int transformationId)
        {
            try
            {
                var transformation = GetById(transformationId);
                var operation = new DerivedColumnOperation
                {
                    Order = _utilities.GetNewId(transformation.Operations, o => o.Order),
                    Name = "DERIVEDCOLUMN",
                    IsValid = true,
                    SourceFields = transformation.Operations.Any()
                    ? _utilities.GetLastOperationFields(transformation.Operations)
                    : transformation.SourceFields,
                };

                if (transformation.SelectedDatasetId != null)
                {
                    _context.Operations.Add(operation);
                    transformation.Operations.Add(operation);

                    _context.Operations.OrderBy(o => o.Order);
                    transformation.Operations.OrderBy(o => o.Order);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteOperation(int transformationId, int id)
        {
            var transformation = GetById(transformationId);

            var operation = transformation.Operations.FirstOrDefault(o => o.Id == id);
            if (operation != null)
            {
                transformation.Operations.Remove(operation);
            }

            var operationsToDisable = transformation.Operations.Where(o => o.Id > id);
            if (operationsToDisable.Count() > 0)
            {
                foreach (var o in operationsToDisable)
                {
                    o.IsValid = false;
                }
            }

            _context.SaveChanges();
        }


        public void RemoveAllOperations(int transformationId)
        {
            var transformation = GetById(transformationId);

            if (transformation.Operations.Count() > 0)
            {
                _context.RemoveRange(transformation.Operations);
                _context.SaveChanges();
            }
        }
    }
}