
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawDepthFlaggedAction : FlaggedAction
{
    private const int ColDepth = 69;
    private const int RowDepth = 44;
    public RedrawDepthFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        string depths;
        if (SaveGame.CurrentDepth == 0)
        {
            if (SaveGame.Wilderness[SaveGame.Player.WildernessY][SaveGame.Player.WildernessX].Dungeon != null)
            {
                depths = SaveGame.Wilderness[SaveGame.Player.WildernessY][SaveGame.Player.WildernessX].Dungeon.Shortname;
                SaveGame.Wilderness[SaveGame.Player.WildernessY][SaveGame.Player.WildernessX].Dungeon.Visited = true;
            }
            else
            {
                depths = $"Wild ({SaveGame.Player.WildernessX},{SaveGame.Player.WildernessY})";
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
