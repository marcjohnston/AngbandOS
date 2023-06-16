namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollIdentify : ScrollItemClass
{
    private ScrollIdentify(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override string Name => "Identify";

    public override int[] Chance => new int[] { 1, 1, 1, 1 };
    public override int Cost => 50;
    public override string FriendlyName => "Identify";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 5, 10, 30 };
    public override int? SubCategory => 12;
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (!eventArgs.SaveGame.IdentifyItem())
        {
            eventArgs.UsedUp = false;
        }
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new IdentifyScrollItem(SaveGame);
}
