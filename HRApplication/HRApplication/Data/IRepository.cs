using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication.Data
{
    public interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T GetById(int? id);
        void Add(T t);
        void Update(T t);
        void Delete(T t);
       
    }
}
