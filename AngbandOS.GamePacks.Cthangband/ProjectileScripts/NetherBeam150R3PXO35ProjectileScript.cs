namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NetherBeam150R3PXO35ProjectileScript : ProjectileScriptGameConfiguration
{
    public override string DamageRollExpression => "150";
    public override string RadiusRollExpression => "3+X/35";
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string ProjectileBindingKey => nameof(NetherProjectile);
    public override bool Stop => false;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => true;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => true;
    public override bool Hide => false;
}