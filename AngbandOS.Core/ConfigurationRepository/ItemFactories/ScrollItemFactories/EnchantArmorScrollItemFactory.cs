// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class EnchantArmorScrollItemFactory : ScrollItemFactory
{
    private EnchantArmorScrollItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Enchant Armor";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 125;
    public override string FriendlyName => "Enchant Armor";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        eventArgs.Identified = true;
        if (!SaveGame.EnchantItem(0, 0, 1))
        {
            eventArgs.UsedUp = false;
        }
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}