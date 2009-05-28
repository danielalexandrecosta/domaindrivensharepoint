namespace TrackMan.Framework.ListServices
{
    public interface IListItemWrapper
    {
        object this[string fieldName] { get; set; }
        void Update();
        void Delete();
    }
}