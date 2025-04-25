// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportAwayEvilAtLosByArtifact100ProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => false;
    public override bool Kill => true;
    public override bool Jump => true;
    public override bool Beam => false;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => false;
    public override bool Hide => true;
    public override string ProjectileBindingKey => nameof(TeleportAwayEvilProjectile);
    public override string DamageRollExpression => "100";
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.AllMonstersInLos;
    public override bool? Identified => null;
    public override string? PostMessage => "The power of the artifact banishes evil!";
}
