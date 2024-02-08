using AngbandOS.Core.Interface;

namespace AngbandOS.PersistentStorage
{
    public class FileSystemPersistentStorage : ICorePersistentStorage
    {
        private string SaveFilename;

        public FileSystemPersistentStorage(string saveFilename)
        {
            SaveFilename = saveFilename;
        }

        public bool GameExists()
        {
            return File.Exists(SaveFilename);
        }

        public void PersistEntities(string repositoryName, KeyValuePair<string, string>[] jsonEntities)
        {
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);
            string filename = $"{folderName}.json";

            try
            {
                Directory.Delete(folderName, true);
            }
            catch (DirectoryNotFoundException) { }
            catch (Exception ex)
            {

            }

            try
            {
                File.Delete(filename);
            }
            catch (FileNotFoundException) { }
            catch (Exception ex)
            {

            }

            bool directoryCreated = false;

            // If we need to write a .json file for empty keys, store the values in an array.
            List<string> strings = new List<string>();
            foreach (KeyValuePair<string, string> keyValuePair in jsonEntities)
            {
                // Check to see if the key for the entity is empty.  If so, we will store the entity as a {repositoryName}.json file.
                if (keyValuePair.Key == "")
                {
                    strings.Add(keyValuePair.Value);
                }
                else
                {
                    // Process a folder of entities.
                    if (keyValuePair.Value.Length > 0)
                    {
                        if (!directoryCreated)
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        string subfolderPath = Path.Combine(folderName, keyValuePair.Key);
                        string subfolderFilename = $"{subfolderPath}.json";
                        File.WriteAllText(subfolderFilename, keyValuePair.Value);
                    }
                }
            }

            // Write the .json file for the null key values.
            if (strings.Count > 0)
            {
                string jsonArray = System.Text.Json.JsonSerializer.Serialize(strings);
                File.WriteAllText(filename, jsonArray);
            }
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
