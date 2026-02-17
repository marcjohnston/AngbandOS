namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MorningStarBloodspikeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "22"),
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(ValueAttribute), "30000"),
        (nameof(StrengthAttribute), "4"),
    };
    public override string FriendlyName => "'Bloodspike'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResNexus => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.Black;
}
