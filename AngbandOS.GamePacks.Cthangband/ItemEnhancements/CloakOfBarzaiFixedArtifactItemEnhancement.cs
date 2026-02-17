namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfBarzaiFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "10000"),
        (nameof(AttacksAttribute), "15"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.ResistAll20p1d20Activation);
    public override string FriendlyName => "of Barzai";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResPois => true;
    public override ColorEnum? Color => ColorEnum.Green;
}
