namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfAcid50r2AndResistAcid1d20p20DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool ResAcid => true;
}