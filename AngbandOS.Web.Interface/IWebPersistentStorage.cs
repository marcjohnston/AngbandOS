namespace AngbandOS.Web.Interface
{
    /// <summary>
    /// Represents an interface that a persistent storage driver needs to implement for the web interface.
    /// </summary>
    public interface IWebPersistentStorage
    {
        bool Delete(string id, string username);

        SavedGameDetails[] List(string username);
    }
}
