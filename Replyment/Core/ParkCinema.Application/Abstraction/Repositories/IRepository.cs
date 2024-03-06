using Microsoft.EntityFrameworkCore;
using Replyment.Domain.Entities.Common;

namespace Replyment.Application.Abstraction.Repositories;

public interface IRepository<T> where T : BaseEntity, new()
{
    public DbSet<T> Table { get; }
}
