using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using url_shortner.Helpers;

namespace url_shortner.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [HttpPost]
        [HttpDelete]
        [HttpPatch]
        [HttpPut]
        public IActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View();
            try
            {
                var l = LongBase64.Base64StringToLong(id);

                IDbConnection db = new MySqlConnection(Global.Configuration.GetSection("ConnectionStrings")["local"]);

                var url = db.QuerySingleOrDefault<string>("SELECT url FROM redirects WHERE id = @id", new { id = l });

                if (string.IsNullOrEmpty(url))
                    return Redirect("~/!error");

                //PreserveMethod a.k.a., if a POST method, forward and keep request a POST method
                return RedirectPermanentPreserveMethod(url);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return View();
            }
        }

        public IActionResult error()
        {
            return View();
        }
    }
}