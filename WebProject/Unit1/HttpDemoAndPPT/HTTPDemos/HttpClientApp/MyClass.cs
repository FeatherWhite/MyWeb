using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientApp
{
    /// <summary>
    /// 为正确序列化，此类必须与服务端的类拥有相同的属性
    /// </summary>
    public class MyClass
    {
        public int Id { get; set; }
        public string Info { get; set; }
    }
}
