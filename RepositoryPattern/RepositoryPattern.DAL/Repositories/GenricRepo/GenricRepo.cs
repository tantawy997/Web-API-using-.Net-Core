using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL;

public class GenricRepo<TEntity> : IGenricRepo<TEntity> where TEntity : class
{
    private readonly AppDbContext context;
    public GenricRepo(AppDbContext _context)
    {
          context = _context;
    }

    public void Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }


    public void DeleteById(Guid id)
    {
        var entityId = GetById(id);
        if (entityId != null)
        {
            context.Set<TEntity>().Remove(entityId);
        }
    }

    public List<TEntity> GetAll()
    {
        return context.Set<TEntity>().ToList();
    }

    public TEntity? GetById(Guid id)
    {
        return context.Set<TEntity>().Find(id);
    }


    public void Update(TEntity entity)
    {

    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}
