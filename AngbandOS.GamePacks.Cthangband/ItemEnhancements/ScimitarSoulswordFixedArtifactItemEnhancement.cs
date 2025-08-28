namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScimitarSoulswordFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Blessed => true;
    public override string? BonusAttacksRollExpression => "1";
    public override int? TreasureRating => 20;
    public override string FriendlyName => "'Soulsword'";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? BonusIntelligenceRollExpression => "2";
    public override string? BonusWisdomRollExpression => "2";
    public override bool? ResChaos => true;
    public override bool? ResDisen => true;
    public override bool? ResNether => true;
    public override bool? ResNexus => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override bool? SlayDemon => true;
    public override int? SlayDragon => 3;
    public override bool? SlayEvil => true;
    public override bool? SlayUndead => true;
    public override int? Value => 111111;
    public override string BonusHitsRollExpression => "9";
    public override string BonusDamageRollExpression => "11";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
