namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerFaithFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    // Faith shoots a fire bolt
    public override string? ActivationName => nameof(ActivationsEnum.FireBolt9d8Every8p1d8DirectionalActivation);
    public override bool? BrandFire => true;
    public override string FriendlyName => "'Faith'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a dagger which provides no light.
    /// </summary>
    public override int? Radius => 3;
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override int? Value => 12000;
    public override string Hits => "4";
    public override string Damage => "6";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
