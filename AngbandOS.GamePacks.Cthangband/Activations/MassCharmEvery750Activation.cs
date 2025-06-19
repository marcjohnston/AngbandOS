// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Charm multiple monsters.
/// </summary>
[Serializable]
public class MassCharmEvery750Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "";

    public override string ActivationCancellableScriptItemBindingKey => nameof(CharmAtLos2xProjectileScript);

    public override string RechargeTimeRollExpression => "750";

    public override int Value => 17500;

    public override string Name => "Mass charm";

}
