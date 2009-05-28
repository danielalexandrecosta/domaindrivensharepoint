namespace TrackMan.Framework.ListServices
{
    public interface IEntityItem<TEntity>
    {
        TEntity CreateEntity();
        void Update(TEntity asset);
        void Delete();
    }
}