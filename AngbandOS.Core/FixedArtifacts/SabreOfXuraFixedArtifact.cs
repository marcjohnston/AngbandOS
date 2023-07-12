// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SabreOfXuraFixedArtifact : FixedArtifact
{
    private readonly ItemFactory _baseItemCategory;
    private SabreOfXuraFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<SwordSabre>();
    }

    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<VerticalBarSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "The Sabre of Xura";
    public override int Ac => 0;
    public override bool Blessed => true;
    public override bool BrandCold => true;
    public override bool Con => true;
    public override int Cost => 125000;
    public override int Dd => 2;
    public override bool Dex => true;
    public override int Ds => 7;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Xura";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 4;
    public override int Rarity => 45;
    public override bool Regen => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResFear => true;
    public override bool ResNether => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool SlowDigest => true;
    public override bool Str => true;
    public override bool SustCon => true;
    public override bool SustStr => true;
    public override int ToA => 0;
    public override int ToD => 12;
    public override int ToH => 20;
    public override int Weight => 50;
}
