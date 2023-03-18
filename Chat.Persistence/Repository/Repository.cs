using Chat.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repository;

public class Repository<T> : IRepository<T> where T : class
{

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }


    protected DbContext _dbContext;
    protected DbSet<T> _dbSet;


    public virtual IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public virtual T? GetFirstOrDefault(Func<T, bool> predicate)
    {
        return _dbSet.FirstOrDefault(predicate);
    }


    public virtual void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}
