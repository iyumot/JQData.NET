using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JQData.NET
{
    public static class JAPI
    {
        private const string ApiUrl = "https://dataapi.joinquant.com/apis";

        private static HttpClient webClient { get; } = new HttpClient();

        public static string Token { get; private set; }

        private static bool IsTokenAvaliable => !string.IsNullOrWhiteSpace(Token);

        public static bool GetToken(string phone, string password)
        {
            return GetTokenAsync(phone, password).Result;
        }
        public static async Task<bool> GetTokenAsync(string phone, string password)
        {
            var json = $"{{ \"method\": \"get_token\", \"mob\": \"{phone}\", \"pwd\": \"{password}\" }}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resp = await webClient.PostAsync(ApiUrl, content);
            var token = await resp.Content.ReadAsStringAsync();

            if (token.StartsWith("error"))
                return false;

            Token = token;
            return true;
        }

        public static void GetAllSecurities()
        {

        }

    }
}
