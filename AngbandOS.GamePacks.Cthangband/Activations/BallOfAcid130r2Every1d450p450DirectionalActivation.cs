// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BallOfAcid130r2Every1d450p450DirectionalActivation : ActivationGameConfiguration
{

    public override string? PreActivationMessage => "You breathe acid.";
    public override string RechargeTimeRollExpression => "1d450+450";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Acid130Rn2ProjectileScript);

    public override int Value => 5000;

    public override string Name => "Breathe acid (130)";

}

