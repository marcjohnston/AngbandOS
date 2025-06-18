namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SoftLeatherArmorOfTheKoboldChiefFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string FriendlyName => "of the Kobold Chief";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusStealthRollExpression => "4";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool Stealth => true;
}