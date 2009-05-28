using System.Collections.Generic;

namespace TrackMan.Framework.ListServices
{
    public interface IListService<TEntity>
    {
        IEntityItem<TEntity> CreateItem();
        IEnumerable<IEntityItem<TEntity>> Query(string queryString);
        IEnumerable<IEntityItem<TEntity>> GetAll();
    }
}