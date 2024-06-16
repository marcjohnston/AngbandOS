// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerOfAssassinFixedArtifact : FixedArtifact
{
    private DaggerOfAssassinFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(DaggerWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Dagger of Assassin";
    public override int Ac => 0;
    public override bool BrandPois => true;
    public override int Cost => 125000;
    public override int TreasureRating => 20;
    public override int Dd => 2;
    public override bool Dex => true;
    public override int Ds => 4;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Assassin";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int InitialBonusDexterity => 4;
    public override int InitialBonusSearch => 4;
    public override int InitialBonusStealth => 4;
    public override int Rarity => 80;
    public override bool ResDark => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Stealth => true;
    public override bool SustDex => true;
    public override int ToA => 5;
    public override int ToD => 15;
    public override int ToH => 10;
    public override int Weight => 12;
}
