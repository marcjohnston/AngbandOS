namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmuletOfAbdulAlhazredFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Amulet of Abdul Alhazred dispels evil
    public override string? ActivationName => nameof(ActivationsEnum.DispelEvil5xEvery300p1d300Activation);
    public override int? TreasureRating => 20;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Abdul Alhazred";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Charisma => "3";
    public override string? Infravision => "3";
    public override string? Wisdom => "3";
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? SeeInvis => true;
    public override int? Value => 90000;
}
