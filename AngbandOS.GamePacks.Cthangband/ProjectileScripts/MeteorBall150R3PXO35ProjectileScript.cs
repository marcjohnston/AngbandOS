namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MeteorBall150R3PXO35ProjectileScript : ProjectileScriptGameConfiguration
{
    public override string DamageRollExpression => "150";
    public override string RadiusRollExpression => "3+X/35";
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string ProjectileBindingKey => nameof(MeteorProjectile);
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
}