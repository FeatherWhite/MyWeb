using ASPCoreWebAPIServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ASPCoreWebAPIServer.Controllers
{
    /// <summary>
    /// 一个用于返回纯数据的控制器，
    /// 在早期版本中，此控制器被称为Web API控制器,派生自ApiController
    /// 在ASP.NET core中，Web API与MVC合二为一，均派生自Controller
    /// </summary>
    [Route("api/[controller]")]
    public class MyServiceController : Controller
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult Search(string value)
        {
            return Json(
                new
                {
                    message = "Web API Server：您尝试着搜索“" + value + "”"
                });
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response.StatusCode = 200;
            return Json( new MyClass()
            {
                num1 = 100,
                num2 = 200
            });
        }

        [HttpGet]
        [Route("headers")]
        public IActionResult Headers()
        {
            return Ok(Request.Headers);
        }

        [HttpPost]
        public IActionResult Post([FromBody]MyClass obj)
        {
            int result = obj.num1 + obj.num2;
            return Json(result);
        }
    }
}
