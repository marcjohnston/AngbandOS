﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WisdomAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private WisdomAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.


    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = 1 + item.GetBonusValue(5, level);
        if (power < 0 || (power == 0 && SaveGame.Rng.RandomLessThan(100) < 50))
        {
            item.IdentBroken = true;
            item.IdentCursed = true;
            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
        }
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(DoubleQuoteSymbol));
    public override string Name => "Wisdom";
    public override bool Wis => true;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 500;
    public override string FriendlyName => "Wisdom";
    public override bool HideType => true;
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 3;
    public override Item CreateItem() => new Item(SaveGame, this);
}