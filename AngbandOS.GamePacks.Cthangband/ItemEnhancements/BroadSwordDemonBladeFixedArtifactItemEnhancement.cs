namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordDemonBladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override int? TreasureRating => 20;
    public override string FriendlyName => "'Demon Blade'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Attacks => "2";
    public override string? Charisma => "2";
    public override string? Dexterity => "2";
    public override string? Speed => "2";
    public override string? Stealth => "2";
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override int? Weight => -20;
    public override int? Vorpal1InChance => 6;
    public override int? VorpalExtraAttacks1InChance => 2;
    public override int? Value => 66666;
    public override int? DamageDice => 9;
    public override string Hits => "-30";
    public override string Damage => "7";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
