namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceOfDisruptionDeathwreakerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Aggravate => true;
    public override bool BrandFire => true;
    public override bool BrandPois => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "'Deathwreaker'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a mace which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override bool NoTele => true;
    public override string? BonusTunnelRollExpression => "6";
    public override string? BonusStrengthRollExpression => "6";
    public override bool ResChaos => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override int SlayDragon => 3;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool Vampiric => true;
    public override int Weight => 280;
    public override int Cost => 444444;
    public override int DamageDice => 5;
}
