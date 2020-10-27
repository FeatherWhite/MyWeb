using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace HttpClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("敲任意键开始演示如何使用HttpClient组件访问Web API：\n");
            Console.ReadKey(true);
            TestGetFromWebServer().Wait();

            Console.WriteLine("\n敲任意键进行下一个演示：\n");
            Console.ReadKey(true);
            TestSearch().Wait();


            Console.WriteLine("\n敲任意键进行下一个演示：\n");
            Console.ReadKey(true);
            TestHttpHeader().Wait();

            Console.WriteLine("\n敲任意键进行下一个演示：\n");
            Console.ReadKey(true);
            TestPost().Wait();

            Console.WriteLine("\n演示结束，敲任意键退出……");

            Console.ReadKey(true);
        }

        #region "辅助方法"
        static HttpClient getHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12623");
            //设定HTTP Header，指定期望接收JSON字符串
            client.DefaultRequestHeaders.Add("Accept", "application/json ");
            return client;
        }

        #endregion

        /// <summary>
        /// 发送简单的HTTP请求到Web API Server
        /// </summary>
        static async Task TestGetFromWebServer()
        {
            Console.WriteLine("向Web Server发出HTTP GET请求。");
            var client = getHttpClient();

            Console.WriteLine("\n收到服务器发回的数据:");
            string result = await client.GetStringAsync("api/myservice");
            Console.WriteLine(result);
        }
        /// <summary>
        /// 发送包容查询字符串的HTTP请求
        /// </summary>
        /// <returns></returns>
        static async Task TestSearch()
        {

            var client = getHttpClient();

            Console.WriteLine("HttpClient访问Web API服务器，通过查询字符串搜索数据。\n");

            string searchWhat = "中国人 abc";
            string searchUrl = $"api/myservice/search?value={searchWhat}";

            string result = await client.GetStringAsync(searchUrl);

            Console.WriteLine($"已经将“{searchUrl}”发给服务器……");

            Console.WriteLine($"\n收到服务器发回的数据:{result}");
        }

        /// <summary>
        /// 测试添加HTTP Header
        /// </summary>
        static async Task TestHttpHeader()
        {
            Console.WriteLine("测试向HTTP请求中添加自定义的Header:my-header。\n");
            var client = getHttpClient();
            client.DefaultRequestHeaders.Add("my-header", "my-header value");
            Console.WriteLine("Server端返回：");
            string result = await client.GetStringAsync("api/myservice/headers");
            Console.WriteLine(result);
        }
        /// <summary>
        /// 测试POST
        /// </summary>
        static async Task TestPost()
        {
            var client = getHttpClient();

            Console.WriteLine("向服务器Post一个MyClass对象。\n");

            var data = new MyClass()
            {
                Id = new Random().Next(),
                Info = "新对象创建于" + DateTime.Now.ToShortTimeString()
            };

            try
            {
                var response = await client.PostAsJsonAsync("api/myService", data);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("服务器返回处理结果");
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
