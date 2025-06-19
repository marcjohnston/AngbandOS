// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IlluminationEvery1d10p10DirectionalActivation : ActivationGameConfiguration
{

    public override string? PreActivationMessage => "The {0} wells with clear light...";
    public override string RechargeTimeRollExpression => "1d10+10";
    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.IlluminationEvery1d10p10Script);

    public override int Value => 5000;

    public override string Name => "Illumination";

}

