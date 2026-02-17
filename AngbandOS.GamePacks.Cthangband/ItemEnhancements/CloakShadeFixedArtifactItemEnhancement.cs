namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakShadeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "8000"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Shade'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? SeeInvis => true;
    public override ColorEnum? Color => ColorEnum.Green;
}
