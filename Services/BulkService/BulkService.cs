using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using micropay.Dto;
using micropay.Models;
using micropay.Services.AuthService;
using micropay.ViewModels;
using micropay.Data;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace micropay.Services.BulkService;

public class BulkService : IBulkService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _accessor;
    private readonly IAuthService _authService;

    public BulkService(DataContext context, IHttpContextAccessor accessor, IAuthService authService)
    {
        _context = context;
        _accessor = accessor;
        _authService = authService;
    }

    public async Task<string> SendInvoice(int TransactionId)
    {
        var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == TransactionId);
        var token = await _context.Tokens.FirstOrDefaultAsync(x => x.Id == transaction.TokenId);
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == token.UserId);
        string url = "https://api.mozesms.com/message/v2";
        string apiKey = "149:bxfpc7-oLlFCf-oMImz8-TjVbcY";
        string from = "MOZOTP";
        string to = "+258" + transaction.Contact.ToString();
        string message = $@"Nova fatura de: {user.Name} {user.Surname}

Referente: {token.Name}

Entidade: 12345
Referencia: 0000000000{transaction.Id}
Data: {transaction.Created.ToString("dd/MM/yyyy")}
Valor: {transaction.Amount} MT

Pague por deposito BIM e BCI, Conta Movel, IZI, Internet Banking e ATM. Para mais detalhes, acesse: https://sparkpaga.com/invoice/0000000000{transaction.Id}";

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
                
                return responseContent;
            }
            else
            {
                return "Request failed";
            }
        }
    }
}