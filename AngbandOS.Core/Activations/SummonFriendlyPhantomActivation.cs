// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Summon phantom warriors or beasts.
/// </summary>
[Serializable]
internal class SummonFriendlyPhantomActivation : Activation
{
    private SummonFriendlyPhantomActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "You summon a phantasmal servant.";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(FriendlyPhantomSummonScript);

    protected override string RechargeTimeRollExpression => "1d200+200";

    public override int Value => 12000;

    public override string Name => "Summon phantasmal servant";

}
