namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BeakedAxeOfTheodenFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(ToDamageAttribute), "10"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(ValueAttribute), "40000"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(WisdomAttribute), "3"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife120Every400DirectionalActivation);
    public override string FriendlyName => "of Theoden";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ShowMods => true;
    public override bool? SlowDigest => true;
    public override bool? Telepathy => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
