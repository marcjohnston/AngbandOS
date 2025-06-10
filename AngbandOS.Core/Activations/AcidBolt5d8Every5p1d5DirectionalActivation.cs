// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Shoot an acid bolt that does 5d8 damage.
/// </summary>
[Serializable]
internal class AcidBolt5d8Every5p1d5DirectionalActivation : Activation
{
    private AcidBolt5d8Every5p1d5DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} is covered in acid...";

    protected override string RechargeTimeRollExpression => "1d5+5";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(Acid5d8ProjectileScript);

    public override int Value => 250;

    public override string Name => "Acid bolt (5d8)";
}
