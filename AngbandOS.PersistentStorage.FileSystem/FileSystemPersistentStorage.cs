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

            // Process a folder of entities.
            foreach (KeyValuePair<string, string> keyValuePair in jsonEntities)
            {
                string key = keyValuePair.Key;
                if (!IsValidName(key))
                {
                    throw new Exception($"The entity key name {key} contains invalid characters.  Only a-z, A-Z, 0-9, . characters are allows.");
                }

                // Check to see if there is any content to save.  Empty content will not be written to the disk.
                if (keyValuePair.Value.Length > 0)
                {
                    // Check to see if we need to create the folder.
                    if (!directoryCreated)
                    {
                        Directory.CreateDirectory(folderName);
                    }

                    // Write the file.
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
            try
            {
                string[] folderFiles = Directory.GetFiles(folderName);
                List<string> entities = new List<string>();
                foreach (string filename in folderFiles)
                {
                    string json = File.ReadAllText(Path.Combine(folderName, filename));
                    entities.Add(json);
                }
                return entities.ToArray();
            }
            catch (DirectoryNotFoundException)
            {
                return new string[] { };
            }
        }

        public string? RetrieveEntity(string repositoryName)
        {
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);
            string filename = $"{folderName}.json";
            try
            {
                string json = File.ReadAllText(filename);
                return json;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
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
