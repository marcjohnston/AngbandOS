namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ConfusionBeamAllDirections75ProjectileScript : ProjectileScriptGameConfiguration
{
    public override string DamageRollExpression => "75";
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.AllDirections;
    public override string ProjectileBindingKey => nameof(ConfusionProjectile);
    public override bool Stop => false;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => true;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => true;
    public override bool Hide => false;
}