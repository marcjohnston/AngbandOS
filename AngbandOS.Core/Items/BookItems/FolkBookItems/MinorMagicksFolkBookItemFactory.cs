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

    public override char Character => '?';
    public override Colour Colour => Colour.BrightPurple;
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
        SaveGame.SingletonRepository.Spells.Get<FolkSpellDetectDoorsAndTraps>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellPhlogiston>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellDetectTreasure>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellDetectEnchantment>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellDetectObjects>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellCurePoison>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellResistCold>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellResistFire>()
    };

    public override Item CreateItem() => new MinorMagicksFolkBookItem(SaveGame);
}
