namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlamesRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfFire50r2AndResistFire1d20p20DirectionalActivation);
    public override bool IgnoreFire => true;
    public override bool ResFire => true;
    public override int Weight => 2;
    public override int Value => 1000;
    public override ColorEnum Color => ColorEnum.Gold;
}
