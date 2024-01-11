using micropay.Models;

namespace micropay.Services.PaymentService;

public class PaymentService : IPaymentService
{
    public async Task<bool> PayWithMpesa(int TransactionId)
    {
        return true;
    }

    public async Task<bool> PayWithEmola(int TransactionId)
    {
        return true;
    }

    public async Task<bool> PayDirectWithMpesa(string Contact)
    {
        await Task.Delay(2000);
        return true;
    }

    public async Task<bool> PayDirectWithEmola(string Contact)
    {
        await Task.Delay(2000);
        return true;
    }

    public async Task<bool> PayWithCard()
    {
        return true;
    }

    public async Task<bool> PayWithBitcoin()
    {
        return true;
    }

    public async Task<bool> PayWithPaypal()
    {
        return true;
    }

    public async Task<bool> PayWithSIMO()
    {
        return true;
    }

    public async Task<bool> PayWithCash()
    {
        return true;
    }
}