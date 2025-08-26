namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MorningStarFirestarterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Firestarter does fire ball
    public override string? ActivationName => nameof(ActivationsEnum.LargeBallFire72Every100DirectionalActivation);
    public override bool BrandFire => true;
    public override string FriendlyName => "'Firestarter'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a morning star which provides no light.
    /// </summary>
    public override int Radius => 3;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override int Value => 35000;
    public override string BonusAttacksRollExpression => "2";
    public override string BonusHitsRollExpression => "5";
    public override string BonusDamageRollExpression => "7";
    public override ColorEnum Color => ColorEnum.Black;
}
