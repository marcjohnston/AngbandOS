namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LawDragonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BreatheSoundOrShards230r2Every1d300p300DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResShards => true;
    public override bool ResSound => true;
    public override int TreasureRating => 30;
}