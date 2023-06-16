namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollEnchantArmor : ScrollItemClass
{
    private ScrollEnchantArmor(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override string Name => "Enchant Armor";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 125;
    public override string FriendlyName => "Enchant Armor";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int? SubCategory => 16;
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        eventArgs.Identified = true;
        if (!eventArgs.SaveGame.EnchantItem(0, 0, 1))
        {
            eventArgs.UsedUp = false;
        }
    }
    public override Item CreateItem() => new EnchantArmorScrollItem(SaveGame);
}
