using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repositories.Implementations;

public class ARepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
{
    protected DishContext Context { get; }
    protected DbSet<TEntity> Table { get; }
    public ARepositoryAsync(DishContext context)
    {
        Context = context;
        Table = context.Set<TEntity>();
    } 
    
    
    
    
    public async Task<TEntity> CreateAsync(TEntity t)
    {
        Table.Add(t);
        await Context.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list)
    {
        Table.AddRange(list);
        await Context.SaveChangesAsync();
        return list;
    }

    public async Task UpdateAsync(TEntity t)
    {
        Context.ChangeTracker.Clear();
        Table.Update(t);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list)
    {
        Table.UpdateRange(list);
        await Context.SaveChangesAsync();
    }

    public async Task<TEntity>? ReadAsync(int id)
    {
        return (await Table.FindAsync(id))!;
    }

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await Table.Where(filter).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAsync(int start, int count)
    {
        return await Table.Skip(start).Take(count).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAllAsync()
    {
        return await Table.ToListAsync();
    }

    public async Task DeleteAsync(TEntity t)
    {
        Table.Remove(t);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Table.Remove(Table.Find(id)!);
        await Context.SaveChangesAsync();
    }
}