// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpecialEnchantArmorScrollItemFactory : ScrollItemFactory
{
    private SpecialEnchantArmorScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(QuestionMarkSymbol));
    public override string Name => "*Enchant Armor*";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 500;
    public override string FriendlyName => "*Enchant Armor*";
    public override int LevelNormallyFound => 50;
    public override int[] Locale => new int[] { 50, 50, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (!Game.EnchantItem(0, 0, Game.DieRoll(3) + 2))
        {
            eventArgs.UsedUp = false;
        }
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
