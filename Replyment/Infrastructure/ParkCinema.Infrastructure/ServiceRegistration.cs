using Microsoft.Extensions.DependencyInjection;
using Replyment.Application.Abstraction.Services.Payment.PayPal;
using Replyment.Application.Abstraction.Services.Payment.Stripe;
using Replyment.Application.Abstraction.Services.Payment;
using Replyment.Application.Abstraction.Services.Stroge;
using Replyment.Application.Abstraction.Services.Stroge.Local;
using Replyment.Infrastructure.Services;
using Replyment.Infrastructure.Services.Stroge;
using Replyment.Infrastructure.Services.Stroge.Local;
using Stripe;
using Replyment.Infrastructure.Services.Payment.Stripe;
using Replyment.Infrastructure.Services.Payment.PayPal;
using Replyment.Application.Abstraction.Services.QrCode;
using Replyment.Infrastructure.Services.QrCode;
using Replyment.Application.Abstraction.Services.Cryptography;
using Replyment.Infrastructure.Services.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Replyment.Application.Abstraction.Services;
using Replyment.Infrastructure.Services.TokenResponseJwt;
using Replyment.Application.Abstraction.Services.Email;
using Replyment.Infrastructure.Services.Email;

namespace Replyment.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        //File
        //services.AddScoped<IStorgeService, StorgeService();
        services.AddScoped<IStorageFile, StorageFile>();
        services.AddScoped<ILocalStorage, LocalStorage>();

        //Payment
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IStripePayment, StripeService>();
        services.AddScoped<IPayPalPayment, PayPalService>();
        services.AddScoped<TokenService>();
        services.AddScoped<CustomerService>();
        services.AddScoped<ChargeService>();
        //---------------------------------
        services.AddPayment<StripeService>();

        //user
        services.AddScoped<ITokenHandler, TokkenHandler>();

        //QRCode
        services.AddScoped<IQRCoderServıces, QRCoderServıces>();

        //Cryptography 
        services.AddScoped<IEncryptionService, EncryptionService>();

        //Email
        services.AddScoped<IEmailService, EmailService>();
    }

    public static void AddStorageFile<T>(this IServiceCollection services) where T : Storage, IStorageFile
    {                                                                               //class
        services.AddScoped<IStorageFile, T>();
    }

    public static void AddPayment<T>(this IServiceCollection services) where T : class, IPayment
    {
        services.AddScoped<IPayment, T>();
    }
}
