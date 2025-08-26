namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeadCrownOfTheUniverseFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 20;
    public override bool IsCursed => true;
    public override string FriendlyName => "of the Universe";
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a lead crown which provides no light.
    /// </summary>
    public override int Radius => 3;
    public override bool NoTele => true;
    public override bool PermaCurse => true;
    public override string? BonusCharismaRollExpression => "125";
    public override string? BonusConstitutionRollExpression => "125";
    public override string? BonusDexterityRollExpression => "125";
    public override string? BonusIntelligenceRollExpression => "125";
    public override string? BonusInfravisionRollExpression => "125";
    public override string? BonusStrengthRollExpression => "125";
    public override string? BonusWisdomRollExpression => "125";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override bool Telepathy => true;
    public override int Value => 10000000;
    public override ColorEnum Color => ColorEnum.Black;
}
