// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Drain up to 50 life from an opponent, and give it to the player.
/// </summary>
[Serializable]
internal class Vampire1DirectionalActivation : DirectionalActivation
{
    private Vampire1DirectionalActivation(Game game) : base(game) { }
    
    protected override string RechargeTimeRollExpression => "400";

    protected override bool Activate(int direction)
    {
        for (int i = 0; i < 3; i++)
        {
            if (Game.DrainLife(direction, 50))
            {
                Game.RestoreHealth(50);
            }
        }
        return true;
    }

    public override int Value => 1000;

    public override string Name => "Vampiric drain 3x (50)";

}
