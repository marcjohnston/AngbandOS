// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class GoUpScript : Script
    {
        private GoUpScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            // We need to actually be on an up staircase
            GridTile tile = SaveGame.Level.Grid[SaveGame.Player.MapY][SaveGame.Player.MapX];
            if (tile.FeatureType.Name != "UpStair")
            {
                SaveGame.MsgPrint("I see no up staircase here.");
                SaveGame.EnergyUse = 0;
                return false;
            }
            // Use no energy, so monsters in the new level don't get to go first
            SaveGame.EnergyUse = 0;
            // If we're outside then we must be entering a tower
            if (SaveGame.CurrentDepth == 0)
            {
                SaveGame.CurDungeon = SaveGame.Wilderness[SaveGame.Player.WildernessY][SaveGame.Player.WildernessX].Dungeon;
                SaveGame.MsgPrint($"You enter {SaveGame.CurDungeon.Name}");
            }
            else
            {
                SaveGame.MsgPrint("You enter a maze of up staircases.");
            }
            // Autosave, just in case
            SaveGame.DoCmdSaveGame(true);
            // In a tower, going up increases our level number
            if (SaveGame.CurDungeon.Tower)
            {
                int stairLength = Program.Rng.DieRoll(5);
                if (stairLength > SaveGame.CurrentDepth)
                {
                    stairLength = 1;
                }
                // Make sure we don't go past a quest level
                for (int i = 0; i < stairLength; i++)
                {
                    SaveGame.CurrentDepth++;
                    if (SaveGame.IsQuest(SaveGame.CurrentDepth))
                    {
                        break;
                    }
                }
                // Make sure we don't go deeper than the dungeon depth
                if (SaveGame.CurrentDepth > SaveGame.CurDungeon.MaxLevel)
                {
                    SaveGame.CurrentDepth = SaveGame.CurDungeon.MaxLevel;
                }
            }
            else
            {
                // We're not in a tower, so going up decreases our level number
                int j = Program.Rng.DieRoll(SaveGame.OneInChanceUpStairsReturnsToTownLevel);
                if (j > SaveGame.CurrentDepth)
                {
                    j = 1;
                }
                SaveGame.CurrentDepth -= j;
                if (SaveGame.CurrentDepth < 0)
                {
                    SaveGame.CurrentDepth = 0;
                }
                if (SaveGame.CurrentDepth == 0)
                {
                    SaveGame.Player.WildernessX = SaveGame.CurDungeon.X;
                    SaveGame.Player.WildernessY = SaveGame.CurDungeon.Y;
                    SaveGame.CameFrom = LevelStart.StartStairs;
                }
            }
            SaveGame.NewLevelFlag = true;
            SaveGame.CreateDownStair = true;
            return false;
        }
    }
}
