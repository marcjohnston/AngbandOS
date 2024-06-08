// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Make a physical attack against each adjacent monster.
/// </summary>
[Serializable]
internal class WhirlwindActivation : Activation
{
    private WhirlwindActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "";  // There is no message for this artifact power.

    public override int RechargeTime() => 250;

    protected override bool OnActivate(Item item)
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
        return true;
    }

    public override int Value => 7500;

    public override string Name => "Whirlwind attack";

    public override string Frequency => "250";
}
