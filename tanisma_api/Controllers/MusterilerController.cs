using Dapper;
using Microsoft.AspNetCore.Mvc;
using tanisma_api.Controllers.Base;
using tanisma_api.Model;

namespace tanisma_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusterilerController : BaseController
    {
  
        [HttpGet("GetCustomerByEmail")]
        public async Task<IEnumerable<Musteriler>> GetCustomerByEmail(string email)
        {
            await _connection.OpenAsync();

            var queryText = $"SELECT * FROM musteriler where mail_adres='{email}'";

            var data = _connection.Query<Musteriler>(queryText).ToList();

            await _connection.CloseAsync();

            return data;
        }
        [HttpGet("GetAllCustomer")]
        public async Task<IEnumerable<Musteriler>> GetAllCustomer()
        {
            await _connection.OpenAsync();

            var queryText = "SELECT * FROM musteriler";

            var data = _connection.Query<Musteriler>(queryText).ToList();

            await _connection.CloseAsync();

            return data;
        }
        [HttpPost("AddCustomer")]
        public async Task<bool> AddCustomer([FromBody] Musteriler musteriler)
        {
            await _connection.OpenAsync();
            var sql = "INSERT INTO musteriler (id,ad, soyad,numara,adres,mail_adres,durum ) VALUES (@Id, @Ad,@Soyad,@Numara,@Adres,@Mail_Adresi,@Durum)";

            var customer = new
            {
                Id = musteriler.Id,
                Ad = musteriler.Ad,
                Soyad = musteriler.Soyad,
                Numara = musteriler.Numara,
                Adres = musteriler.Adres,
                Mail_Adresi = musteriler.Mail_Adres,
                Durum = musteriler.Durum,
            };

            var result = _connection.Execute(sql, customer) > 0;

            await _connection.CloseAsync();

            return result;
        }
        [HttpPut("UpdateCustomer")]
        public async Task<bool> UpdateCustomer([FromBody] Musteriler musteriler)
        {
            await Task.Delay(111);//bunu silersin kod hata vermesin diye eklendii...


            return false ;
        }
    }
}