namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SlowDigestionAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private SlowDigestionAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '"';
    public override string Name => "Slow Digestion";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 200;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Slow Digestion";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override bool SlowDigest => true;
    public override int Weight => 3;
    public override Item CreateItem() => new SlowDigestionAmuletJeweleryItem(SaveGame);
}
