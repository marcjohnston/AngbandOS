
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrDepthRedrawAction : RedrawAction
    {
        private const int ColDepth = 69;
        private const int RowDepth = 44;
        public PrDepthRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
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
            SaveGame.PrintLine(depths.PadLeft(9), RowDepth, ColDepth);
        }
    }
}
