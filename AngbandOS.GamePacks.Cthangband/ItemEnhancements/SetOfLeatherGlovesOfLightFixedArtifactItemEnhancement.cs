namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfLeatherGlovesOfLightFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "30000"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.MagicMissile2d6Every2DirectionalActivation);
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Light";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResLight => true;
    public override bool? SustCon => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
