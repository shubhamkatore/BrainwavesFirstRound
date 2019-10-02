using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using DBHelper;

namespace WebService.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // GET: api/Stock
        [HttpGet]
        public string Get()
        {
            var date = "2016-12-30";
            var Parameters = new Dictionary<string, string> { { "@date", date } };
            var DataTable = SQLOperation.ExecuteCommand(Startup.ConnectionString, "gettopfive", Parameters);
            DataTable.Merge(SQLOperation.ExecuteCommand(Startup.ConnectionString, "getlastfive", Parameters));
            return JsonConvert.SerializeObject(DataTable);
        }

        [HttpGet("names", Name = "GetNames")]
        public string GetStockNames()
        {
            var stocks = new List<string> { };
            var DataTable = SQLOperation.ExecuteCommand(Startup.ConnectionString, "getsymbolnames");
            foreach (DataRow row in DataTable.Rows)
                stocks.Add(row["symbol"].ToString());
            return JsonConvert.SerializeObject(stocks.ToArray());
        }

        [HttpGet("names/{stock}", Name = "GetDatabyName")]
        public string GetStockDataByName(string stock)
        {
            var Parameters = new Dictionary<string, string> { {"@symbol",stock.ToUpper() } };
            var DataTable = SQLOperation.ExecuteCommand(Startup.ConnectionString, "getstockbysymbol",Parameters);
            return JsonConvert.SerializeObject(DataTable);
        }
        [HttpGet("date/{date}", Name = "GetDatabyDate")]
        public string GetStockDataByDate(string date)
        {
            var Parameters = new Dictionary<string, string> { { "@date", date } };
            var DataTable = SQLOperation.ExecuteCommand(Startup.ConnectionString, "getstockbydate", Parameters);
            return JsonConvert.SerializeObject(DataTable);
        }
        // GET: api/Stock/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stock
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Stock/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
