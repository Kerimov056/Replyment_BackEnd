using EndProject.Application.DTOs.Payment;
using Replyment.Application.Abstraction.Services.Payment.PayPal;

namespace Replyment.Infrastructure.Services.Payment.PayPal;

public class PayPalService : IPayPalPayment
{
    public Task<ChargeResource> CreateCharge(CreateChargeResource resource, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerResource> CreateCustomer(CreateCustomerResource resource, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
