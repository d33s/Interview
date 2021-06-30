namespace Interview.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Interview.DataAccessLayer;
    using Interview.DataAccessLayer.Models;
    using Newtonsoft.Json;

    // TODO: methods could be async
    // TODO: error handling
    public class ValuesController : ApiController
    {
        private JsonDataAccess _dataAccess;

        public ValuesController()
        {
            _dataAccess = new JsonDataAccess();
        }

        // GET api/values
        public IEnumerable<Transaction> Get()
        {
            return _dataAccess.GetAll();
        }

        // GET api/values?id=3f2b12b8-2a06-45b4-b057-45949279b4e5
        public Transaction Get(string id)
        {
            Guid guid;
            if (Guid.TryParse(id, out guid))
            {
                return _dataAccess.GetRecord(guid);
            }

            return null;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            var transaction = JsonConvert.DeserializeObject<Transaction>(value);
            _dataAccess.AddRecord(transaction);
        }

        // PUT api/values/5
        public void Put(string id, [FromBody]string value)
        {
            Guid guid;
            if (Guid.TryParse(id, out guid))
            {
                var transaction = JsonConvert.DeserializeObject<Transaction>(value);
                _dataAccess.UpdateRecord(guid, transaction);
            }
        }

        // DELETE api/values/5
        public void Delete(string id)
        {
            Guid guid;
            if (Guid.TryParse(id, out guid))
            {
                _dataAccess.DeleteRecord(guid);
            }
        }
    }
}
