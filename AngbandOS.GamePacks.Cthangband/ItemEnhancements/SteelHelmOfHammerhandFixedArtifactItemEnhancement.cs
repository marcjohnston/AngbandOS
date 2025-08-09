namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SteelHelmOfHammerhandFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string FriendlyName => "of Hammerhand";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "3";
    public override bool ResAcid => true;
    public override bool ResNexus => true;
    public override int Cost => 45000;
    public override int DamageDice => 1;
}
