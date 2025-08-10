namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsOfGhoulsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.BoltOfFrost6d8Every1d7p7DirectionalActivation);
    public override string FriendlyName => "of Ghouls";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "4";
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool SustCon => true;
    public override int Cost => 33000;
    public override string BonusAttacksRollExpression => "15";
}
