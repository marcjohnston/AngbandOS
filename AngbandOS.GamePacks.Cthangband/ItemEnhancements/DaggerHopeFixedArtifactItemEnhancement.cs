namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerHopeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Hope shoots a frost bolt
    public override string? ActivationName => nameof(ActivationsEnum.FrostBolt6d8Every7p1d7DirectionalActivation);

    public override bool BrandCold => true;
    public override string FriendlyName => "'Hope'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResCold => true;
    public override bool ShowMods => true;
    public override int Cost => 11000;
    public override int DamageDice => 1;
}
