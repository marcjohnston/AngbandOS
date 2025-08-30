namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GemstoneShiningTrapezodedronFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Shining Trapezohedron lights the entire level and recalls us, but drains
    // health to do so
    public override string? ActivationName => nameof(ActivationsEnum.TrapezohedronGemstoneActivation);
    public override int? TreasureRating => 20;
    public override string FriendlyName => "'Shining Trapezodedron'";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Intelligence => "3";
    public override string? Speed => "3";
    public override string? Wisdom => "3";
    public override bool? ResChaos => true;
    public override bool? SeeInvis => true;
    public override int? Value => 150000;
    public override ColorEnum? Color => ColorEnum.Red;
}
