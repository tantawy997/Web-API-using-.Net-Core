using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL;

public interface IGenricRepo<TEntity> where TEntity : class 
{
     List<TEntity> GetAll();

     TEntity? GetById(Guid id);

     void Add(TEntity entity);

     void Update(TEntity entity);


     void Delete(TEntity entity);    

     void DeleteById(Guid id);

    void SaveChanges();



}
