// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PnakoticManuscriptsCorporealBookItemFactory : CorporealBookItemFactory
{
    private PnakoticManuscriptsCorporealBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.BrightYellow;
    public override string Name => "[Pnakotic Manuscripts]";

    public override int[] Chance => new int[] { 3, 0, 0, 0 };
    public override int Cost => 100000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Pnakotic Manuscripts]";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 90;
    public override int[] Locale => new int[] { 90, 0, 0, 0 };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new PnakoticManuscriptsCorporealBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(CorporealSpellHeroism)),
        SaveGame.SingletonRepository.Spells.Get(nameof(CorporealSpellWraithform)),
        SaveGame.SingletonRepository.Spells.Get(nameof(CorporealSpellAttunement)),
        SaveGame.SingletonRepository.Spells.Get(nameof(CorporealSpellRestoreBody)),
        SaveGame.SingletonRepository.Spells.Get(nameof(CorporealSpellHealingTrue)),
        SaveGame.SingletonRepository.Spells.Get(nameof(CorporealSpellHypnoticEyes)),
        SaveGame.SingletonRepository.Spells.Get(nameof(CorporealSpellRestoreSoul)),
        SaveGame.SingletonRepository.Spells.Get(nameof(CorporealSpellInvulnerability))
   };
}
