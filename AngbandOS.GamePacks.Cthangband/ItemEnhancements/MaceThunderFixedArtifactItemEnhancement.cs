namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceThunderFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.Speed20p1d20Every250Activation);
    public override bool? BrandElec => true;
    public override string FriendlyName => "'Thunder'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImElec => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(ToDamageAttribute), "12"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "50000"),
        (nameof(WeightAttribute), "80"),
    };
    public override bool? ShowMods => true;
    public override ColorEnum? Color => ColorEnum.Black;
}
