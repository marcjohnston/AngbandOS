namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerCharityFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.LightningBolt4d8Every6p1d6DirectionalActivation);
    public override bool? BrandElec => true;
    public override string FriendlyName => "'Charity'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResElec => true;
    public override bool? ShowMods => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "13000"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(MeleeToHitAttribute), "4"),
        (nameof(ToDamageAttribute), "6"),
    };
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
