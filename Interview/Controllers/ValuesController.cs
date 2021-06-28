namespace Interview.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Interview.DataAccessLayer;

    public class ValuesController : ApiController
    {
        private IDataAccess _dataAccess { get; set; }

        public ValuesController(IDataAccess dataAccess)
            :base()
        {
            dataAccess = dataAccess;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return _dataAccess.GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return _dataAccess.GetRecord(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            var transaction = ;// json deserialize here
            _dataAccess.AddRecord(transaction);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            var transaction = ;// json deserialize here
            _dataAccess.UpdateRecord(transaction);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _dataAccess.DeleteRecord(id);
        }
    }
}
