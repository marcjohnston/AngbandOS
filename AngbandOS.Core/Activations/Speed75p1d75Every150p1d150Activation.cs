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
internal class Speed75p1d75Every150p1d150Activation : Activation
{
    private Speed75p1d75Every150p1d150Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "The {0} glows brightly...";

    protected override bool OnActivate(Item item)
    {
        if (Game.HasteTimer.Value == 0)
        {
            Game.HasteTimer.SetTimer(Game.DieRoll(75) + 75);
        }
        else
        {
            Game.HasteTimer.AddTimer(5);
        }
        return true;
    }

    protected override string RechargeTimeRollExpression => "1d150+150";

    public override int Value => 20000;

    public override string Name => "Haste self (75+d75)";

    public override string Frequency => "200";
}
