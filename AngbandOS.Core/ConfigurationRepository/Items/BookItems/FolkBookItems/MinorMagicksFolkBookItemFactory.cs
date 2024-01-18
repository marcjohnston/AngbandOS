// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class MinorMagicksFolkBookItemFactory : FolkBookItemFactory
{
    private MinorMagicksFolkBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColourEnum Colour => ColourEnum.BrightPurple;
    public override string Name => "[Minor Magicks]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 250;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Minor Magicks]";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 30;
    public override bool KindIsGood => false;

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(FolkSpellDetectDoorsAndTraps)),
        SaveGame.SingletonRepository.Spells.Get(nameof(FolkSpellPhlogiston)),
        SaveGame.SingletonRepository.Spells.Get(nameof(FolkSpellDetectTreasure)),
        SaveGame.SingletonRepository.Spells.Get(nameof(FolkSpellDetectEnchantment)),
        SaveGame.SingletonRepository.Spells.Get(nameof(FolkSpellDetectObjects)),
        SaveGame.SingletonRepository.Spells.Get(nameof(FolkSpellCurePoison)),
        SaveGame.SingletonRepository.Spells.Get(nameof(FolkSpellResistCold)),
        SaveGame.SingletonRepository.Spells.Get(nameof(FolkSpellResistFire))
    };

    public override Item CreateItem() => new MinorMagicksFolkBookItem(SaveGame);
}
