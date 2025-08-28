namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExecutionersSwordOfNyarlathotepFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandPois => true;
    public override int? TreasureRating => 20;
    public override string FriendlyName => "of Nyarlathotep";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override int? SlayDragon => 3;
    public override bool? SlayEvil => true;
    public override bool? SlayGiant => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override bool? SlayUndead => true;
    public override int? Vorpal1InChance => 6;
    public override int? VorpalExtraAttacks1InChance => 2;
    public override int? Value => 111000;
    public override string BonusHitsRollExpression => "18";
    public override string BonusDamageRollExpression => "19";
    public override ColorEnum? Color => ColorEnum.Red;
}
