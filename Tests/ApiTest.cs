using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationCSharpProject.Tests
{
    public class ApiTest
    {
        public static void Main()
        {
            const string word_id = "insurance";
            const string lang_code = "an-gb";
            const string fields = "etymologies";
            const string strictMatch = "false";

            var client = new RestClient("https://od-api.oxforddictionaries.com:443/api/v2/");
            var request = new RestRequest("entries/" +lang_code+ '/' + word_id + "?fields=" +fields+ "&strictMatch" +strictMatch);
            request.AddHeader("app_id", "daf7fa24");
            request.AddHeader("app_key","");

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);

            dynamic stuff = JObject.Parse(response.Content.ToString());
            Console.WriteLine(stuff.results[0].lexicalEntries[0].entries[0].etymologies[0]);

            Assert.IsNotNull(stuff.results[0].lexicalEntries[0].entries[0].etymologies[0]);
            Assert.Equals(response.StatusCode, 200);

        }
    }
}
