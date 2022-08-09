using Cthangband;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angband.Wpf
{
    internal class Program
    {
        public static string SaveFolder;
        private static string[] _saveSlot;

        public static void GetDefaultFolder()
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            savePath = Path.Combine(savePath, "My Games");
            savePath = Path.Combine(savePath, Constants.VersionName);
            SaveFolder = savePath;
            _saveSlot = new string[4];
            for (int i = 0; i < 4; i++)
            {
                _saveSlot[i] = Path.Combine(savePath, $"slot{i + 1}.v_{Constants.VersionMajor}_{Constants.VersionMinor}_savefile");
            }
        }

        public static bool DirCreate(string path)
        {
            // Path might be empty - this is not an error condition
            if (string.IsNullOrEmpty(path))
            {
                return true;
            }
            DirectoryInfo intended = new DirectoryInfo(path);
            // If it already exists, then we're fine
            if (intended.Exists)
            {
                return true;
            }
            intended.Create();
            return true;
        }

        public static void Quit(string reason)
        {
            if (!string.IsNullOrEmpty(reason))
            {
                MessageBox.Show(reason, Constants.VersionName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Environment.Exit(0);
        }

        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                GetDefaultFolder();
                if (!DirCreate(SaveFolder))
                {
                    Quit($"Cannot create '{SaveFolder}'");
                }
                string gameGuid = GameServer.NewGame();
                GameServer.Play(gameGuid, new MainWindow());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
