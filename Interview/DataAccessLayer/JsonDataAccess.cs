namespace Interview.DataAccessLayer
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Newtonsoft.Json;

    public class JsonDataAccess : IDataAccess
    {
        internal IList<Transaction> Transactions { get; set; }

        private string _configPath = $@"{Directory.GetCurrentDirectory()}" + "\\..\\" + "appsettings.json";
        public IEnumerable<TData> GetData<TData>()
        {
            var jsonText = File.ReadAllText(_configPath);
            return JsonConvert.DeserializeObject<IEnumerable<Account>>(jsonText);
        }

        public IEnumerable<Transaction> GetAll<TData>()
        {
            return Transactions;
        }        

        public Transaction GetRecord<Transaction>(Guid id)
        {
            return Transactions.SingleOrDefault(t => t.Id == id);
        }

        public Transaction AddRecord<Transaction>(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void DeleteRecord<Transaction>(Guid guid)
        {
            var transactionToRemove = Transactions.SingleOrDefault(t => t.Id == guid);

            if (transactionToRemove != null)
            {
                Transactions.Remove(transactionToRemove);
            }
        }

        public IEnumerable<Transaction> UpdateRecord<TData>(Transaction transaction)
        {
            var transactionToUpdate = Transactions.SingleOrDefault(t => t.Id == transaction.Id);
            if (transactionToUpdate != null)
            {
                transactionToUpdate = transaction;
            }
        }
    }
}