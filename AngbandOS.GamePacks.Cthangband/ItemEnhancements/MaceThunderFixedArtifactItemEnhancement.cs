namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceThunderFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    // Thunder does haste
    public override string? ActivationName => nameof(ActivationsEnum.Speed20p1d20Every250Activation);
    public override bool? BrandElec => true;
    public override string FriendlyName => "'Thunder'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImElec => true;
    public override int? SlayDragon => 5;
    public override bool? ShowMods => true;
    public override int? Weight => 80;
    public override int? Value => 50000;
    public override int? DamageDice => 1;
    public override string Hits => "12";
    public override string Damage => "12";
    public override ColorEnum? Color => ColorEnum.Black;
}
