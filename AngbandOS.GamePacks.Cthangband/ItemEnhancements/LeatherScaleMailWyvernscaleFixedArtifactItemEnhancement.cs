namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeatherScaleMailWyvernscaleFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(MeleeToHitAttribute), "-1"),
        (nameof(AttacksAttribute), "25"),
        (nameof(ValueAttribute), "25000"),
        (nameof(WeightAttribute), "-80"),
        (nameof(DexterityAttribute), "3"),
    };
    public override string FriendlyName => "'Wyvernscale'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResShards => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
