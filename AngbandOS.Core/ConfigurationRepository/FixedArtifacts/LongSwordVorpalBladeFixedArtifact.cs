// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordVorpalBladeFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private LongSwordVorpalBladeFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(SwordLongSword));
    }


    public override ItemFactory BaseItemCategory => _baseItemCategory;

    /// <summary>
    /// Returns a 1-in-3 chance for the long sword of vorpal cutting.
    /// </summary>
    public override int VorpalExtraDamage1InChance => 3;

    /// <summary>
    /// Returns a 1-in-2 chance for the long sword of vorpal to have extra attacks.
    /// </summary>
    public override int VorpalExtraAttacks1InChance => 2;

    public override bool IsVorpalBlade => true;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "The Long Sword 'Vorpal Blade'";
    public override int Ac => 0;
    public override int Cost => 250000;
    public override int Dd => 5;
    public override bool Dex => true;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Vorpal Blade'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override bool Lightsource => true;
    public override int Pval => 2;
    public override int Rarity => 30;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool SlayEvil => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 32;
    public override int ToH => 32;
    public override bool Vorpal => true;
    public override int Weight => 150;
}
