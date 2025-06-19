// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Banish evil creatures.
/// </summary>
[Serializable]
public class BanishEvilEvery250p1d250Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "";

    public override string ActivationCancellableScriptItemBindingKey => nameof(TeleportAwayEvilAtLosByArtifact100ProjectileScript);

    public override string RechargeTimeRollExpression => "1d250+250";

    public override int Value => 3000;

    public override string Name => "Banish evil";

}
