using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using tanisma_api.Model;

namespace tanisma_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusterilerController : ControllerBase
    {


        [HttpGet()]
        public IEnumerable<Musteriler> Get(string email)
        {


            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbs\\tanisma_app_veritabani.accdb");

            conn.Open();

            var queryText = "SELECT * FROM musteriler where email =" + email;


            var data = conn.Query<Musteriler>(queryText).ToList();
             // insert sql yazzz


            return data;
        }
    }
}