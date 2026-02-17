namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PairOfSoftLeatherBootsOfDancingFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(CharismaAttribute), "5"),
        (nameof(DexterityAttribute), "5"),
        (nameof(ValueAttribute), "40000"),
        (nameof(AttacksAttribute), "15"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.RemoveFearAndPoisonEvery5Activation);
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Dancing";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResChaos => true;
    public override bool? ResNether => true;
    public override bool? SustCha => true;
    public override bool? SustCon => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
