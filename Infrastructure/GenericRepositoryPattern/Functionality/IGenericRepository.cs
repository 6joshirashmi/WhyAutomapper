using Domain;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.GenericRepositoryPattern.Functionality
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        T GetById(int Id);
        List<T> GetAll();

    }
}
