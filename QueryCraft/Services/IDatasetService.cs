using QueryCraft.Entities;

namespace QueryCraft.Services
{
    public interface IDatasetService
    {
        ICollection<Dataset> LoadDatasets();
    }

    public class DatasetService : IDatasetService
    {
        public ICollection<Dataset> LoadDatasets()
        {
            return new List<Dataset>
            {
                new Dataset
                {
                    Name = "Accounts",
                    FileType = "CSV",
                    Fields = new List<Field>
                    {
                        new Field { Name = "Id", DataType = "int" },
                        new Field { Name = "CustodianId", DataType = "int" },
                        new Field { Name = "CustomerId", DataType = "int" },
                        new Field { Name = "Number", DataType = "string" },
                        new Field { Name = "Master", DataType = "string" },
                        new Field { Name = "Name", DataType = "string" },
                        new Field { Name = "AccountStatus", DataType = "string" },
                        new Field { Name = "AccountType", DataType = "string" },
                        new Field { Name = "PrimaryContact", DataType = "string" },
                        new Field { Name = "MailingAddress", DataType = "string" },
                        new Field { Name = "MailingCity", DataType = "string" },
                        new Field { Name = "MailingState", DataType = "string" },
                        new Field { Name = "MailingCountry", DataType = "string" },
                        new Field { Name = "MailingZipCode", DataType = "string" },
                        new Field { Name = "Email", DataType = "string" },
                        new Field { Name = "Phone", DataType = "string" },
                        new Field { Name = "BussinesPhone", DataType = "string" },
                        new Field { Name = "DateOpened", DataType = "DateTime" },
                        new Field { Name = "CurrencyId", DataType = "int?" }
                    }
                },
                new Dataset
                {
                    Name = "Positions",
                    FileType = "CSV",
                    Fields = new List<Field>
                    {
                        new Field { Name = "CustodianId", DataType = "int" },
                        new Field { Name = "CustomerId", DataType = "int" },
                        new Field { Name = "ProcessDate", DataType = "DateTime" },
                        new Field { Name = "AccountId", DataType = "int" },
                        new Field { Name = "SecurityId", DataType = "int" },
                        new Field { Name = "ShortPosition", DataType = "bool" },
                        new Field { Name = "Quantity", DataType = "int" },
                        new Field { Name = "MarketValue", DataType = "decimal" },
                        new Field { Name = "OriginalCost", DataType = "decimal" },
                        new Field { Name = "OriginalCostDate", DataType = "DateTime" }
                    }
                },
                new Dataset
                {
                    Name = "Prices",
                    FileType = "CSV",
                    Fields = new List<Field>
                    {
                        new Field { Name = "CustodianId", DataType = "int" },
                        new Field { Name = "ProcessDate", DataType = "DateTime" },
                        new Field { Name = "SecurityId", DataType = "int" },
                        new Field { Name = "PriceValue", DataType = "decimal" }
                    }
                },
                new Dataset
                {
                    Name = "Securities",
                    FileType = "CSV",
                    Fields = new List<Field>
                    {
                        new Field { Name = "Id", DataType = "int" },
                        new Field { Name = "CustodianId", DataType = "int" },
                        new Field { Name = "SecurityTypeId", DataType = "int" },
                        new Field { Name = "CurrencyId", DataType = "int" },
                        new Field { Name = "PrimarySymbol", DataType = "string" },
                        new Field { Name = "Cusip", DataType = "string" },
                        new Field { Name = "Sedol", DataType = "string" },
                        new Field { Name = "Isin", DataType = "string" },
                        new Field { Name = "Ticker", DataType = "string" },
                        new Field { Name = "Description", DataType = "string" },
                        new Field { Name = "SectorId", DataType = "int" },
                        new Field { Name = "Industry", DataType = "string" }
                    }
                },
                new Dataset
                {
                    Name = "Transactions",
                    FileType = "CSV",
                    Fields = new List<Field>
                    {
                        new Field { Name = "Id", DataType = "int" },
                        new Field { Name = "CustodianId", DataType = "int" },
                        new Field { Name = "CustomerId", DataType = "int" },
                        new Field { Name = "ProcessDate", DataType = "DateTime" },
                        new Field { Name = "AccountId", DataType = "int" },
                        new Field { Name = "SecurityId", DataType = "int" },
                        new Field { Name = "TransactionCodeId", DataType = "int" },
                        new Field { Name = "CancelIndicator", DataType = "bool" },
                        new Field { Name = "Comment", DataType = "string" },
                        new Field { Name = "TradeDate", DataType = "DateTime" },
                        new Field { Name = "SettlementDate", DataType = "DateTime" },
                        new Field { Name = "Quantity", DataType = "int" },
                        new Field { Name = "Amount", DataType = "decimal" },
                        new Field { Name = "OriginalCost", DataType = "decimal?" },
                        new Field { Name = "OriginalCostDate", DataType = "DateTime?" },
                        new Field { Name = "Sdtype", DataType = "string" },
                        new Field { Name = "Sdsymbol", DataType = "string" },
                        new Field { Name = "Exchange", DataType = "string?" },
                        new Field { Name = "ExchangeFee", DataType = "decimal?" },
                        new Field { Name = "Commission", DataType = "decimal?" },
                        new Field { Name = "OtherFees", DataType = "decimal?" },
                        new Field { Name = "Broker", DataType = "string?" },
                        new Field { Name = "WhtSecurityId", DataType = "int?" },
                        new Field { Name = "ExecPri", DataType = "decimal?" },
                        new Field { Name = "ExecPriCalc", DataType = "decimal?" },
                        new Field { Name = "Reorg", DataType = "bool" }
                    }
                }
            };
        }
    }
}