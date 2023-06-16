namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class LongBowWeaponItemFactory : BowWeaponItemFactory
{
    private LongBowWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '}';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Long Bow";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 120;
    public override string FriendlyName => "& Long Bow~";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 40;
    public override int MissileDamageMultiplier => 3;
    public override ItemTypeEnum AmmunitionItemCategory => ItemTypeEnum.Arrow;
    public override Item CreateItem() => new LongBowWeaponItem(SaveGame);
}
