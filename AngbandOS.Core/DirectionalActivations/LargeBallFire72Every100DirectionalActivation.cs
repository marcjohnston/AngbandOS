// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class LargeBallFire72Every100DirectionalActivation : DirectionalActivation
{
    private LargeBallFire72Every100DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} rages in fire...";

    protected override string RechargeTimeRollExpression => "100";

    protected override string DirectionalActivationCancellableScriptBindingKey => nameof(Fire72r3ProjectileScript);

    public override int Value => 6000;

    public override string Name => "Large fire ball (72)";

}
