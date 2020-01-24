using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iocco_api.BusinessLayer
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Insert(List<TEntity> entityList);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(List<TEntity> entityList);
        void Delete(object id);

    }
}
