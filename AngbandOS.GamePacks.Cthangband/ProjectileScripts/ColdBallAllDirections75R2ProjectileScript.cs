namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ColdBallAllDirections75R2ProjectileScript : ProjectileScriptGameConfiguration
{
    public override string DamageRollExpression => "75";
    public override string RadiusRollExpression => "2";
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.AllDirections;
    public override string ProjectileBindingKey => nameof(ColdProjectile);
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
}