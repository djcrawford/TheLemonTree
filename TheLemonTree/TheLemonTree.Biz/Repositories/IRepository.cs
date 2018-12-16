using System.Collections.Generic;
using TheLemonTree.Biz.Models;

namespace TheLemonTree.Biz.Repositories
{
    public interface IRepository<TModel,TKey>
    {
        void Add(TModel model);
        IEnumerable<TModel> GetAll();
        void Remove(TKey id);
    }
}