// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DamageRingItemFactory : RingItemFactory
{
    private DamageRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override string Name => "Damage";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power == 0 && SaveGame.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        item.BonusDamage = 5 + SaveGame.DieRoll(8) + item.GetBonusValue(10, level);
        if (power < 0)
        {
            item.IdentBroken = true;
            item.IdentCursed = true;
            item.BonusDamage = 0 - item.BonusDamage;
        }
    }

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 500;
    public override string FriendlyName => "Damage";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 2;
    public override Item CreateItem() => new Item(SaveGame, this);
}
