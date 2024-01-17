using AngbandOS.Core.Interface;

namespace AngbandOS.PersistentStorage
{
    public class FileSystemPersistentStorage : ICorePersistentStorage
    {
        private string SaveFilename;

        public FileSystemPersistentStorage(string filename)
        {
            SaveFilename = filename;
        }

        public bool GameExists()
        {
            return File.Exists(SaveFilename);
        }

        public void PersistEntities(string repositoryName, string[] jsonEntities)
        {
            throw new NotImplementedException();
        }

        public string[] RetrieveEntities(string repositoryName) 
        {  
            throw new NotImplementedException();
        }

        public byte[]? ReadGame()
        {
            byte[]? data = null;
            try
            {
                data = File.ReadAllBytes(SaveFilename);
            }
            catch (Exception)
            {
            }
            return data;
        }

        public bool WriteGame(GameDetails gameDetails, byte[] value)
        {
            File.WriteAllBytes(SaveFilename, value);
            return true;
        }
    }
}
