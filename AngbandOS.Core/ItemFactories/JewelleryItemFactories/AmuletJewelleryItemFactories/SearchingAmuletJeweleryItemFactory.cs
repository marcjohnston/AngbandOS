// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SearchingAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private SearchingAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(DoubleQuoteSymbol));
    public override string Name => "Searching";


    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (power < 0 || (power == 0 && Game.RandomLessThan(100) < 50))
        {
            item.IdentBroken = true;
            item.IdentCursed = true;
            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
        }
    }
    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 600;
    public override string FriendlyName => "Searching";
    public override bool HideType => true;
    public override int LevelNormallyFound => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override bool Search => true;
    public override int Weight => 3;
    public override Item CreateItem() => new Item(Game, this);
}