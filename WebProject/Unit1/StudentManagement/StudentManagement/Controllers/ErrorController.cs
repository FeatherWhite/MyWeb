using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StudentManagement.Controllers
{
    public class ErrorController : Controller
    {
        private ILogger<ErrorController> logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        //如果状态码为404，则路径将变为Error/404
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = 
                HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "抱歉，读者访问的页面不存在";
                    //LogWarning()方法将异常记录作为日志中的警告类别记录
                    logger.LogWarning($"发生了一个404错误. 路径 = " +
                $"{statusCodeResult.OriginalPath} 以及查询字符串 = " +
                $"{statusCodeResult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }
        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            //获取异常细节
            var exceptionHandlerPathFeature =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //LogError()方法将异常记录作为日志中的错误类别记录
            logger.LogError($"路径 {exceptionHandlerPathFeature.Path} " +
                $"产生了一个错误{exceptionHandlerPathFeature.Error}");
            return View("Error");
        }
    }
}
