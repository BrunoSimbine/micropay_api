using System.Security.Claims;
using micropay.Dto;
using micropay.Models;
using micropay.Services.AuthService;
using micropay.ViewModels;

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace micropay.Services.BulkService;

public class BulkService : IBulkService
{
    private readonly IHttpContextAccessor _accessor;
    private readonly IAuthService _authService;

    public BulkService(IHttpContextAccessor accessor, IAuthService authService)
    {
        _accessor = accessor;
        _authService = authService;
    }

    public async Task<string> SendInvoice(int TransactonId)
    {
        string url = "https://api.mozesms.com/message/v2";
        string apiKey = "YOUR_API_KEY";
        string from = "Sender_ID";
        string to = "+258845888195";
        string message = "Hello from MozeSMS API";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("from", from),
                new KeyValuePair<string, string>("to", to),
                new KeyValuePair<string, string>("message", message)
            });

            HttpResponseMessage response = await client.PostAsync(url, parameters);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Request successful. Response:");
                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
    }
}