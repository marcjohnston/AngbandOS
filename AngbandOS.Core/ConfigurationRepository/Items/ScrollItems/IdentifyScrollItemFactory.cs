// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class IdentifyScrollItemFactory : ScrollItemFactory
{
    private IdentifyScrollItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Identify";

    public override int[] Chance => new int[] { 1, 1, 1, 1 };
    public override int Cost => 50;
    public override string FriendlyName => "Identify";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 5, 10, 30 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (!SaveGame.IdentifyItem())
        {
            eventArgs.UsedUp = false;
        }
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new IdentifyScrollItem(SaveGame);
}