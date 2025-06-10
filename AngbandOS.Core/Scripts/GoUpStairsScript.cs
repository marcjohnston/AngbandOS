// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GoUpStairsScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private GoUpStairsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the go up stairs script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the go up stairs script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // We need to actually be on an up staircase
        GridTile tile = Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue];
        if (!tile.FeatureType.IsUpStaircase)
        {
            Game.MsgPrint("I see no up staircase here.");
            Game.EnergyUse = 0;
            return;
        }
        // Use no energy, so monsters in the new level don't get to go first
        Game.EnergyUse = 0;
        // If we're outside then we must be entering a tower
        if (Game.CurrentDepth == 0)
        {
            Game.CurDungeon = Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon;
            Game.MsgPrint($"You enter {Game.CurDungeon.Name}");
        }
        else
        {
            Game.MsgPrint("You enter a maze of up staircases.");
        }
        // Autosave, just in case
        Game.DoCmdSaveGame(true);
        // In a tower, going up increases our level number
        if (Game.CurDungeon.Tower)
        {
            int stairLength = Game.DieRoll(5);
            if (stairLength > Game.CurrentDepth)
            {
                stairLength = 1;
            }
            // Make sure we don't go past a quest level
            for (int i = 0; i < stairLength; i++)
            {
                Game.CurrentDepth++;
                if (Game.IsQuest(Game.CurrentDepth))
                {
                    break;
                }
            }
            // Make sure we don't go deeper than the dungeon depth
            if (Game.CurrentDepth > Game.CurDungeon.MaxLevel)
            {
                Game.CurrentDepth = Game.CurDungeon.MaxLevel;
            }
        }
        else
        {
            // We're not in a tower, so going up decreases our level number
            int j = Game.DieRoll(Game.OneInChanceUpStairsReturnsToTownLevel);
            if (j > Game.CurrentDepth)
            {
                j = 1;
            }
            Game.CurrentDepth -= j;
            if (Game.CurrentDepth < 0)
            {
                Game.CurrentDepth = 0;
            }
            if (Game.CurrentDepth == 0)
            {
                Game.WildernessX = Game.CurDungeon.X;
                Game.WildernessY = Game.CurDungeon.Y;
                Game.CameFrom = LevelStartEnum.StartStairs;
            }
        }
        Game.NewLevelFlag = true;
        Game.CreateDownStair = true;
    }
}
