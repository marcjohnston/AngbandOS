namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PairOfSoftLeatherBootsOfDancingFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Dancing heal poison and fear
    public override string? ActivationName => nameof(ActivationsEnum.RemoveFearAndPoisonEvery5Activation);
    public override bool FreeAct => true;
    public override string FriendlyName => "of Dancing";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusCharismaRollExpression => "5";
    public override string? BonusDexterityRollExpression => "5";
    public override bool ResChaos => true;
    public override bool ResNether => true;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override int Cost => 40000;
}
