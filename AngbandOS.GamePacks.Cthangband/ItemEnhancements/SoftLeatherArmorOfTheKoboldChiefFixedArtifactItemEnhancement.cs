namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SoftLeatherArmorOfTheKoboldChiefFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "45000"),
        (nameof(StealthAttribute), "4"),
    };
    public override string FriendlyName => "of the Kobold Chief";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResDark => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
