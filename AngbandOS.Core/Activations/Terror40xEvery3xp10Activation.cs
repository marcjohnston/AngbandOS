// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Activations;

/// <summary>
/// Scare monsters with a 40+level strength.
/// </summary>
[Serializable]
internal class Terror40xEvery3xp10Activation : Activation
{
    private Terror40xEvery3xp10Activation(Game game) : base(game) { }

    protected override string RechargeTimeRollExpression => "3d1*X+10";
    public override string? PreActivationMessage => "rays of fear in every direction";
    protected override string ActivationCancellableScriptItemBindingKey => nameof(TurnAllAtLos1xp40ProjectileScript);

    public override int Value => 2500;

    public override string Name => "Terror (40p1x)";

}
