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

        private bool IsValidName(string name)
        {
            foreach (char c in name.ToLower())
            {
                if (!"abcdefghijklmnopqrstuvwxyz0123456789._".Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        public void PersistEntities(string repositoryName, KeyValuePair<string, string>[] jsonEntities)
        {
            if (!IsValidName(repositoryName))
            {
                throw new Exception($"The repository name {repositoryName} contains invalid characters.  Only a-zA-Z0-9_. characters are allows.");
            }
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);
            bool directoryCreated = false;

            try
            {
                Directory.Delete(folderName, true);
            }
            catch (DirectoryNotFoundException)
            {
            }

            foreach (KeyValuePair<string, string> keyValuePair in jsonEntities)
            {
                string key = keyValuePair.Key;
                if (!IsValidName(key))
                {
                    throw new Exception($"The entity key name {key} contains invalid characters.  Only a-z, A-Z, 0-9, . characters are allows.");
                }

                // Process a folder of entities.
                if (keyValuePair.Value.Length > 0)
                {
                    if (!directoryCreated)
                    {
                        Directory.CreateDirectory(folderName);
                    }
                    string subfolderPath = Path.Combine(folderName, key);
                    string subfolderFilename = $"{subfolderPath}.json";
                    File.WriteAllText(subfolderFilename, keyValuePair.Value);
                }
            }
        }

        public void PersistEntity(string repositoryName, string json)
        {
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);
            string filename = $"{folderName}.json";

            try
            {
                File.Delete(filename);
            }
            catch (FileNotFoundException)
            {
            }

            // Write the .json file for the null key values.
            if (json.Length > 0)
            {
                File.WriteAllText(filename, json);
            }
        }

        public string[] RetrieveEntities(string repositoryName)
        {
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);

            List<string> entities = new List<string>();
            foreach (string filename in Directory.GetFiles(folderName))
            {
                string json = File.ReadAllText(Path.Combine(folderName, filename));
                entities.Add(json);
            }
            return entities.ToArray();
        }

        public string RetrieveEntity(string repositoryName)
        {
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);
            string filename = $"{folderName}.json";
            string json = File.ReadAllText(filename);
            return json;
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
