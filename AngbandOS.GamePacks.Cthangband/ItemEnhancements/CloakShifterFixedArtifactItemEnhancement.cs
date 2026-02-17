namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakShifterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(StealthAttribute), "3"),
        (nameof(ValueAttribute), "11000"),
        (nameof(AttacksAttribute), "15"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Teleport100Every45Activation);
    public override string FriendlyName => "'Shifter'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override ColorEnum? Color => ColorEnum.Green;
}
