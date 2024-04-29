// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AccuracyRingItemFactory : RingItemFactory
{
    private AccuracyRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power == 0 && Game.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        item.BonusToHit = 5 + Game.DieRoll(8) + item.GetBonusValue(10, level);
        if (power < 0)
        {
            item.IdentBroken = true;
            item.IdentCursed = true;
            item.BonusToHit = 0 - item.BonusToHit;
        }
    }
    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(EqualSignSymbol));
    public override string Name => "Accuracy";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 500;
    public override string FriendlyName => "Accuracy";
    public override int LevelNormallyFound => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 2;
    public override Item CreateItem() => new Item(Game, this);
}
