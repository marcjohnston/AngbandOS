namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalScaleMailOfTheOrcsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.GenocideEvery500Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusArmorClassAttribute), "2"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(AttacksAttribute), "40"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "150000"),
        (nameof(CharismaAttribute), "4"),
        (nameof(StrengthAttribute), "4"),
    };
    public override string FriendlyName => "of the Orcs";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResDark => true;
    public override bool? ResDisen => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
