namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordFiretongueFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "21"),
        (nameof(MeleeToHitAttribute), "19"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "205000"),
        (nameof(WeightAttribute), "50"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(Vorpal1InChanceAttribute), "6"),
        (nameof(CharismaAttribute), "4"),
        (nameof(RadiusAttribute), "3"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(StrengthAttribute), "4"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Firetongue'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResChaos => true;
    public override bool? ResFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlayGiant => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override bool? SlayUndead => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
