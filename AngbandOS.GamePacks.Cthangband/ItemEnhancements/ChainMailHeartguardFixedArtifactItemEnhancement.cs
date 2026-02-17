namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChainMailHeartguardFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(CharismaAttribute), "2"),
        (nameof(StrengthAttribute), "2"),
        (nameof(ValueAttribute), "32000"),
        (nameof(AttacksAttribute), "15"),
        (nameof(MeleeToHitAttribute), "-2"),
    };
    public override string FriendlyName => "'Heartguard'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResNexus => true;
    public override bool? ResShards => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
