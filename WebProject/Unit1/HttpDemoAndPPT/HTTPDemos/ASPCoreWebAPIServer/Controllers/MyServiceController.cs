using ASPCoreWebAPIServer.Models;
using Microsoft.AspNetCore.Mvc;


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
            return Json(new MyClass()
            {
                Info = "Web Server发回的Json格式信息",
                Id = 100
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
            var result = new
            {
                message = "收到了你发送过来的MyClass对象",
                receivedObj = obj
            };

            return Json(result);
        }
    }
}
