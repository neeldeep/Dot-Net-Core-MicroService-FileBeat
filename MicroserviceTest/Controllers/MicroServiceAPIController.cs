using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroserviceTest.Controllers
{
    [Route("api/[controller]")]
    public class MicroServiceAPIController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var respContent=string.Format("<html><body>Test Microservice API <p>{0}</p></body></html>",DateTime.Now);

            string[] userNames = { "Arthur", "Penny", "Jeremy", "Steve" };

            dynamic obj = new System.Dynamic.ExpandoObject();

            obj.verified = false;
            obj.evnt="logged_in";
            obj.status = "200";
            obj.time = new Random().Next(20, 200);
            obj.username = userNames[new Random().Next(userNames.Length-1)];

            string logJSON = JsonConvert.SerializeObject(obj);

            System.IO.File.AppendAllText(@"/usr/local/VAS/app.log",logJSON+Environment.NewLine);

            return new ContentResult()
            {
                Content = respContent,
                ContentType = "text/html",
            };
        }
    }
}
