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
    private RedrawDepthFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        string depths;
        if (SaveGame.CurrentDepth == 0)
        {
            if (SaveGame.Wilderness[SaveGame.WildernessY][SaveGame.WildernessX].Dungeon != null)
            {
                depths = SaveGame.Wilderness[SaveGame.WildernessY][SaveGame.WildernessX].Dungeon.Shortname;
                SaveGame.Wilderness[SaveGame.WildernessY][SaveGame.WildernessX].Dungeon.Visited = true;
            }
            else
            {
                depths = $"Wild ({SaveGame.WildernessX},{SaveGame.WildernessY})";
            }
        }
        else
        {
            depths = $"lvl {SaveGame.CurrentDepth}+{SaveGame.DungeonDifficulty}";
            SaveGame.CurDungeon.KnownOffset = true;
            if (SaveGame.CurrentDepth == SaveGame.CurDungeon.MaxLevel)
            {
                SaveGame.CurDungeon.KnownDepth = true;
            }
        }
        SaveGame.Screen.PrintLine(depths.PadLeft(9), RowDepth, ColDepth);
    }
}
