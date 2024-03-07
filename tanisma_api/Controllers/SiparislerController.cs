using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using tanisma_api.Controllers.Base;
using tanisma_api.Model;

namespace tanisma_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparislerController : BaseController
    {
        [HttpGet("GetOrderById")]
        public async Task<IEnumerable<Musteriler>> GetOrderById(int  id)
        {
            await _connection.OpenAsync();

            var queryText = "SELECT * FROM siparisler";

            var data = _connection.Query<Musteriler>(queryText).ToList();

            await _connection.CloseAsync();

            return data;
        }

    }
}
