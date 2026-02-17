namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakDarknessFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.SleepActivation);
    public override string FriendlyName => "'Darkness'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StealthAttribute), "2"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "13000"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(WisdomAttribute), "2"),
        (nameof(AttacksAttribute), "4"),
    };
    public override bool? ResAcid => true;
    public override bool? ResDark => true;
    public override ColorEnum? Color => ColorEnum.Green;
}
