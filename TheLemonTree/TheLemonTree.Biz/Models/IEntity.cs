using System;
using System.Collections.Generic;
using System.Text;

namespace TheLemonTree.Biz.Models
{
    public interface IEntity<TModel,TKey>
    {
        TKey Id { get; set; }
    }
}
