// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BrillianceAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private BrillianceAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<DoubleQuoteSymbol>();
    public override string Name => "Brilliance";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 500;
    public override string FriendlyName => "Brilliance";
    public override bool HideType => true;
    public override bool Int => true;
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 3;
    public override bool Wis => true;
    public override Item CreateItem() => new BrillianceAmuletJeweleryItem(SaveGame);
}