// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BladeOfChaosDoomcallerFixedArtifact : FixedArtifact
{
    private BladeOfChaosDoomcallerFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(BladeOfChaosWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "The Blade of Chaos 'Doomcaller'";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool BrandCold => true;
    public override bool BrandFire => true;
    public override bool BrandPois => true;
    public override bool Chaotic => true;
    public override int Cost => 250000;
    public override int TreasureRating => 20;
    public override int Dd => 6;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Doomcaller'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 70;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for the Blade of Chaos which provides no light.
    /// </summary>
    public override int Radius => 1;

    public override int InitialTypeSpecificValue => 0;
    public override int Rarity => 25;
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Telepathy => true;
    public override int ToA => -50;
    public override int ToD => 28;
    public override int ToH => 18;
    public override bool Vorpal => true;
    public override int Weight => 180;
}
