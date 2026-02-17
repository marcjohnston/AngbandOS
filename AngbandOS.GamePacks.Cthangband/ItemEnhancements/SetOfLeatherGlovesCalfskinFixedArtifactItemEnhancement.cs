namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfLeatherGlovesCalfskinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "8"),
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "36000"),
        (nameof(StrengthAttribute), "2"),
        (nameof(ConstitutionAttribute), "2"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Calfskin'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ShowMods => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
