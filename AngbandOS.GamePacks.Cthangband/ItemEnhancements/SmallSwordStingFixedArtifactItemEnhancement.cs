namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallSwordStingFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(AttacksAttribute), "1"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "8"),
        (nameof(MeleeToHitAttribute), "7"),
        (nameof(DiceSidesAttribute), "-1"),
        (nameof(ValueAttribute), "100000"),
        (nameof(WeightAttribute), "-5"),
        (nameof(DexterityAttribute), "2"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "2"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Sting'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayOrc => true;
    public override bool? SlayUndead => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
