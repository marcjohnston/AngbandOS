// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.Enumerations;
using Cthangband.StaticData;
using Cthangband.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cthangband
{
    [Serializable]
    internal class Profile
    {
        public FixedArtifactArray FixedArtifacts;
        public ItemTypeArray ItemTypes;
        public MonsterRaceArray MonsterRaces;
        public RareItemTypeArray RareItemTypes;
        public VaultTypeArray VaultTypes;


        public static Profile Instance
        {
            get; private set;
        }

        public SaveGame Game
        {
            get; private set;
        }

        public static void LoadOrCreate(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                Instance = Program.DeserializeFromSaveFolder<Profile>(fileName);
            }
            else
            {
                Instance = new Profile();
                Instance.Initialise();
            }
            SaveGame.Instance = Instance.Game;
        }


        public void Run()
        {
            // Create a new game if necessary
            if (Game == null)
            {
                SaveGame game = new SaveGame(this);
                game.Initialise();
                Game = game;
            }
            Game.MsgFlag = false;
            Game.MsgPrint(null);
            Game.MsgFlag = false;

            // Set a globally accessible reference to our game
            SaveGame.Instance = Game;
            // And play it!
            Game.Play();
            // Remove the global reference
            SaveGame.Instance = null;
        }

        private void Initialise()
        {
            GlobalData.PopulateNewProfile(this);
        }

    }
}