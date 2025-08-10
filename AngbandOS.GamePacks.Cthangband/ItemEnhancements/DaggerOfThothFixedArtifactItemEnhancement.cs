namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerOfThothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Thoth shoots a poison ball
    public override string? ActivationName => nameof(ActivationsEnum.StinkingCloud12Every1d4p4DirectionalActivation);
    public override bool BrandPois => true;
    public override string FriendlyName => "of Thoth";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResDisen => true;
    public override bool ResPois => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override int Cost => 35000;
    public override int DamageDice => 1;
    public override string BonusHitsRollExpression => "4";
    public override string BonusDamageRollExpression => "3";
}
