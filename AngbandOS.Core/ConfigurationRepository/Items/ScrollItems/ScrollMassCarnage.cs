// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollMassCarnage : ScrollItemClass
{
    private ScrollMassCarnage(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<QuestionMarkSymbol>();
    public override string Name => "Mass Carnage";

    public override int[] Chance => new int[] { 4, 4, 0, 0 };
    public override int Cost => 1000;
    public override string FriendlyName => "Mass Carnage";
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 100, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        SaveGame.MassCarnage(true);
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new MassCarnageScrollItem(SaveGame);
}