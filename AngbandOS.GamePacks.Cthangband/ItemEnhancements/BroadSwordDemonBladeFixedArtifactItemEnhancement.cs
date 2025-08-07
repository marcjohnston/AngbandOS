namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordDemonBladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Aggravate => true;
    public override bool Blows => true;
    public override bool Cha => true;
    public override int TreasureRating => 20;
    public override bool Dex => true;
    public override string FriendlyName => "'Demon Blade'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusAttacksRollExpression => "2";
    public override string? BonusCharismaRollExpression => "2";
    public override string? BonusDexterityRollExpression => "2";
    public override string? BonusSpeedRollExpression => "2";
    public override string? BonusStealthRollExpression => "2";
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Speed => true;
    public override bool Stealth => true;
    public override int Weight => -20;
    public override bool Vorpal => true;
    public override int Cost => 66666;
}
