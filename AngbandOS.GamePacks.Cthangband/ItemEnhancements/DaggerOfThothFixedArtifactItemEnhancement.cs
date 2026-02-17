namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerOfThothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "35000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(MeleeToHitAttribute), "4"),
        (nameof(ToDamageAttribute), "3"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.StinkingCloud12Every1d4p4DirectionalActivation);
    public override bool? BrandPois => true;
    public override string FriendlyName => "of Thoth";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResDisen => true;
    public override bool? ResPois => true;
    public override bool? ShowMods => true;
    public override bool? SlayOrc => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
