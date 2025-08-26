namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedFlailThunderfistFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool BrandElec => true;
    public override bool BrandFire => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "'Thunderfist'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a two-handed sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusStrengthRollExpression => "4";
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override int Weight => 20;
    public override int Value => 160000;
    public override string BonusHitsRollExpression => "5";
    public override string BonusDamageRollExpression => "18";
    public override ColorEnum Color => ColorEnum.Yellow;
}
