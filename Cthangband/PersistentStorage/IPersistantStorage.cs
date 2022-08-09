namespace Cthangband.PersistentStorage
{
    internal interface IPersistentStorage
    {
        string Read(string slot);
        bool Write(byte[] value, string filename);
    }
}
