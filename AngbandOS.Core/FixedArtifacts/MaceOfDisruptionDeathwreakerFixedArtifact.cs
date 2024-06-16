// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MaceOfDisruptionDeathwreakerFixedArtifact : FixedArtifact
{
    private MaceOfDisruptionDeathwreakerFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(MaceHaftedWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "The Mace of Disruption 'Deathwreaker'";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool BrandFire => true;
    public override bool BrandPois => true;
    public override int Cost => 444444;
    public override int TreasureRating => 20;
    public override int Dd => 7;
    public override int Ds => 8;
    public override string FriendlyName => "'Deathwreaker'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImFire => true;
    public override int Level => 80;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a mace which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override bool NoTele => true;
    protected override string? BonusTunnelRollExpression => "6";
    protected override string? BonusStrengthRollExpression => "6";
    public override int Rarity => 38;
    public override bool ResChaos => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 18;
    public override int ToH => 18;
    public override bool Tunnel => true;
    public override bool Vampiric => true;
    public override int Weight => 400;
}
