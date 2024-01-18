// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollRemoveCurse : ScrollItemClass
{
    private ScrollRemoveCurse(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Remove Curse";

    public override int[] Chance => new int[] { 1, 2, 2, 0 };
    public override int Cost => 100;
    public override string FriendlyName => "Remove Curse";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 20, 40, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (SaveGame.RemoveCurse())
        {
            SaveGame.MsgPrint("You feel as if someone is watching over you.");
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new RemoveCurseScrollItem(SaveGame);
}
