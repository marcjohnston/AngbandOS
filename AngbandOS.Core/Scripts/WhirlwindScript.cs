// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WhirlwindScript : Script, IActivateItemScript
{
    private WhirlwindScript(Game game) : base(game) { }

    public UsedResult ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        for (int direction = 0; direction <= 9; direction++)
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[direction];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[direction];
            GridTile cPtr = Game.Map.Grid[y][x];
            Monster mPtr = Game.Monsters[cPtr.MonsterIndex];
            if (cPtr.MonsterIndex != 0 && (mPtr.IsVisible || Game.GridPassable(y, x)))
            {
                Game.PlayerAttackMonster(y, x);
            }
        }
        return new UsedResult(true);
    }
}
