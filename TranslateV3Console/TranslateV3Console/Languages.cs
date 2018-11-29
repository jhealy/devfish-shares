using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
// NOTE: Install the Newtonsoft.Json NuGet package.
using Newtonsoft.Json;

namespace TranslateV3Console
{
    public static class Languages
    {
        static string host = "https://api.cognitive.microsofttranslator.com";
        static string path = "/languages?api-version=3.0";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = Constants.TRANSLATE_KEY;

        public async static Task<bool> GetLanguagesAsync()
        {
            Console.WriteLine("--- GETLANGUAGESASYNC ---");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
                var uri = host + path;
                var response = await client.GetAsync(uri);
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(result), Formatting.Indented);

                // Note: If writing to the console, set this.
                Console.OutputEncoding = UnicodeEncoding.UTF8;
                System.IO.File.WriteAllBytes("output.txt", Encoding.UTF8.GetBytes(json));
            }
            Console.WriteLine("GetLanguagesAsync() done....");
            return true;
        }
    }
}
