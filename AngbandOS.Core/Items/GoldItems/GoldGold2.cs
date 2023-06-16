namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class GoldGold2 : GoldItemClass
{
    private GoldGold2(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '$';
    public override Colour Colour => Colour.Gold;
    public override string Name => "gold**";

    public override int Cost => 16;
    public override string FriendlyName => "gold";
    public override int Level => 1;
    public override Item CreateItem() => new Gold2GoldItem(SaveGame);
}
