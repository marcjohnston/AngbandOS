namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeLeatherShieldRawhideFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "12000"),
        (nameof(WeightAttribute), "-40"),
    };
    public override string FriendlyName => "'Rawhide'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResDark => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
