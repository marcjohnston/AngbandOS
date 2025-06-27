namespace AngbandOS.GamePacks.Cthangband;

// Kobolds can throw poison darts
[Serializable]
public class KoboldRacialPowerScript : ProjectileScriptGameConfiguration
{
    public override string? PreMessage => "You throw a dart of poison.";
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string ProjectileBindingKey => nameof(PoisonGasProjectile);
    public override string DamageRollExpression => "X";
}