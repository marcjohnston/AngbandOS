// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Charm a monster.
/// </summary>
[Serializable]
internal class CharmMonster1xEvery400DirectionalActivation : Activation
{
    private CharmMonster1xEvery400DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "";

    protected override string RechargeTimeRollExpression => "400";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(Charm1xProjectileScript);

    public override int Value => 10000;

    public override string Name => "Charm monster";

}
