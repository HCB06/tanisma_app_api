using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;

namespace tanisma_api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected readonly OleDbConnection _connection;
        public BaseController()
        {
            _connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbs\\tanisma_app_veritabani.accdb");
        }
      
    }
}
