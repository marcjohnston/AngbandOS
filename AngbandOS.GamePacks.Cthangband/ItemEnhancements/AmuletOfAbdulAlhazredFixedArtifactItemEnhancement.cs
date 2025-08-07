namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmuletOfAbdulAlhazredFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Amulet of Abdul Alhazred dispels evil
    public override string? ActivationName => nameof(ActivationsEnum.DispelEvil5xEvery300p1d300Activation);
    public override bool Cha => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Abdul Alhazred";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override string? BonusCharismaRollExpression => "3";
    public override string? BonusInfravisionRollExpression => "3";
    public override string? BonusWisdomRollExpression => "3";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool SeeInvis => true;
    public override bool Wis => true;
    public override int Cost => 90000;
}
