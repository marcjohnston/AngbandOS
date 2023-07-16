// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollSpecialIdentify : ScrollItemClass
{
    private ScrollSpecialIdentify(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<QuestionMarkSymbol>();
    public override string Name => "*Identify*";

    public override int[] Chance => new int[] { 1, 2, 1, 1 };
    public override int Cost => 1000;
    public override string FriendlyName => "*Identify*";
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 50, 80, 100 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        eventArgs.Identified = true;
        if (!SaveGame.IdentifyFully())
        {
            eventArgs.UsedUp = false;
        }
    }
    public override Item CreateItem() => new SpecialIdentifyScrollItem(SaveGame);
}
