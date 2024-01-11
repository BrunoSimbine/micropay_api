using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;

namespace micropay.Services.PaymentService;

public interface IPaymentService
{
    Task<bool> PayWithMpesa(int TransactionId);
    Task<bool> PayWithEmola(int TransactionId);
    Task<bool> PayDirectWithMpesa(string Contact);
    Task<bool> PayDirectWithEmola(string Contact);
    Task<bool> PayWithCard();
    Task<bool> PayWithBitcoin();
    Task<bool> PayWithPaypal();
    Task<bool> PayWithSIMO();
}