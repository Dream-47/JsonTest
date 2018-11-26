using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JsonTest
{
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 简单Json转化与解析

            //这个例子展示了怎么将.net对象转化为Json字符串与然后将Json字符串转化成.net对象。
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
                {
                   "User",
                   "Admin"
                }
            };
            //关键方法，主要参数为对象，其余参数为限制条件
            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            Console.WriteLine(json);
            // {
            //   "Email": "james@example.com",
            //   "Active": true,
            //   "CreatedDate": "2013-01-20T00:00:00Z",
            //   "Roles": [
            //     "User",
            //     "Admin"
            //   ]
            // }

            //关键方法，主要参数为json字符串，其余参数为限制条件，泛型参数为你要转化成的对象，如果Json字符串与对象不符合，会报错
            Account _account = JsonConvert.DeserializeObject<Account>(json);
            Console.WriteLine(_account.Email);
            // james@example.com

            Console.WriteLine("Hello World!");
            Console.ReadKey();

            #endregion

            #region 使用容器转化Json
            //生成Json字符串
            //(一个自定义的容器，类似于字典，主要类型有JObject，JArray,JValue)，继承于Jcontainner
            JArray array = new JArray();
            array.Add("Manual text");
            array.Add(new DateTime(2000, 5, 23));
            JObject o = new JObject();
            o["MyArray"] = array;
            string json2 = o.ToString();
            Console.WriteLine(json2);
            Console.ReadKey();
            // {
            //   "MyArray": [
            //     "Manual text",
            //     "2000-05-23T00:00:00"
            //   ]
            // }

            //读取修改Json字符串，类似字典
            JObject jObject = JObject.Parse(json2);
            jObject["MyArray"][0] = "Manual text2";
            Console.WriteLine(jObject);
            Console.ReadKey();
            // {
            //   "MyArray": [
            //     "Manual text2",
            //     "2000-05-23T00:00:00"
            //   ]
            // }

            #endregion       
        }
    }
}
