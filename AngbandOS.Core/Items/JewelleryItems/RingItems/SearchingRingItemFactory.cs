namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SearchingRingItemFactory : RingItemFactory
{
    private SearchingRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '=';
    public override string Name => "Searching";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 250;
    public override string FriendlyName => "Searching";
    public override bool HideType => true;
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override bool Search => true;
    public override int? SubCategory => 23;
    public override int Weight => 2;
    public override Item CreateItem() => new SearchingRingItem(SaveGame);
}
