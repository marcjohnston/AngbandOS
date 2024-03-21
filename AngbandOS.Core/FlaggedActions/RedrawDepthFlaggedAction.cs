// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawDepthFlaggedAction : FlaggedAction
{
    private const int ColDepth = 69;
    private const int RowDepth = 44;
    private RedrawDepthFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        string depths;
        if (Game.CurrentDepth == 0)
        {
            if (Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon != null)
            {
                depths = Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon.Shortname;
                Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon.Visited = true;
            }
            else
            {
                depths = $"Wild ({Game.WildernessX},{Game.WildernessY})";
            }
        }
        else
        {
            depths = $"lvl {Game.CurrentDepth}+{Game.DungeonDifficulty}";
            Game.CurDungeon.KnownOffset = true;
            if (Game.CurrentDepth == Game.CurDungeon.MaxLevel)
            {
                Game.CurDungeon.KnownDepth = true;
            }
        }
        Game.Screen.PrintLine(depths.PadLeft(9), RowDepth, ColDepth);
    }
}
