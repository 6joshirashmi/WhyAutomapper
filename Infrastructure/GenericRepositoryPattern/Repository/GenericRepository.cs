using Domain;
using Domain.EFCore;
using Infrastructure.GenericRepositoryPattern.Functionality;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.GenericRepositoryPattern.Repository
{
    // Generic DAL
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        // Define the Generic DBSet at this point.
        // It will currently works for two tables : user and userprofile

        private readonly UserDBContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public GenericRepository(UserDBContext _userDBContext)
        {
                this.context = _userDBContext;
                entities=context.Set<T>();
        }

        int IGenericRepository<T>.Add(T entity)  //Helper methods and wrapper method/ generalized method
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
           return context.SaveChanges();
        }

        int IGenericRepository<T>.Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
           return context.SaveChanges();
        }

        List<T> IGenericRepository<T>.GetAll()
        {
            return entities.ToList();
        }

        T IGenericRepository<T>.GetById(int Id)
        {
            return entities.SingleOrDefault(s => s.Id == Id);
        }

        int IGenericRepository<T>.Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
           return context.SaveChanges();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
