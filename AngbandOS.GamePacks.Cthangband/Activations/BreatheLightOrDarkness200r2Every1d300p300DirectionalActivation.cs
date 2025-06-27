// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BreatheLightOrDarkness200r2Every1d300p300DirectionalActivation : ActivationGameConfiguration
{

    public override string? PreActivationMessage => "You breathe the elements.";
    public override string RechargeTimeRollExpression => "1d300+300";

    public override string ActivationCancellableScriptItemBindingKey => nameof(LightOrDarkness200rm2ProjectileScriptWeightedRandom);

    public override int Value => 5000;

    public override string Name => "Breathe light/darkness (200)";

}

