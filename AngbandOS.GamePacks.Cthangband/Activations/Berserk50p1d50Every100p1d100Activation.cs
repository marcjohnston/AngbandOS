// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Bless us and make us a superhero.
/// </summary>
[Serializable]
public class Berserk50p1d50Every100p1d100Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.SuperheroismAndBlessing50p1d50Script);

    public override string RechargeTimeRollExpression => "1d100+100";

    public override int Value => 800;

    public override string Name => "Heroism and berserk (50+d50)";

}
