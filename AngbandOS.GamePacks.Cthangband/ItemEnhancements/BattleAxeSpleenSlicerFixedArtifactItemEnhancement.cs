namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BattleAxeSpleenSlicerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(MeleeToHitAttribute), "4"),
        (nameof(ToDamageAttribute), "3"),
        (nameof(ValueAttribute), "21000"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(StrengthAttribute), "1"),
        (nameof(DexterityAttribute), "1"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Heal4d8AndWoundsEvery3p1d3Activation);
    public override string FriendlyName => "'Spleen Slicer'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ShowMods => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
