namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TridentOfWrathFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Blessed => true;
    public override bool? Chaotic => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "18"),
        (nameof(MeleeToHitAttribute), "16"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(ValueAttribute), "90000"),
        (nameof(WeightAttribute), "230"),
        (nameof(DexterityAttribute), "2"),
        (nameof(StrengthAttribute), "2"),
    };
    public override string FriendlyName => "of Wrath";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResDark => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayUndead => true;
    public override ColorEnum? Color => ColorEnum.Yellow;
}
