using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RapidApi.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&language=en&to_symbol=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "4b38bf5c65msh4807436cd4553b5p129eefjsneb11faede721" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<>(body);
                return View(values);
            }
            
        }
    }
}
