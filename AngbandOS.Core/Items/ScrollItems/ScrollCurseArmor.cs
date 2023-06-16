namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollCurseArmor : ScrollItemClass
{
    private ScrollCurseArmor(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override string Name => "Curse Armor";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override string FriendlyName => "Curse Armor";
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int? SubCategory => 2;
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (eventArgs.SaveGame.CurseArmour())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new CurseArmorScrollItem(SaveGame);
}
