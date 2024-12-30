// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Teleport away an opponent.
/// </summary>
[Serializable]
internal class TeleportAwayEvery200DirectionalActivation : DirectionalActivation
{
    private TeleportAwayEvery200DirectionalActivation(Game game) : base(game) { }
    
    protected override string RechargeTimeRollExpression => "200";

    protected override string DirectionalActivationCancellableScriptBindingKey => nameof(TeleportAwayAll1xProjectileScript);

    public override int Value => 2000;

    public override string Name => "Teleport away";

}
