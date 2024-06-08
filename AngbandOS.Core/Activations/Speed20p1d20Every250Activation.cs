// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us temporary haste.
/// </summary>
[Serializable]
internal class Speed20p1d20Every250Activation : Activation
{
    private Speed20p1d20Every250Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows bright green...";

    protected override bool OnActivate(Item item)
    {
        if (Game.HasteTimer.Value == 0)
        {
            Game.HasteTimer.SetTimer(Game.DieRoll(20) + 20);
        }
        else
        {
            Game.HasteTimer.AddTimer(5);
        }
        return true;
    }

    public override int RechargeTime() => 250;

    public override int Value => 15000;

    public override string Name => "Haste self (20+d20)";

    public override string Frequency => "250";
}
