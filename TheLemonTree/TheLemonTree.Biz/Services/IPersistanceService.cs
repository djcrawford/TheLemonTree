using System;
using System.Collections.Generic;
using System.Text;
using TheLemonTree.Biz.Models;

namespace TheLemonTree.Biz.Services
{
    public interface IPersistanceService<TModel,TKey> where TModel:class,IEntity<TModel,TKey>, new()
    {
        TModel Create(TModel item);
        TModel Read(TKey key);
        IEnumerable<TModel> ReadAll();
        void Update(TModel item);
        void Delete(TKey key);
    }
}
