namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalberdArmorbaneFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "9"),
        (nameof(MeleeToHitAttribute), "6"),
        (nameof(ValueAttribute), "22000"),
        (nameof(CharismaAttribute), "3"),
        (nameof(RadiusAttribute), "3"),
    };
    public override bool? BrandFire => true;
    public override bool? Feather => true;
    public override string FriendlyName => "'Armorbane'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override bool? ResSound => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayGiant => true;
    public override bool? SlayUndead => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
