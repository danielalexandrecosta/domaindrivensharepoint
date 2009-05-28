using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.Assets.Repositories.UOWAssetRepository.UnitOfWork
{
    public interface IUnitOfWork<TEntity>
    {
        int InsertCount { get; }
        int UpdateCount { get; }
        int DeleteCount { get; }

        TEntity Get(TEntity entity);
        bool Contains(TEntity entity);
        void AddInsert(TEntity entity, IEntityItem<TEntity> entityItem);
        void AddUpdate(TEntity entity, IEntityItem<TEntity> entityItem);
        void AddDelete(TEntity entity);
        void Update();
        void Clear();
    }
}