namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfAcid50r2AndResistAcid1d20p20DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool ResAcid => true;
    public override int Weight => 2;
    public override int Value => 2000;
    public override ColorEnum Color => ColorEnum.Gold;
}
