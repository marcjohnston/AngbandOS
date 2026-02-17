namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MorningStarFirestarterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(RadiusAttribute), "3"),
        (nameof(ToDamageAttribute), "7"),
        (nameof(MeleeToHitAttribute), "5"),
        (nameof(AttacksAttribute), "2"),
        (nameof(ValueAttribute), "35000"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.LargeBallFire72Every100DirectionalActivation);
    public override bool? BrandFire => true;
    public override string FriendlyName => "'Firestarter'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override ColorEnum? Color => ColorEnum.Black;
}
