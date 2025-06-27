namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NexusBallAtSelf800R8ProjectileScript : ProjectileScriptGameConfiguration
{
    public override string DamageRollExpression => "800";
    public override string RadiusRollExpression => "8";
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.AtPlayerLocation;
    public override string ProjectileBindingKey => nameof(NexusProjectile);
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
}