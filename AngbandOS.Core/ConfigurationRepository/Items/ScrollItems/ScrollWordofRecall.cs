// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollWordOfRecall : ScrollItemClass
{
    private ScrollWordOfRecall(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<QuestionMarkSymbol>();
    public override string Name => "Word of Recall";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 150;
    public override string FriendlyName => "Word of Recall";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        SaveGame.ToggleRecall();
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new WordOfRecallScrollItem(SaveGame);
}