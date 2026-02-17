namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NecklaceOfTheDwarvesFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "75000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "3"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of the Dwarves";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? SeeInvis => true;
}
