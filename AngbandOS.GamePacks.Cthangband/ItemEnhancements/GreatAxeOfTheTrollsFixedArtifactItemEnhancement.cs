namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatAxeOfTheTrollsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.MassCarnageActivation);
    public override bool? Blessed => true;
    public override bool? BrandCold => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "18"),
        (nameof(MeleeToHitAttribute), "15"),
        (nameof(AttacksAttribute), "8"),
        (nameof(ValueAttribute), "200000"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(CharismaAttribute), "2"),
        (nameof(StrengthAttribute), "2")
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of the Trolls";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImCold => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayOrc => true;
    public override bool? SlayUndead => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
