// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us temporary resistance to the basic elements.
/// </summary>
[Serializable]
internal class ResistAll20p1d20Activation : Activation
{
    private ResistAll20p1d20Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows many colors...";

    protected override bool OnActivate(Item item)
    {
        Game.AcidResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.LightningResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.FireResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.ColdResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.PoisonResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        return true;
    }

    protected override string RechargeTimeRollExpression => "111";

    public override int Value => 5000;

    public override string Name => "Resist elements (40+d40)";

}
