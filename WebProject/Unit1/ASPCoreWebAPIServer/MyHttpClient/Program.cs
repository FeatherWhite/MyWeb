using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("敲任意键进行Post Add演示：\n");
            Console.ReadKey(true);
            TestPost().Wait();
            Console.WriteLine("\n敲任意键开始演示如何使用HttpClient组件访问Web API：\n");
            Console.ReadKey(true);
            TestGetFromWebServer().Wait();
            Console.ReadLine();
        }

        #region "辅助方法"
        static HttpClient getHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3317");
            //设定HTTP Header，指定期望接收JSON字符串
            client.DefaultRequestHeaders.Add("Accept", "application/json");
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
        /// 让服务器运算一个加法
        /// </summary>
        static async Task TestPost()
        {
            var client = getHttpClient();

            Console.WriteLine("向服务器Post一个MyClass对象。\n");

            var data = new MyClass()
            {
                num1 = 200,
                num2 = 300
            };
            try
            {
                //var byteContent = new StringContent(JsonConvert.SerializeObject(data));
                //var response = client.PostAsync("api/myService",byteContent).Result;
                //response.EnsureSuccessStatusCode();
                //Console.WriteLine("服务器返回处理结果");
                var myContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = client.PostAsync("api/myService",myContent).Result;
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //try
            //{
            //    var response = await client.PostAsJsonAsync("api/myService", data);
            //    response.EnsureSuccessStatusCode();
            //    Console.WriteLine("服务器返回处理结果");
            //    var result = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(result);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
