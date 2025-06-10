// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpeedProjectileFriendlyProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => false;

    public override bool Kill => true;

    public override bool Jump => true;

    public override bool Beam => false;

    public override bool Grid => false;

    public override bool Item => true;

    public override bool Thru => false;

    public override bool Hide => false;

    public override string ProjectileBindingKey => nameof(OldSpeedProjectile);

    public override string DamageRollExpression => "0";
    public override string RadiusRollExpression => "2";
    public override bool SmashingOnPetsTurnsUnfriendly => false;
}
