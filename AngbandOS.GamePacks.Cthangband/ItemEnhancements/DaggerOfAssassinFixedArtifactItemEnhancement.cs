namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerOfAssassinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool BrandPois => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Assassin";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "4";
    public override string? BonusSearchRollExpression => "4";
    public override string? BonusStealthRollExpression => "4";
    public override bool ResDark => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SustDex => true;
    public override int Value => 125000;
    public override int DamageDice => 1;
    public override string BonusAttacksRollExpression => "5";
    public override string BonusHitsRollExpression => "10";
    public override string BonusDamageRollExpression => "15";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
