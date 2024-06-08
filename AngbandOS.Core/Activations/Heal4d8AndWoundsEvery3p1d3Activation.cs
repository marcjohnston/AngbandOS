// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Heal 4d8 health and reduce bleeding.
/// </summary>
[Serializable]
internal class Heal4d8AndWoundsEvery3p1d3Activation : Activation
{
    private Heal4d8AndWoundsEvery3p1d3Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} radiates deep purple...";

    protected override bool OnActivate(Item item)
    {
        Game.RestoreHealth(Game.DiceRoll(4, 8));
        Game.BleedingTimer.SetTimer((Game.BleedingTimer.Value / 2) - 50);
        return true;
    }

    protected override string RechargeTimeRollExpression => "1d3+3";

    public override int Value => 750;

    public override string Name => "Heal 4d8 & wounds";

    public override string Frequency => "3+d3";
}
