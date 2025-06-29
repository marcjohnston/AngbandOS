namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceThunderFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Thunder does haste
    public override string? ActivationName => nameof(ActivationsEnum.Speed20p1d20Every250Activation);
    public override bool BrandElec => true;
    public override string FriendlyName => "'Thunder'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImElec => true;
    public override bool KillDragon => true;
    public override bool ShowMods => true;
}