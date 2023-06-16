namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class NetherResistanceRingItemFactory : RingItemFactory
{
    private NetherResistanceRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '=';
    public override string Name => "Nether Resistance";

    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 14500;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Nether Resistance";
    public override bool HoldLife => true;
    public override int Level => 34;
    public override int[] Locale => new int[] { 34, 0, 0, 0 };
    public override bool ResNether => true;
    public override int? SubCategory => 40;
    public override int Weight => 2;
    public override Item CreateItem() => new NetherResistanceRingItem(SaveGame);
}
