// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollSpecialRemoveCurse : ScrollItemClass
{
    private ScrollSpecialRemoveCurse(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<QuestionMarkSymbol>();
    public override string Name => "*Remove Curse*";

    public override int[] Chance => new int[] { 2, 2, 2, 1 };
    public override int Cost => 8000;
    public override string FriendlyName => "*Remove Curse*";
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 75, 85, 95 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        SaveGame.RemoveAllCurse();
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new SpecialRemoveCurseScrollItem(SaveGame);
}
