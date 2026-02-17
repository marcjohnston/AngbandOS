namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongBowOfSerpentsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "19"),
        (nameof(MeleeToHitAttribute), "17"),
        (nameof(ValueAttribute), "20000"),
        (nameof(DexterityAttribute), "3"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Serpents";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ShowMods => true;
    public override bool? XtraMight => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
