using AngbandOS.Interface;

namespace AngbandOS.PersistentStorage
{
    [Serializable]
    public class FileSystemPersistentStorage : IPersistentStorage
    {
        public SavedGameDetails[] ListSavedGames(string username)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadGame(string username, string guid)
        {
            string path = Path.Combine("C:\\Users\\Marc\\AppData\\Roaming", guid);
            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueIdentifier">The unique identifier to store the game as.</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteGame(string username, string guid, GameDetails gameDetails, byte[] value)
        {
            string path = Path.Combine("C:\\Users\\Marc\\AppData\\Roaming", guid);
            File.WriteAllBytes(path, value);
            return true;
        }
    }
}
