using Microsoft.EntityFrameworkCore;
using Replyment.Application.Abstraction.Services.Subscription;
using Replyment.Domain.Entities;
using Replyment.Domain.Enums.SubscriptionLevel;
using Replyment.Persistance.Context;

namespace Replyment.API.BackGroundServıces;

public class SubscriptionBackService : IHostedService
{
    private IServiceProvider _serviceProvider;
    private Timer _timer;

    public SubscriptionBackService(IServiceProvider serviceProvider, Timer timer)
    {
        _serviceProvider = serviceProvider;
        _timer = timer;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"{nameof(SubscriptionBackService)}Service started....");
        _timer = new Timer(carStautus, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        return Task.CompletedTask;
    }


    private async void carStautus(object state)
    {
        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var subscriptionService = scope.ServiceProvider.GetRequiredService<ISubscriptionService>();


            var today = DateTime.UtcNow;
            var subscriptionExpired = await dbContext.Subscriptions
                        .Where(x => x.EndDate.Hour == today.Hour && x.EndDate.Minute == today.Minute && x.SubscriptionLevel==SubscriptionLevel.OneYear)
                        .ToListAsync();

            foreach (var item in subscriptionExpired)
            {
                await subscriptionService.ChangeSubscriptionLevel(item);
            }

        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        Console.WriteLine($"{nameof(SubscriptionBackService)}Service stopped....");
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer = null;
    }
}
