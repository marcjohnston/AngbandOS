namespace Cthangband.PersistentStorage
{
    internal interface IPersistentStorage
    {
        string Read(string slot);
        bool Write(string value, string filename);
    }
}
