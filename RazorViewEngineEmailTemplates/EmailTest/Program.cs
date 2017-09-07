using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmailTest
{
    class Program
    {
        private static HttpClient _client = new HttpClient();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press [enter] to send a request");
                Console.WriteLine("Enter 'exit' to close the app");

                var input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }

                var test = GetEmail().Result;
                Console.WriteLine(test);
            }
        }

        static async Task<string> GetEmail()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await _client.GetAsync("http://localhost:5020/api/email");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
