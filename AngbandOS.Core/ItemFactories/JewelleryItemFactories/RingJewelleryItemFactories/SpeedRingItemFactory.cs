// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpeedRingItemFactory : RingItemFactory
{
    private SpeedRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(EqualSignSymbol));
    public override string Name => "Speed";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power == 0 && Game.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        item.TypeSpecificValue = Game.DieRoll(5) + item.GetBonusValue(5, level);
        while (Game.RandomLessThan(100) < 50)
        {
            item.TypeSpecificValue++;
        }
        if (power < 0)
        {
            item.IdentBroken = true;
            item.IdentCursed = true;
            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
        }
        else
        {
            Game.TreasureRating += 25;
        }
    }

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100000;
    public override string FriendlyName => "Speed";
    public override bool HideType => true;
    public override int LevelNormallyFound => 80;
    public override int[] Locale => new int[] { 80, 0, 0, 0 };
    public override bool Speed => true;
    public override int Weight => 2;

    public override bool KindIsGood => true;
    public override Item CreateItem() => new Item(Game, this);
}
