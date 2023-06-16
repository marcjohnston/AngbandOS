namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class GoldRubies : GoldItemClass
{
    private GoldRubies(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '$';
    public override Colour Colour => Colour.Red;
    public override string Name => "rubies";

    public override int Cost => 24;
    public override string FriendlyName => "rubies";
    public override int Level => 1;
    public override Item CreateItem() => new RubiesGoldItem(SaveGame);
}
