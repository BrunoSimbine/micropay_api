using micropay.Models;

namespace micropay.Services.PaymentService;

public class PaymentService : IPaymentService
{
    public async Task<bool> PayWithMpesa(int TransactionId)
    {
        
    }

    public async Task<bool> PayWithEmola(int TransactionId)
    {
        
    }

    public async Task<bool> PayDirectWithMpesa(string Contact)
    {
        
    }

    public async Task<bool> PayDirectWithEmola(string Contact)
    {
        
    }

    public async Task<bool> PayWithCard()
    {
        
    }

    public async Task<bool> PayWithBitcoin()
    {
        
    }

    public async Task<bool> PayWithPaypal()
    {
        
    }

    public async Task<bool> PayWithSIMO()
    {
        
    }
}