namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DragonHelmOfPowerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "4"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "300000"),
        (nameof(WeightAttribute), "25"),
        (nameof(DexterityAttribute), "4"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(RadiusAttribute), "3"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Terror40xEvery3xp10Activation);
    public override string FriendlyName => "of Power";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResBlind => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? Telepathy => true;
    public override ColorEnum? Color => ColorEnum.BrightGreen;
}
