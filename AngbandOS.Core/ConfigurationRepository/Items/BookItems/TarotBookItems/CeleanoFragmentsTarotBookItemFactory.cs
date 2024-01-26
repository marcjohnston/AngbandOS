// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CeleanoFragmentsTarotBookItemFactory : TarotBookItemFactory
{
    private CeleanoFragmentsTarotBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.Pink;
    public override string Name => "[Celeano Fragments]";

    public override int[] Chance => new int[] { 3, 0, 0, 0 };
    public override int Cost => 100000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Celeano Fragments]";
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
    public override Item CreateItem() => new CeleanoFragmentsTarotBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellEtherealDivination)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellAstralLore)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellSummonUndead)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellSummonDragon)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellMassSummons)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellSummonDemon)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellSummonAncientDragon)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellSummonGreaterUndead))
    };
}
