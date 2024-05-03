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
    private DamageRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Damage";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power == 0 && Game.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        item.BonusDamage = 5 + Game.DieRoll(8) + item.GetBonusValue(10, level);
        if (power < 0)
        {
            item.IdentBroken = true;
            item.IdentCursed = true;
            item.BonusDamage = 0 - item.BonusDamage;
        }
    }

    public override int Cost => 500;
    public override string FriendlyName => "Damage";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 2;
    public override Item CreateItem() => new Item(Game, this);
}
