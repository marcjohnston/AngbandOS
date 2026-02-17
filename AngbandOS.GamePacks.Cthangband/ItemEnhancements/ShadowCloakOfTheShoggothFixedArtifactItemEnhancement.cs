namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakOfTheShoggothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "12"),
        (nameof(ValueAttribute), "35000"),
        (nameof(StealthAttribute), "4"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of the Shoggoth";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImAcid => true;
    public override bool? SeeInvis => true;
    public override ColorEnum? Color => ColorEnum.Black;
}
