using Microsoft.EntityFrameworkCore;
using Replyment.Application.Abstraction.Repositories;
using Replyment.Domain.Entities.Common;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;
    public WriteRepository(AppDbContext context) => _context = context;
    public DbSet<T> Table => _context.Set<T>();
    public async Task AddAsync(T entity) => await _context.AddAsync(entity);
    public async Task AddRangeAsync(IEnumerable<T> entities) => await Table.AddRangeAsync(entities);    
    public void Remove(T entity) => Table.Remove(entity);
    public void RemoveRange(IEnumerable<T> entities) => Table.RemoveRange(entities);
    public void Update(T entity) => Table.Update(entity);
    public async Task SaveChangeAsync() => await _context.SaveChangesAsync();
}
