namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MultiHuedDragonScaleMailRazorbackFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.StarBall150Every1000p1d325DirectionalActivation);
    public override bool? Aggravate => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-4"),
        (nameof(AttacksAttribute), "25"),
        (nameof(ValueAttribute), "400000"),
        (nameof(WeightAttribute), "300"),
        (nameof(RadiusAttribute), "3"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Razorback'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImElec => true;
    public override bool? ResCold => true;
    public override bool? ResDark => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? ResPois => true;
    public override bool? SeeInvis => true;
    public override ColorEnum? Color => ColorEnum.Purple;
}
