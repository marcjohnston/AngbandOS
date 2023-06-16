namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class DamageRingItemFactory : RingItemFactory
{
    private DamageRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '=';
    public override string Name => "Damage";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 500;
    public override string FriendlyName => "Damage";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int? SubCategory => 29;
    public override int Weight => 2;
    public override Item CreateItem() => new DamageRingItem(SaveGame);
}
