namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ResistAcidAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private ResistAcidAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '"';
    public override string Name => "Resist Acid";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 300;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Resist Acid";
    public override bool IgnoreAcid => true;
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override bool ResAcid => true;
    public override int Weight => 3;
    public override Item CreateItem() => new ResistAcidAmuletJeweleryItem(SaveGame);
}
