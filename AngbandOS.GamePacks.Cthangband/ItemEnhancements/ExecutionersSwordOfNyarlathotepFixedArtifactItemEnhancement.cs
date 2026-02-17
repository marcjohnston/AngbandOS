namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExecutionersSwordOfNyarlathotepFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandPois => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "19"),
        (nameof(MeleeToHitAttribute), "18"),
        (nameof(ValueAttribute), "111000"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(Vorpal1InChanceAttribute), "6"),
        (nameof(SlayDragonAttribute), "3"),
    };
    public override string FriendlyName => "of Nyarlathotep";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayGiant => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override bool? SlayUndead => true;
    public override ColorEnum? Color => ColorEnum.Red;
}
