using EndProject.Application.DTOs.Payment;

namespace Replyment.Application.Abstraction.Services.Payment;

public interface IPayment
{
    Task<CustomerResource> CreateCustomer(CreateCustomerResource resource, CancellationToken cancellationToken);
    Task<ChargeResource> CreateCharge(CreateChargeResource resource, CancellationToken cancellationToken);
}
