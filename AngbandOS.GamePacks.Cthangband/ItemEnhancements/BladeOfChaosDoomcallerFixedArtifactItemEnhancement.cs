namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BladeOfChaosDoomcallerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override bool? BrandCold => true;
    public override bool? BrandFire => true;
    public override bool? BrandPois => true;
    public override bool? Chaotic => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(Vorpal1InChanceAttribute), "6"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(ValueAttribute), "250000"),
        (nameof(AttacksAttribute), "-50"),
        (nameof(MeleeToHitAttribute), "18"),
        (nameof(ToDamageAttribute), "28"),
        (nameof(RadiusAttribute), "1"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Doomcaller'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResChaos => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override bool? SlayEvil => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override bool? Telepathy => true;
    public override ColorEnum? Color => ColorEnum.Purple;
}
