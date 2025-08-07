namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatAxeOfTheTrollsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Trolls does mass carnage
    public override string? ActivationName => nameof(ActivationsEnum.MassCarnageActivation);
    public override bool Blessed => true;
    public override bool BrandCold => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int TreasureRating => 20;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Trolls";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool Int => true;
    public override string? BonusCharismaRollExpression => "2";
    public override string? BonusConstitutionRollExpression => "2";
    public override string? BonusDexterityRollExpression => "2";
    public override string? BonusIntelligenceRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override string? BonusWisdomRollExpression => "2";
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
    public override bool Wis => true;
    public override int Cost => 200000;
}
