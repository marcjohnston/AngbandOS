namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AugmentedChainMailOfTheOgreLordsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Ogre Lords destroys doors
    public override string? ActivationName => nameof(ActivationsEnum.DestroyDoorsEvery10Activation);
    public override bool Con => true;
    public override string FriendlyName => "of the Ogre Lords";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override string? BonusConstitutionRollExpression => "3";
    public override string? BonusIntelligenceRollExpression => "3";
    public override string? BonusWisdomRollExpression => "3";
    public override bool ResAcid => true;
    public override bool ResConf => true;
    public override bool ResPois => true;
    public override bool Wis => true;
}