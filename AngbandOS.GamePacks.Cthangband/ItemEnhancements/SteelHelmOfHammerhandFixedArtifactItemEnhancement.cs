namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SteelHelmOfHammerhandFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "45000"),
        (nameof(DexterityAttribute), "3"),
    };
    public override string FriendlyName => "of Hammerhand";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResNexus => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
