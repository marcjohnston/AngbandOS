// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Shoot a fire bolt that does 9d8 damage.
/// </summary>
[Serializable]
internal class FireBolt9d8Every8p1d8DirectionalActivation : DirectionalActivation
{
    private FireBolt9d8Every8p1d8DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} is covered in fire...";

    protected override string RechargeTimeRollExpression => "1d8+8";

    protected override string DirectionalActivationCancellableScriptBindingKey => nameof(Fire9d8ProjectileScript);

    public override int Value => 250;

    public override string Name => "Fire bolt (9d8)";

}
