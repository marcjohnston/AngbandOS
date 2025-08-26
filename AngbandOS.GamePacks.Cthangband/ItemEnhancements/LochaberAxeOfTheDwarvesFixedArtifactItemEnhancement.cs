namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LochaberAxeOfTheDwarvesFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 20;
    public override string FriendlyName => "of the Dwarves";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusInfravisionRollExpression => "10";
    public override string? BonusTunnelRollExpression => "10";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override int Value => 80000;
    public override string BonusHitsRollExpression => "12";
    public override string BonusDamageRollExpression => "17";
    public override ColorEnum Color => ColorEnum.Black;
}
