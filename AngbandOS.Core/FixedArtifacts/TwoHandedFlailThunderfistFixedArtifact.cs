// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedFlailThunderfistFixedArtifact : FixedArtifact
{
    private TwoHandedFlailThunderfistFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(TwoHandedFlailHaftedWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "The Two-Handed Flail 'Thunderfist'";
    public override int Ac => 0;
    public override bool BrandElec => true;
    public override bool BrandFire => true;
    public override int Cost => 160000;
    public override int TreasureRating => 20;
    public override int Dd => 3;
    public override int Ds => 6;
    public override string FriendlyName => "'Thunderfist'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 45;


    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a two-handed sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int InitialBonusStrength => 4;
    public override int Rarity => 38;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 18;
    public override int ToH => 5;
    public override int Weight => 300;
}
