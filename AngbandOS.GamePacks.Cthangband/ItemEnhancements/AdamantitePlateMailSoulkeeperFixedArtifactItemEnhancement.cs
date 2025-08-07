namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AdamantitePlateMailSoulkeeperFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.Heal1000Every888Activation);
    public override bool Con => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "'Soulkeeper'";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "2";
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool SustCon => true;
    public override int Value => 280000; // Total 300000
    public override int Cost => 300000;
}
