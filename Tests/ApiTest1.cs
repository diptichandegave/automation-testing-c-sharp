using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationCSharpProject.Tests
{
    [TestClass]
    internal class ApiTest1
    {
        [TestMethod]
        public static void TranslateEnglishToFrench()
        {
            const string test_word = "test";
            const string source_lang_code = "en";
            const string target_lang_code = "fr";

            var client = new RestClient("https://od-api.oxforddictionaries.com:443/api/v2/");
            var request = new RestRequest("translations/" + source_lang_code + '/' + target_lang_code + '/' + test_word);
            request.AddHeader("app_id", "daf7fa24");
            request.AddHeader("app_key", "");

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
            Assert.Equals(response.StatusCode, 404);
        }
    }
}
