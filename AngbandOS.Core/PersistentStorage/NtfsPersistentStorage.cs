using System;
using System.IO;

namespace Cthangband.PersistentStorage
{
    [Serializable]
    internal class NtfsPersistentStorage : IPersistentStorage
    {
        public string Read(string slot)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid">The filename to store the game as.</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Write(string value, string filename)
        {
            string path = Path.Combine(Program.SaveFolder, filename);
            FileInfo info = new FileInfo(path);
            using (FileStream stream = info.OpenWrite())
            {
                //stream.Write(value, 0, value.Length);   
            }
            return true;
        }
    }
}
