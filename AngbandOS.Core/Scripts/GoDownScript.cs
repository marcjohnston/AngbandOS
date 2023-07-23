// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GoDownScript : Script
{
    private GoDownScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        bool isTrapDoor = false;
        GridTile tile = SaveGame.Grid[SaveGame.MapY][SaveGame.MapX];
        if (tile.FeatureType.IsTrapDoor)
        {
            isTrapDoor = true;
        }
        // Need to be on a staircase or trapdoor
        if (tile.FeatureType.Name != "DownStair" && !isTrapDoor)
        {
            SaveGame.MsgPrint("I see no down staircase here.");
            SaveGame.EnergyUse = 0;
            return false;
        }
        // Going onto a new level takes no energy, so the monsters on that level don't get to
        // move before us
        SaveGame.EnergyUse = 0;
        if (isTrapDoor)
        {
            SaveGame.MsgPrint("You deliberately jump through the trap door.");
        }
        else
        {
            // If we're on the surface, enter the relevant dungeon
            if (SaveGame.CurrentDepth == 0)
            {
                SaveGame.CurDungeon = SaveGame.Wilderness[SaveGame.WildernessY][SaveGame.WildernessX].Dungeon;
                SaveGame.MsgPrint($"You enter {SaveGame.CurDungeon.Name}");
            }
            else
            {
                SaveGame.MsgPrint("You enter a maze of down staircases.");
            }
            // Save the game, just in case
            SaveGame.DoCmdSaveGame(true);
        }
        // If we're in a tower, a down staircase reduces our level number
        if (SaveGame.CurDungeon.Tower)
        {
            int stairLength = Program.Rng.DieRoll(5);
            if (stairLength > SaveGame.CurrentDepth)
            {
                stairLength = 1;
            }
            SaveGame.CurrentDepth -= stairLength;
            if (SaveGame.CurrentDepth < 0)
            {
                SaveGame.CurrentDepth = 0;
            }
            // If we left the dungeon, remember where we are
            if (SaveGame.CurrentDepth == 0)
            {
                SaveGame.WildernessX = SaveGame.CurDungeon.X;
                SaveGame.WildernessY = SaveGame.CurDungeon.Y;
                SaveGame.CameFrom = LevelStart.StartStairs;
            }
        }
        else
        {
            // We're not in a tower, so a down staircase increases our level number
            int stairLength = Program.Rng.DieRoll(5);
            if (stairLength > SaveGame.CurrentDepth)
            {
                stairLength = 1;
            }
            // Check if we're about to go past a quest level
            for (int i = 0; i < stairLength; i++)
            {
                SaveGame.CurrentDepth++;
                if (SaveGame.IsQuest(SaveGame.CurrentDepth))
                {
                    // Stop on the quest level
                    break;
                }
            }
            // Don't go past the max dungeon level
            if (SaveGame.CurrentDepth > SaveGame.CurDungeon.MaxLevel)
            {
                SaveGame.CurrentDepth = SaveGame.CurDungeon.MaxLevel;
            }
            // From the surface we always go to the first level
            if (SaveGame.CurrentDepth == 0)
            {
                SaveGame.CurrentDepth++;
            }
        }
        // We need a new level
        SaveGame.NewLevelFlag = true;
        if (!isTrapDoor)
        {
            // Create an up staircase if we went down a staircase
            SaveGame.CreateUpStair = true;
        }
        return false;
    }
}
