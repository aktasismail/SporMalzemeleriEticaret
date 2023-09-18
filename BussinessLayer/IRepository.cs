using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression);
        T Get(int Id);
        T Find(Expression<Func<T, bool>> expression);
        int Add(T Entity);
        int Update(T Entity);
        int Delete(int Id);
    }
}
