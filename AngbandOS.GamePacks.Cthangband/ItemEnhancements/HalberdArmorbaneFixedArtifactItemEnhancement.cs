namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalberdArmorbaneFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool BrandFire => true;
    public override bool Feather => true;
    public override string FriendlyName => "'Armorbane'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for an halberd which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusCharismaRollExpression => "3";
    public override bool ResFire => true;
    public override bool ResSound => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayGiant => true;
    public override bool SlayUndead => true;
    public override int Cost => 22000;
    public override string BonusHitsRollExpression => "6";
    public override string BonusDamageRollExpression => "9";
}
