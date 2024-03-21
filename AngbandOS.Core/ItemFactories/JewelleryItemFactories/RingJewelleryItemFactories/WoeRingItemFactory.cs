// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WoeRingItemFactory : RingItemFactory
{
    private WoeRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override string Name => "Woe";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.IdentBroken = true;
        item.IdentCursed = true;
        item.BonusArmorClass = 0 - (5 + item.GetBonusValue(10, level));
        item.TypeSpecificValue = 0 - (1 + item.GetBonusValue(5, level));
    }

    public override bool Cha => true;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override bool Cursed => true;
    public override string FriendlyName => "Woe";
    public override bool HideType => true;
    public override int LevelNormallyFound => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int InitialTypeSpecificValue => -5;
    public override bool Teleport => true;
    public override int Weight => 2;
    public override bool Wis => true;
    public override Item CreateItem() => new Item(Game, this);
}
