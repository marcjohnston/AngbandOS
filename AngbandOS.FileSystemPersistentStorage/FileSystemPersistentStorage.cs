using AngbandOS.Interface;

namespace AngbandOS.PersistentStorage
{
    [Serializable]
    public class FileSystemPersistentStorage : IPersistentStorage
    {
        public byte[] ReadGame()
        {
            string path = Path.Combine("C:\\Users\\Marc\\AppData\\Roaming", "saved-game");
            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueIdentifier">The unique identifier to store the game as.</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteGame(GameDetails gameDetails, byte[] value)
        {
            string path = Path.Combine("C:\\Users\\Marc\\AppData\\Roaming", "saved-game");
            File.WriteAllBytes(path, value);
            return true;
        }
    }
}
