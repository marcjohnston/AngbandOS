namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfTheSwashbucklerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(CharismaAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
        (nameof(ValueAttribute), "35000"),
        (nameof(AttacksAttribute), "18"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.RechargeActivation);
    public override bool? FreeAct => true;
    public override string FriendlyName => "of the Swashbuckler";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResFire => true;
    public override ColorEnum? Color => ColorEnum.Green;
}
