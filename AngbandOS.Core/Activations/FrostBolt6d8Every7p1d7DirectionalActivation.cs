// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Shoot a frost bolt that does 6d8 damage.
/// </summary>
[Serializable]
internal class FrostBolt6d8Every7p1d7DirectionalActivation : Activation
{
    private FrostBolt6d8Every7p1d7DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} is covered in frost...";

    protected override string RechargeTimeRollExpression => "1d7+7";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(Cold6d8ProjectileScript);

    public override int Value => 250;

    public override string Name => "Frost bolt (6d8)";

}
