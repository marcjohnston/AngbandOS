// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Long range teleport.
/// </summary>
[Serializable]
internal class Teleport100Every45Activation : Activation
{
    private Teleport100Every45Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} twists space around you...";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(TeleportSelfScript);

    protected override string RechargeTimeRollExpression => "45";

    public override int Value => 2000;

    public override string Name => "Teleport (100)";

}
