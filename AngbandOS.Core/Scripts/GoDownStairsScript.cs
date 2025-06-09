// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GoDownStairsScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private GoDownStairsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the go down stairs script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the go down stairs script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool isTrapDoor = false;
        GridTile tile = Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue];
        if (tile.FeatureType.IsTrapDoor)
        {
            isTrapDoor = true;
        }
        // Need to be on a staircase or trapdoor
        if (!tile.FeatureType.IsDownStaircase && !isTrapDoor)
        {
            Game.MsgPrint("I see no down staircase here.");
            Game.EnergyUse = 0;
            return;
        }
        // Going onto a new level takes no energy, so the monsters on that level don't get to
        // move before us
        Game.EnergyUse = 0;
        if (isTrapDoor)
        {
            Game.MsgPrint("You deliberately jump through the trap door.");
        }
        else
        {
            // If we're on the surface, enter the relevant dungeon
            if (Game.CurrentDepth == 0)
            {
                Game.CurDungeon = Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon;
                Game.MsgPrint($"You enter {Game.CurDungeon.Name}");
            }
            else
            {
                Game.MsgPrint("You enter a maze of down staircases.");
            }
            // Save the game, just in case
            Game.DoCmdSaveGame(true);
        }
        // If we're in a tower, a down staircase reduces our level number
        if (Game.CurDungeon.Tower)
        {
            int stairLength = Game.DieRoll(5);
            if (stairLength > Game.CurrentDepth)
            {
                stairLength = 1;
            }
            Game.CurrentDepth -= stairLength;
            if (Game.CurrentDepth < 0)
            {
                Game.CurrentDepth = 0;
            }
            // If we left the dungeon, remember where we are
            if (Game.CurrentDepth == 0)
            {
                Game.WildernessX = Game.CurDungeon.X;
                Game.WildernessY = Game.CurDungeon.Y;
                Game.CameFrom = LevelStartEnum.StartStairs;
            }
        }
        else
        {
            // We're not in a tower, so a down staircase increases our level number
            int stairLength = Game.DieRoll(5);
            if (stairLength > Game.CurrentDepth)
            {
                stairLength = 1;
            }
            // Check if we're about to go past a quest level
            for (int i = 0; i < stairLength; i++)
            {
                Game.CurrentDepth++;
                if (Game.IsQuest(Game.CurrentDepth))
                {
                    // Stop on the quest level
                    break;
                }
            }
            // Don't go past the max dungeon level
            if (Game.CurrentDepth > Game.CurDungeon.MaxLevel)
            {
                Game.CurrentDepth = Game.CurDungeon.MaxLevel;
            }
            // From the surface we always go to the first level
            if (Game.CurrentDepth == 0)
            {
                Game.CurrentDepth++;
            }
        }
        // We need a new level
        Game.NewLevelFlag = true;
        if (!isTrapDoor)
        {
            // Create an up staircase if we went down a staircase
            Game.CreateUpStair = true;
        }
    }
}
