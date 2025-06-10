
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

[Serializable]
internal class DepthFunction : StringFunction
{
    private DepthFunction(Game game) : base(game) { } // This object is a singleton.
    public override string StringValue
    {
        get
        {
            string depth;
            if (Game.CurrentDepth == 0)
            {
                if (Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon != null)
                {
                    depth = Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon.Shortname;
                    Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon.Visited = true;
                }
                else
                {
                    depth = $"Wild ({Game.WildernessX},{Game.WildernessY})";
                }
            }
            else
            {
                depth = $"lvl {Game.CurrentDepth}+{Game.DungeonDifficulty}";
                Game.CurDungeon.KnownOffset = true;
                if (Game.CurrentDepth == Game.CurDungeon.MaxLevel)
                {
                    Game.CurDungeon.KnownDepth = true;
                }
            }
            return depth;
        }
    }
}
