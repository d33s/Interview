namespace Interview.DataAccessLayer
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Interview.DataAccessLayer.Models;

    public class JsonDataAccess : IDataAccess
    {
        private readonly string _configPath;

        private IList<Transaction> _transactions { get; set; }

        public JsonDataAccess()
        {
            _configPath = $@"{AppDomain.CurrentDomain.BaseDirectory}" + "..\\" + "data.json";
            var jsonText = File.ReadAllText(_configPath);
            _transactions = JsonConvert.DeserializeObject<List<Transaction>>(jsonText);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _transactions;
        }        

        public Transaction GetRecord(Guid id)
        {
            return _transactions.SingleOrDefault(t => t.Id == id);
        }

        public void AddRecord(Transaction transaction)
        {
            _transactions.Add(transaction);

            UpdateFile();
        }

        public void DeleteRecord(Guid id)
        {
            var transactionToRemove = _transactions.SingleOrDefault(t => t.Id == id);
            if (transactionToRemove != null)
            {
                _transactions.Remove(transactionToRemove);
            }

            UpdateFile();
        }

        public void UpdateRecord(Guid id, Transaction transaction)
        {
            var transactionToUpdate = _transactions.SingleOrDefault(t => t.Id == id);
            if (transactionToUpdate != null)
            {
                transactionToUpdate = transaction;
            }

            UpdateFile();
        }

        private void UpdateFile()
        {
            File.WriteAllText(_configPath,
                JsonConvert.SerializeObject(
                    _transactions,
                    typeof(Transaction[]),
                    Formatting.Indented,
                    new JsonSerializerSettings()));
        }
    }
}