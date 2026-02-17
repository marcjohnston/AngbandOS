namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfBastFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.Speed75p1d75Every150p1d150Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "175000"),
        (nameof(SpeedAttribute), "4"),
        (nameof(DexterityAttribute), "4"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(StrengthAttribute), "4"),
    };
    public override string FriendlyName => "of Bast";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
}
