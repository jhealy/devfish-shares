using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
// NOTE: Install the Newtonsoft.Json NuGet package.
using Newtonsoft.Json;

namespace TranslateV3ConsoleNET
{
    public static class DictionaryExamples
    {
        static string host = "https://api.cognitive.microsofttranslator.com";
        static string path = "/dictionary/examples?api-version=3.0";
        // Translate from English to French.
        static string params_ = "&from=en&to=fr";

        static string uri = host + path + params_;

        // NOTE: Replace this example key with a valid subscription key.
        static string key = Constants.TRANSLATE_KEY;

        static string text = "great";
        static string translation = "formidable";

        public async static Task<bool> DoExamples()
        {
            Console.WriteLine("--- DICTIONARY EXAMPLES ---");
            System.Object[] body = new System.Object[] { new { Text = text, Translation = translation } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented);

                Console.OutputEncoding = UnicodeEncoding.UTF8;
                Console.WriteLine(result);

                return true;
            }
        }
    }
}
