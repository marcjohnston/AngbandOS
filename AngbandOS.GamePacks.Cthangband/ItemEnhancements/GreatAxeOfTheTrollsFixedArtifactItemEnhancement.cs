namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatAxeOfTheTrollsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Trolls does mass carnage
    public override string? ActivationName => nameof(ActivationsEnum.MassCarnageActivation);
    public override bool? Blessed => true;
    public override bool? BrandCold => true;
    public override int? TreasureRating => 20;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of the Trolls";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImCold => true;
    public override string? Charisma => "2";
    public override string? Constitution => "2";
    public override string? Dexterity => "2";
    public override string? Intelligence => "2";
    public override string? Strength => "2";
    public override string? Wisdom => "2";
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayOrc => true;
    public override bool? SlayUndead => true;
    public override int? Value => 200000;
    public override string Attacks => "8";
    public override string Hits => "15";
    public override string Damage => "18";
    public override ColorEnum? Color => ColorEnum.Grey;
}
