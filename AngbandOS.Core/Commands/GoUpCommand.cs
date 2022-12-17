using AngbandOS.Enumerations;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Go up a staircase
    /// </summary>
    [Serializable]
    internal class GoUpCommand : ICommand
    {
        private GoUpCommand() { } // This object is a singleton.

        public char Key => '<';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            // We need to actually be on an up staircase
            GridTile tile = saveGame.Level.Grid[saveGame.Player.MapY][saveGame.Player.MapX];
            if (tile.FeatureType.Name != "UpStair")
            {
                saveGame.MsgPrint("I see no up staircase here.");
                saveGame.EnergyUse = 0;
                return;
            }
            // Use no energy, so monsters in the new level don't get to go first
            saveGame.EnergyUse = 0;
            // If we're outside then we must be entering a tower
            if (saveGame.CurrentDepth == 0)
            {
                saveGame.CurDungeon = saveGame.Wilderness[saveGame.Player.WildernessY][saveGame.Player.WildernessX].Dungeon;
                saveGame.MsgPrint($"You enter {saveGame.CurDungeon.Name}");
            }
            else
            {
                saveGame.MsgPrint("You enter a maze of up staircases.");
            }
            // Autosave, just in case
            saveGame.DoCmdSaveGame(true);
            // In a tower, going up increases our level number
            if (saveGame.CurDungeon.Tower)
            {
                int stairLength = Program.Rng.DieRoll(5);
                if (stairLength > saveGame.CurrentDepth)
                {
                    stairLength = 1;
                }
                // Make sure we don't go past a quest level
                for (int i = 0; i < stairLength; i++)
                {
                    saveGame.CurrentDepth++;
                    if (saveGame.Quests.IsQuest(saveGame.CurrentDepth))
                    {
                        break;
                    }
                }
                // Make sure we don't go deeper than the dungeon depth
                if (saveGame.CurrentDepth > saveGame.CurDungeon.MaxLevel)
                {
                    saveGame.CurrentDepth = saveGame.CurDungeon.MaxLevel;
                }
            }
            else
            {
                // We're not in a tower, so going up decreases our level number
                int j = Program.Rng.DieRoll(5);
                if (j > saveGame.CurrentDepth)
                {
                    j = 1;
                }
                saveGame.CurrentDepth -= j;
                if (saveGame.CurrentDepth < 0)
                {
                    saveGame.CurrentDepth = 0;
                }
                if (saveGame.CurrentDepth == 0)
                {
                    saveGame.Player.WildernessX = saveGame.CurDungeon.X;
                    saveGame.Player.WildernessY = saveGame.CurDungeon.Y;
                    saveGame.CameFrom = LevelStart.StartStairs;
                }
            }
            saveGame.NewLevelFlag = true;
            saveGame.CreateDownStair = true;
        }
    }
}
