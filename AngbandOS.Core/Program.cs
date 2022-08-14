// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.Debug;
using Cthangband.Enumerations;
using Cthangband.StaticData;
using Cthangband.UI;
using System.Runtime.Serialization.Formatters.Binary;
using Cthangband.PersistentStorage;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Cthangband
{
    internal static class Program
    {
        public static readonly Rng Rng = new Rng();
        public static bool ExitToDesktop;
        public static HighScoreTable HiScores;
        public static string SaveFolder;
        private static string _activeSaveSlot;
        private static string[] _saveSlot;
        private static Settings _settings;
        private static SaveGame saveGame;
        public static IPersistentStorage PersistentStorage;

        public static SaveGame LoadOrCreate(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            Program.PersistentStorage = new NtfsPersistentStorage();
            if (file.Exists)
            {
                return DeserializeFromSaveFolder<SaveGame>(fileName);
            }
            else
            {
                SaveGame game = new SaveGame(Program.ActiveSaveSlot);
                game.Initialise();
                return game;
            }
        }
        //public static void Run(SaveGame Game)
        //{
        //    Game.MsgFlag = false;
        //    Game.MsgPrint(null);
        //    Game.MsgFlag = false;

        //    // Set a globally accessible reference to our game
        //    SaveGame.Instance = Game;
        //    // And play it!
        //    Game.Play();
        //    // Remove the global reference
        //    SaveGame.Instance = null;
        //}

        public static string ActiveSaveSlot
        {
            get => _activeSaveSlot;
            private set
            {
                _activeSaveSlot = value;

                saveGame = LoadOrCreate(value);
            }
        }

        public static T DeserializeFromSaveFolder<T>(string filename)
        {
            string path = Path.Combine(SaveFolder, filename);
            FileInfo info = new FileInfo(path);
            T o;
            if (!info.Exists)
            {
                return default;
            }
            using (FileStream stream = info.OpenRead())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                o = (T)formatter.Deserialize(stream);
                stream.Close();
            }
            return o;
        }

        /// <summary>
        /// Serializes an object and uses the persistent storage services to write the object to the desired facilities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="filename"></param>
        public static void SerializeToSaveFolder<T>(T o, string filename)
        {
            string jsonString = JsonSerializer.Serialize(o);
//            BinaryFormatter formatter = new BinaryFormatter();
//            MemoryStream memoryStream = new MemoryStream();
//            formatter.Serialize(memoryStream, o);
//            memoryStream.Position = 0;
//            T temp = (T)formatter.Deserialize(memoryStream);

            //string path = Path.Combine(Program.SaveFolder, filename);
            //FileInfo info = new FileInfo(path);
            //using (FileStream stream = info.OpenWrite())
            //{
            //    stream.Write(value, 0, value.Length);
            //    formatter.Serialize(stream, o);
            //}

            PersistentStorage.Write(jsonString, filename);
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

        public static void Quit(string reason)
        {
            if (!string.IsNullOrEmpty(reason))
            {
                MessageBoxShow(reason);
            }
            Environment.Exit(0);
        }

        public static void MessageBoxShow(string message)
        {
            // MessageBox.Show(reason, Constants.VersionName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static Dictionary<string, HighScore> GetHighScoreFromSaves()
        {
            var saves = new Dictionary<string, HighScore>();
            for (int i = 0; i < 4; i++)
            {
                var score = GetHighScoreFromSave(_saveSlot[i]);
                if (score != null)
                {
                    saves.Add(_saveSlot[i], score);
                }
            }
            return saves;
        }

        private static int ChooseProfile(int saveIndex, string action)
        {
            saveGame.Gui.SetBackground(BackgroundImage.Normal);
            saveGame.Gui.Clear();
            for (int i = 0; i < 4; i++)
            {
                PeekSavefile(_saveSlot[i], i, false);
            }
            saveGame.Gui.Print(Colour.BrightTurquoise, "Savegame 1", 5, 15);
            saveGame.Gui.Print(Colour.BrightTurquoise, "Savegame 2", 5, 55);
            saveGame.Gui.Print(Colour.BrightTurquoise, "Savegame 3", 28, 15);
            saveGame.Gui.Print(Colour.BrightTurquoise, "Savegame 4", 28, 55);
            saveGame.Gui.Print(Colour.BrightTurquoise, $"Select a savegame to {action}.".PadCenter(80), 23, 0);
            saveGame.Gui.Refresh();
            saveGame.Gui.Save();
            int displayRow = 0;
            int displayCol = 0;
            while (true)
            {
                saveGame.Gui.Load();
                switch (saveIndex)
                {
                    case 0:
                        displayRow = 9;
                        displayCol = 6;
                        break;

                    case 1:
                        displayRow = 9;
                        displayCol = 46;
                        break;

                    case 2:
                        displayRow = 31;
                        displayCol = 6;
                        break;

                    case 3:
                        displayRow = 31;
                        displayCol = 46;
                        break;
                }
                saveGame.Gui.Print(Colour.BrightPurple, "+----------------+", displayRow - 2, displayCol + 5);
                saveGame.Gui.Print(Colour.BrightPurple, "+----------------+", displayRow + 5, displayCol + 5);
                for (int i = -1; i < 5; i++)
                {
                    saveGame.Gui.Print(Colour.BrightPurple, "|", displayRow + i, displayCol + 5);
                    saveGame.Gui.Print(Colour.BrightPurple, "|", displayRow + i, displayCol + 22);
                }
                saveGame.Gui.HideCursorOnFullScreenInkey = true;
                var c = saveGame.Gui.Inkey();
                if (c == '6' || c == '4')
                {
                    switch (saveIndex)
                    {
                        case 0:
                            saveIndex = 1;
                            break;

                        case 1:
                            saveIndex = 0;
                            break;

                        case 2:
                            saveIndex = 3;
                            break;

                        case 3:
                            saveIndex = 2;
                            break;
                    }
                }
                if (c == '8' || c == '2')
                {
                    switch (saveIndex)
                    {
                        case 0:
                            saveIndex = 2;
                            break;

                        case 1:
                            saveIndex = 3;
                            break;

                        case 2:
                            saveIndex = 0;
                            break;

                        case 3:
                            saveIndex = 1;
                            break;
                    }
                }
                if (c == '\r' || c == ' ')
                {
                    return saveIndex;
                }
                if (c == '\x1b')
                {
                    return -1;
                }
            }
        }

        private static HighScore GetHighScoreFromSave(string save)
        {
            FileInfo file = new FileInfo(save);
            if (!file.Exists)
            {
                return null;
            }
            SaveGame tempSaveGame;
            try
            {
                tempSaveGame = DeserializeFromSaveFolder<SaveGame>(save);
            }
            catch (Exception)
            {
                return null;
            }
            if (tempSaveGame.Player == null)
            {
                return null;
            }
            if (tempSaveGame.Player.IsWizard)
            {
                return null;
            }
            return new HighScore(tempSaveGame);
        }

        private static int LoadGame(int saveIndex)
        {
            int choice = ChooseProfile(saveIndex, "load");
            if (choice >= 0)
            {
                if (PeekSavefile(_saveSlot[choice], 0, true))
                {
                    return choice;
                }
            }
            return -1;
        }

        //private static int NewGame(int saveIndex)
        //{
        //    int choice = ChooseProfile(saveIndex, "overwrite");
        //    if (choice >= 0)
        //    {
        //        if (PeekSavefile(_saveSlot[choice], 0, true))
        //        {
        //            var text = new List<string>
        //            {
        //                $"Savegame {choice} already exists.",
        //                "Overwriting it with a new game will",
        //                "lose the information about monsters",
        //                "that previous characters in that",
        //                "savegame have collected. If all you",
        //                "want to do is play a new character,",
        //                "you should load it instead of over-",
        //                "witing it. Are you sure you wish to",
        //                $"overwrite savegame {choice}?"
        //            };
        //            var options = new List<string> { "Overwrite", "Cancel" };
        //            var popup = new PopupMenu(options, text, 36);
        //            var result = popup.Show();
        //            switch (result)
        //            {
        //                case -1:
        //                case 1:
        //                    return -1;

        //                case 0:
        //                    FileInfo fileInfo = new FileInfo(_saveSlot[choice]);
        //                    if (fileInfo.Exists)
        //                    {
        //                        fileInfo.Delete();
        //                    }
        //                    return choice;
        //            }
        //        }
        //        return choice;
        //    }
        //    return -1;
        //}

        private static bool PeekSavefile(string save, int index, bool silently)
        {
            int displayRow = 0;
            int displayCol = 0;
            switch (index)
            {
                case 0:
                    displayRow = 9;
                    displayCol = 6;
                    break;

                case 1:
                    displayRow = 9;
                    displayCol = 46;
                    break;

                case 2:
                    displayRow = 31;
                    displayCol = 6;
                    break;

                case 3:
                    displayRow = 31;
                    displayCol = 46;
                    break;
            }
            FileInfo file = new FileInfo(save);
            if (!file.Exists)
            {
                if (!silently)
                {
                    saveGame.Gui.Print(Colour.BrightTurquoise, "<Empty>", displayRow, displayCol + 11);
                }
                return false;
            }
            SaveGame tempSaveGame;
            try
            {
                tempSaveGame = DeserializeFromSaveFolder<SaveGame>(save);
            }
            catch (Exception ex)
            {
                if (!silently)
                {
                    saveGame.Gui.Print(Colour.BrightRed, "<Unreadable>", displayRow, displayCol + 8);
                }
                return false;
            }
            if (silently)
            {
                return true;
            }
            bool tempDeath = tempSaveGame.Player == null;
            Colour color;
            int tempLev;
            int tempRace;
            int tempClass;
            Realm tempRealm;
            string tempName;
            if (tempDeath)
            {
                color = Colour.Grey;
                tempLev = tempSaveGame.ExPlayer.Level;
                tempRace = tempSaveGame.ExPlayer.RaceIndex;
                tempClass = tempSaveGame.ExPlayer.ProfessionIndex;
                tempRealm = tempSaveGame.ExPlayer.Realm1;
                tempName = tempSaveGame.ExPlayer.Name.Trim() + tempSaveGame.ExPlayer.Generation.ToRoman(true);
            }
            else
            {
                color = Colour.White;
                if (tempSaveGame.Player.IsWizard)
                {
                    color = Colour.Yellow;
                }
                tempLev = tempSaveGame.Player.Level;
                tempRace = tempSaveGame.Player.RaceIndex;
                tempClass = tempSaveGame.Player.ProfessionIndex;
                tempRealm = tempSaveGame.Player.Realm1;
                tempName = tempSaveGame.Player.Name.Trim() + tempSaveGame.Player.Generation.ToRoman(true);
            }
            saveGame.Gui.Print(color, tempName, displayRow, displayCol + 14 - (tempName.Length / 2));
            string tempchar = $"the level {tempLev}";
            saveGame.Gui.Print(color, tempchar, displayRow + 1, displayCol + 14 - (tempchar.Length / 2));
            tempchar = Race.RaceInfo[tempRace].Title;
            saveGame.Gui.Print(color, tempchar, displayRow + 2, displayCol + 14 - (tempchar.Length / 2));
            tempchar = Profession.ClassSubName(tempClass, tempRealm);
            saveGame.Gui.Print(color, tempchar, displayRow + 3, displayCol + 14 - (tempchar.Length / 2));
            if (tempDeath)
            {
                tempchar = "(deceased)";
                saveGame.Gui.Print(color, tempchar, displayRow + 4, displayCol + 14 - (tempchar.Length / 2));
            }
            else if (tempSaveGame.Player.IsWizard)
            {
                tempchar = "-=<WIZARD>=-";
                saveGame.Gui.Print(color, tempchar, displayRow + 4, displayCol + 14 - (tempchar.Length / 2));
            }
            return true;
        }

        private static void PrintOptionsScreen()
        {
            saveGame.Gui.Clear();
            saveGame.Gui.Print(Colour.Green, "Options", 1, 10);
            saveGame.Gui.Print(Colour.Green, "=======", 2, 10);
            saveGame.Gui.Print(Colour.Blue, "    Text font:", 4, 1);
            saveGame.Gui.Print(Colour.Blue, "   Text style:", 5, 1);
            saveGame.Gui.Print(Colour.Blue, "Display style:", 6, 1);
            saveGame.Gui.Print(Colour.Blue, "  Window size:", 7, 1);
            saveGame.Gui.Print(Colour.Blue, " Music volume:", 8, 1);
            saveGame.Gui.Print(Colour.Blue, " Sound volume:", 9, 1);

            saveGame.Gui.Print(Colour.Green, "Sample Text", 12, 8);
            saveGame.Gui.Print(Colour.Green, "===========", 13, 8);
            saveGame.Gui.Print(Colour.Red, "Red", 15, 1);
            saveGame.Gui.Print(Colour.BrightRed, "Bright Red", 15, 15);
            saveGame.Gui.Print(Colour.Orange, "Orange", 16, 1);
            saveGame.Gui.Print(Colour.BrightOrange, "Bright Orange", 16, 15);
            saveGame.Gui.Print(Colour.Yellow, "Yellow", 17, 1);
            saveGame.Gui.Print(Colour.BrightYellow, "Bright Yellow", 17, 15);
            saveGame.Gui.Print(Colour.Chartreuse, "Chartreuse", 18, 1);
            saveGame.Gui.Print(Colour.BrightChartreuse, "Bright Chartreuse", 18, 15);
            saveGame.Gui.Print(Colour.Green, "Green", 19, 1);
            saveGame.Gui.Print(Colour.BrightGreen, "Bright Green", 19, 15);
            saveGame.Gui.Print(Colour.Turquoise, "Turquoise", 20, 1);
            saveGame.Gui.Print(Colour.BrightTurquoise, "Bright Turquoise", 20, 15);
            saveGame.Gui.Print(Colour.Blue, "Blue", 21, 1);
            saveGame.Gui.Print(Colour.BrightBlue, "Bright Blue", 21, 15);
            saveGame.Gui.Print(Colour.Purple, "Purple", 22, 1);
            saveGame.Gui.Print(Colour.BrightPurple, "Bright Purple", 22, 15);
            saveGame.Gui.Print(Colour.Pink, "Pink", 23, 1);
            saveGame.Gui.Print(Colour.BrightPink, "Bright Pink", 23, 15);
            saveGame.Gui.Print(Colour.Brown, "Brown", 25, 1);
            saveGame.Gui.Print(Colour.BrightBrown, "Bright Brown", 25, 15);
            saveGame.Gui.Print(Colour.Beige, "Beige", 26, 1);
            saveGame.Gui.Print(Colour.BrightBeige, "Bright Beige", 26, 15);
            saveGame.Gui.Print(Colour.Black, "Black", 28, 1);
            saveGame.Gui.Print(Colour.Grey, "Grey", 29, 1);
            saveGame.Gui.Print(Colour.BrightGrey, "Bright Grey", 30, 1);
            saveGame.Gui.Print(Colour.White, "White", 31, 1);
            saveGame.Gui.Print(Colour.BrightWhite, "Bright White", 32, 1);
            saveGame.Gui.Print(Colour.Copper, "Copper", 28, 15);
            saveGame.Gui.Print(Colour.Silver, "Silver", 29, 15);
            saveGame.Gui.Print(Colour.Gold, "Gold", 30, 15);
            saveGame.Gui.Print(Colour.Diamond, "Diamond", 31, 15);
            saveGame.Gui.Print(Colour.Black, "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG", 35, 1);
            saveGame.Gui.Print(Colour.Black, "the quick brown fox jumps over the lazy dog", 36, 1);
            saveGame.Gui.Print(Colour.Black, "1234567890 !\"$%^&·*()_+-={}[]<>.,/?:@~;'#\\|", 37, 1);

            saveGame.Gui.Print(Colour.Green, "Sample Layout", 1, 58);
            saveGame.Gui.Print(Colour.Green, "=============", 2, 58);
            saveGame.Gui.Print(Colour.Grey, "                   # #       ", 4, 50);
            saveGame.Gui.Print(Colour.Grey, "            ########+########", 5, 50);
            saveGame.Gui.Print(Colour.Grey, "            #      + +       ", 6, 50);
            saveGame.Gui.Print(Colour.Grey, "            # ###############", 7, 50);
            saveGame.Gui.Print(Colour.Grey, "            # #              ", 8, 50);
            saveGame.Gui.Print(Colour.Grey, "      #######·########       ", 9, 50);
            saveGame.Gui.Print(Colour.Grey, "      #··············#       ", 10, 50);
            saveGame.Gui.Print(Colour.Grey, "      #·!·······@····#       ", 11, 50);
            saveGame.Gui.Print(Colour.Grey, "#######···o··········#       ", 12, 50);
            saveGame.Gui.Print(Colour.Grey, "··^·k·'··············#       ", 13, 50);
            saveGame.Gui.Print(Colour.Grey, "#######·oo······$····#       ", 14, 50);
            saveGame.Gui.Print(Colour.Grey, "      #··o···········#       ", 15, 50);
            saveGame.Gui.Print(Colour.Grey, "      #######c########       ", 16, 50);
            saveGame.Gui.Print(Colour.Grey, "            #·#              ", 17, 50);
            saveGame.Gui.Print(Colour.Grey, "            #·#######        ", 18, 50);
            saveGame.Gui.Print(Colour.Grey, "            #·······#        ", 19, 50);
            saveGame.Gui.Print(Colour.Grey, "            #######·#        ", 20, 50);
            saveGame.Gui.Print(Colour.Grey, "                  #'#########", 21, 50);
            saveGame.Gui.Print(Colour.Grey, "                  #·'········", 22, 50);
            saveGame.Gui.Print(Colour.Grey, "                  #'#########", 23, 50);
            saveGame.Gui.Print(Colour.Grey, "                  #·#        ", 24, 50);
            saveGame.Gui.Print(Colour.Grey, "      #############·#        ", 25, 50);
            saveGame.Gui.Print(Colour.Grey, "      #·············#        ", 26, 50);
            saveGame.Gui.Print(Colour.Grey, "      *·#############        ", 27, 50);
            saveGame.Gui.Print(Colour.Grey, "      #·# ################   ", 28, 50);
            saveGame.Gui.Print(Colour.Grey, "      #·###·····>········#   ", 29, 50);
            saveGame.Gui.Print(Colour.Grey, "      #···'··········^···#   ", 30, 50);
            saveGame.Gui.Print(Colour.Grey, "      #####·······|······#   ", 31, 50);
            saveGame.Gui.Print(Colour.Grey, "          #·~············#   ", 32, 50);
            saveGame.Gui.Print(Colour.Grey, "          #··············#   ", 33, 50);
            saveGame.Gui.Print(Colour.Grey, "          ######'############", 34, 50);
            saveGame.Gui.Print(Colour.Grey, "               #·##··········", 35, 50);
            saveGame.Gui.Print(Colour.Grey, "               #····#########", 36, 50);
            saveGame.Gui.Print(Colour.Grey, "               ######        ", 37, 50);

            saveGame.Gui.Print(Colour.Brown, "+", 5, 70);
            saveGame.Gui.Print(Colour.Brown, "+ +", 6, 69);
            saveGame.Gui.Print(Colour.White, "#######·########       ", 9, 56);
            saveGame.Gui.Print(Colour.White, "#··············#       ", 10, 56);
            saveGame.Gui.Print(Colour.White, "#·!·······@····#       ", 11, 56);
            saveGame.Gui.Print(Colour.White, "#···o··········#       ", 12, 56);
            saveGame.Gui.Print(Colour.White, "^·k·'··············#       ", 13, 52);
            saveGame.Gui.Print(Colour.White, "#######·oo······$····#       ", 14, 50);
            saveGame.Gui.Print(Colour.White, "      #··o···········#       ", 15, 50);
            saveGame.Gui.Print(Colour.White, "      #######c########       ", 16, 50);
            saveGame.Gui.Print(Colour.BrightYellow, "···", 10, 65);
            saveGame.Gui.Print(Colour.BrightYellow, "·@·", 11, 65);
            saveGame.Gui.Print(Colour.BrightYellow, "···", 12, 65);
            saveGame.Gui.Print(Colour.BrightWhite, "@", 11, 66);
            saveGame.Gui.Print(Colour.Orange, "!", 11, 58);
            saveGame.Gui.Print(Colour.BrightGreen, "o", 12, 60);
            saveGame.Gui.Print(Colour.Red, "^", 13, 52);
            saveGame.Gui.Print(Colour.Green, "k", 13, 54);
            saveGame.Gui.Print(Colour.BrightBrown, "'", 13, 56);
            saveGame.Gui.Print(Colour.Black, "oo", 14, 58);
            saveGame.Gui.Print(Colour.Copper, "$", 14, 66);
            saveGame.Gui.Print(Colour.Black, "o", 15, 59);
            saveGame.Gui.Print(Colour.BrightBlue, "c", 16, 63);
            saveGame.Gui.Print(Colour.White, "#", 17, 62);
            saveGame.Gui.Print(Colour.Black, "·", 17, 63);
            saveGame.Gui.Print(Colour.Black, "·", 18, 63);
            saveGame.Gui.Print(Colour.Black, "·······", 19, 63);
            saveGame.Gui.Print(Colour.Black, "·", 20, 69);
            saveGame.Gui.Print(Colour.Brown, "'", 21, 69);
            saveGame.Gui.Print(Colour.Black, "·'········", 22, 69);
            saveGame.Gui.Print(Colour.Brown, "'", 22, 70);
            saveGame.Gui.Print(Colour.Brown, "'", 23, 69);
            saveGame.Gui.Print(Colour.Black, "·", 24, 69);
            saveGame.Gui.Print(Colour.Black, "·", 25, 69);
            saveGame.Gui.Print(Colour.Black, "·············", 26, 57);
            saveGame.Gui.Print(Colour.Red, "*", 27, 56);
            saveGame.Gui.Print(Colour.Black, "·", 27, 57);
            saveGame.Gui.Print(Colour.Black, "·", 28, 57);
            saveGame.Gui.Print(Colour.Black, "·", 29, 57);
            saveGame.Gui.Print(Colour.Brown, ">", 29, 66);
            saveGame.Gui.Print(Colour.Black, "···", 30, 57);
            saveGame.Gui.Print(Colour.Brown, "'", 30, 60);
            saveGame.Gui.Print(Colour.Purple, "^", 30, 71);
            saveGame.Gui.Print(Colour.BrightWhite, "|", 31, 68);
            saveGame.Gui.Print(Colour.Beige, "~", 32, 62);
            saveGame.Gui.Print(Colour.Brown, "'", 34, 66);
            saveGame.Gui.Print(Colour.Black, "·", 35, 66);
            saveGame.Gui.Print(Colour.Black, "··········", 35, 69);
            saveGame.Gui.Print(Colour.Black, "····", 36, 66);
        }

        //private static void ShowMainMenu()
        //{
        //    saveGame.Gui.CursorVisible = false;
        //    saveGame.Gui.Terminal.PlayMusic(MusicTrack.Menu);
        //    while (true)
        //    {
        //        saveGame.Gui.SetBackground(BackgroundImage.Menu);
        //        saveGame.Gui.Clear();
        //        saveGame.Gui.Print(Colour.BrightRed, $"© 1997-{Constants.CompileTime:yyyy} Dean Anderson".PadCenter(80), 41, 0);
        //        saveGame.Gui.Print(Colour.BrightRed, "See Cthangpedia for license and credits.".PadCenter(80), 42, 0);
        //        saveGame.Gui.Print(Colour.BrightRed, $"{Constants.VersionStamp} ({Constants.CompileTime})".PadCenter(80), 43, 0);
        //        // Check to see if we have a savefile that we can continue
        //        var saveIndex = _settings.LastProfileUsed;
        //        var canContinue = PeekSavefile(_saveSlot[saveIndex], 0, true); ;
        //        var profileChoice = -1;
        //        if (canContinue)
        //        {
        //            var list = new List<string> { "Continue Game", "New Game", "Load Game", "High Scores", "Cthangpedia", "Quit to Desktop" };
        //            var menu = new PopupMenu(list);
        //            var menuChoice = menu.Show();
        //            {
        //                switch (menuChoice)
        //                {
        //                    case 0:
        //                        // Continue Game
        //                        ActiveSaveSlot = _saveSlot[saveIndex];
        //                        Run(saveGame);
        //                        return;

        //                    case 1:
        //                        // New Game
        //                        profileChoice = NewGame(saveIndex);
        //                        if (profileChoice >= 0)
        //                        {
        //                            _settings.LastProfileUsed = profileChoice;
        //                            ActiveSaveSlot = _saveSlot[profileChoice];
        //                            Run(saveGame);
        //                            return;
        //                        }
        //                        break;

        //                    case 2:
        //                        // Load Game
        //                        profileChoice = LoadGame(saveIndex);
        //                        if (profileChoice >= 0)
        //                        {
        //                            _settings.LastProfileUsed = profileChoice;
        //                            ActiveSaveSlot = _saveSlot[profileChoice];
        //                            Run(saveGame);
        //                            return;
        //                        }
        //                        break;

        //                    case 3:
        //                        // High Scores
        //                        HiScores.DisplayScores();
        //                        break;

        //                    case 4:
        //                        // Cthangpedia
        //                        saveGame.Gui.ShowManual();
        //                        break;

        //                    case -1:
        //                    case 5:
        //                        // Exit to Desktop
        //                        ExitToDesktop = true;
        //                        return;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            var list = new List<string> { "New Game", "Load Game", "High Scores", "Cthangpedia", "Quit to Desktop" };
        //            var menu = new PopupMenu(list);
        //            var menuChoice = menu.Show();
        //            {
        //                switch (menuChoice)
        //                {
        //                    case 0:
        //                        // New Game
        //                        profileChoice = NewGame(saveIndex);
        //                        if (profileChoice >= 0)
        //                        {
        //                            _settings.LastProfileUsed = profileChoice;
        //                            ActiveSaveSlot = _saveSlot[profileChoice];
        //                            Run(saveGame);
        //                            return;
        //                        }
        //                        break;

        //                    case 1:
        //                        // Load Game
        //                        profileChoice = LoadGame(saveIndex);
        //                        if (profileChoice >= 0)
        //                        {
        //                            _settings.LastProfileUsed = profileChoice;
        //                            ActiveSaveSlot = _saveSlot[profileChoice];
        //                            Run(saveGame);
        //                            return;
        //                        }
        //                        break;

        //                    case 2:
        //                        // High Scores
        //                        HiScores.DisplayScores();
        //                        break;

        //                    case 3:
        //                        // Cthangpedia
        //                        saveGame.Gui.ShowManual();
        //                        break;

        //                    case -1:
        //                    case 4:
        //                        // Exit to Desktop
        //                        ExitToDesktop = true;
        //                        return;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}