namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BarahirRingItemFactory : RingItemFactory
{
    private BarahirRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '=';
    public override string Name => "Barahir";

    public override int Cost => 65000;
    public override string FriendlyName => "& Ring~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int Level => 50;
    public override int? SubCategory => 32;
    public override int Weight => 2;
    public override Item CreateItem() => new BarahirRingItem(SaveGame);
}
