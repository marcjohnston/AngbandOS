namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuarterstaffFirestaffFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool BrandFire => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "'Firestaff'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a quarterstaff which provides no light.
    /// </summary>
    public override int Radius => 3;
    public override string? BonusIntelligenceRollExpression => "3";
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override int Cost => 70000;
}
