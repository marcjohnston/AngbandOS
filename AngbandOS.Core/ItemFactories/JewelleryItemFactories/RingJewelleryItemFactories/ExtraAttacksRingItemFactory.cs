// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ExtraAttacksRingItemFactory : RingItemFactory
{
    private ExtraAttacksRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override string Name => "Extra Attacks";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power == 0 && Game.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        item.TypeSpecificValue = item.GetBonusValue(3, level);
        if (item.TypeSpecificValue < 1)
        {
            item.TypeSpecificValue = 1;
        }
        if (power < 0)
        {
            item.IdentBroken = true;
            item.IdentCursed = true;
            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
        }
    }

    public override bool Blows => true;
    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 100000;
    public override string FriendlyName => "Extra Attacks";
    public override int LevelNormallyFound => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int Weight => 2;
    public override Item CreateItem() => new Item(Game, this);
}