namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsOfGhoulsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "33000"),
        (nameof(ConstitutionAttribute), "4"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BoltOfFrost6d8Every1d7p7DirectionalActivation);
    public override string FriendlyName => "of Ghouls";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResCold => true;
    public override bool? SustCon => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
