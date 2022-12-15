using AngbandOS.Enumerations;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Use a down staircase or trapdoor
    /// </summary>
    [Serializable]
    internal class GoDownCommand : ICommand
    {
        public char Key => '>';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            bool isTrapDoor = false;
            GridTile tile = saveGame.Level.Grid[saveGame.Player.MapY][saveGame.Player.MapX];
            if (tile.FeatureType.Category == FloorTileTypeCategory.TrapDoor)
            {
                isTrapDoor = true;
            }
            // Need to be on a staircase or trapdoor
            if (tile.FeatureType.Name != "DownStair" && !isTrapDoor)
            {
                saveGame.MsgPrint("I see no down staircase here.");
                saveGame.EnergyUse = 0;
                return;
            }
            // Going onto a new level takes no energy, so the monsters on that level don't get to
            // move before us
            saveGame.EnergyUse = 0;
            if (isTrapDoor)
            {
                saveGame.MsgPrint("You deliberately jump through the trap door.");
            }
            else
            {
                // If we're on the surface, enter the relevant dungeon
                if (saveGame.CurrentDepth == 0)
                {
                    saveGame.CurDungeon = saveGame.Wilderness[saveGame.Player.WildernessY][saveGame.Player.WildernessX].Dungeon;
                    saveGame.MsgPrint($"You enter {saveGame.CurDungeon.Name}");
                }
                else
                {
                    saveGame.MsgPrint("You enter a maze of down staircases.");
                }
                // Save the game, just in case
                saveGame.DoCmdSaveGame(true);
            }
            // If we're in a tower, a down staircase reduces our level number
            if (saveGame.CurDungeon.Tower)
            {
                int stairLength = Program.Rng.DieRoll(5);
                if (stairLength > saveGame.CurrentDepth)
                {
                    stairLength = 1;
                }
                saveGame.CurrentDepth -= stairLength;
                if (saveGame.CurrentDepth < 0)
                {
                    saveGame.CurrentDepth = 0;
                }
                // If we left the dungeon, remember where we are
                if (saveGame.CurrentDepth == 0)
                {
                    saveGame.Player.WildernessX = saveGame.CurDungeon.X;
                    saveGame.Player.WildernessY = saveGame.CurDungeon.Y;
                    saveGame.CameFrom = LevelStart.StartStairs;
                }
            }
            else
            {
                // We're not in a tower, so a down staircase increases our level number
                int stairLength = Program.Rng.DieRoll(5);
                if (stairLength > saveGame.CurrentDepth)
                {
                    stairLength = 1;
                }
                // Check if we're about to go past a quest level
                for (int i = 0; i < stairLength; i++)
                {
                    saveGame.CurrentDepth++;
                    if (saveGame.Quests.IsQuest(saveGame.CurrentDepth))
                    {
                        // Stop on the quest level
                        break;
                    }
                }
                // Don't go past the max dungeon level
                if (saveGame.CurrentDepth > saveGame.CurDungeon.MaxLevel)
                {
                    saveGame.CurrentDepth = saveGame.CurDungeon.MaxLevel;
                }
                // From the surface we always go to the first level
                if (saveGame.CurrentDepth == 0)
                {
                    saveGame.CurrentDepth++;
                }
            }
            // We need a new level
            saveGame.NewLevelFlag = true;
            if (!isTrapDoor)
            {
                // Create an up staircase if we went down a staircase
                saveGame.CreateUpStair = true;
            }
        }
    }
}
