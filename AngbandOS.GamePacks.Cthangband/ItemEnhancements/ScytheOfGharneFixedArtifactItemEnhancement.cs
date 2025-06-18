namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScytheOfGharneFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.WordOfRecallEvery200DirectionalActivation);
    public override bool BrandCold => true;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of G'harne";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a scythe which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusCharismaRollExpression => "3";
    public override string? BonusDexterityRollExpression => "3";
    public override bool ResCold => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
}