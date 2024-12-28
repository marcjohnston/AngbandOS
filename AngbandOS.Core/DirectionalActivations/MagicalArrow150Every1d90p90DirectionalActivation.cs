// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class MagicalArrow150Every1d90p90DirectionalActivation : DirectionalActivation
{
    private MagicalArrow150Every1d90p90DirectionalActivation(Game game) : base(game) { }

    public override string? PreActivationMessage => "Your {0} grows magical spikes...";
    protected override string RechargeTimeRollExpression => "1d90+90";

    protected override string DirectionalActivationCancellableScriptBindingKey => nameof(MagicalArrow150Script);

    public override int Value => 5000;

    public override string Name => "Magical arrow (150)";

}

