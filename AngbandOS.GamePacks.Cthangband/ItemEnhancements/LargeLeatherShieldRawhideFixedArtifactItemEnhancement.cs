namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeLeatherShieldRawhideFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string FriendlyName => "'Rawhide'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override int Weight => -40;
    public override int Cost => 12000;
    public override string BonusAttacksRollExpression => "20";
    public override ColorEnum Color => ColorEnum.BrightBrown;
}
