// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class FlailTotilaFixedArtifact : FixedArtifact
{
    private FlailTotilaFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(FlailHaftedWeaponItemFactory);

    // Totila does confusion
    protected override string? ActivationName => nameof(ConfuseMonster20Every15Activation);

    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "The Flail 'Totila'";
    public override int Ac => 0;
    public override bool BrandFire => true;
    public override int Cost => 55000;
    public override int TreasureRating => 20;
    public override int Dd => 3;
    public override int Ds => 6;
    public override string FriendlyName => "'Totila'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a flail which provides no light.
    /// </summary>
    public override int Radius => 3;

    protected override string? BonusStealthRollExpression => "2";
    public override int Rarity => 8;
    public override bool ResConf => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool Stealth => true;
    public override int ToA => 0;
    public override int ToD => 8;
    public override int ToH => 6;
    public override int Weight => 150;
}
