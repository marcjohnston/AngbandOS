namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RapierOfMontoyaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool BrandCold => true;
    public override string FriendlyName => "of Montoya";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a rapier which provides no light.
    /// </summary>
    public override int Radius => 3;
    public override bool ResCold => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override int Cost => 15000;
}
