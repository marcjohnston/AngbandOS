// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Light the area.
/// </summary>
[Serializable]
internal class LightActivation : Activation
{
    private LightActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} swells with clear light...";

    protected override bool OnActivate(Item item)
    {
        Game.LightArea(Game.DiceRoll(2, 15), 3);
        return true;
    }

    protected override string RechargeTimeRollExpression => "1d10+10";

    public override int Value => 150;

    public override string Name => "Light area (2d15)";

    public override string Frequency => "10+d10";
}
