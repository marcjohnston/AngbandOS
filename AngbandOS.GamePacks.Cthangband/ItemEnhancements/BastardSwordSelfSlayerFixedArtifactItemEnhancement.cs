namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BastardSwordSelfSlayerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Aggravate => true;
    public override bool IsCursed => true;
    public override string FriendlyName => "'Selfslayer'";
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int SlayDragon => 5;
    public override string? BonusConstitutionRollExpression => "5";
    public override bool ResDisen => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayTroll => true;
    public override int Cost => 100000;
    public override int DamageDice => 2;
}
