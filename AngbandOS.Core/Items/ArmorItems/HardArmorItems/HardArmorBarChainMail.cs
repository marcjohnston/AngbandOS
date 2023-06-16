namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HardArmorBarChainMail : HardArmorItemClass
{
    private HardArmorBarChainMail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Bar Chain Mail";

    public override int Ac => 18;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 950;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "Bar Chain Mail~";
    public override int Level => 35;
    public override int[] Locale => new int[] { 35, 0, 0, 0 };
    public override int? SubCategory => 8;
    public override int ToH => -2;
    public override int Weight => 280;
    public override Item CreateItem() => new BarChainMailHardArmorItem(SaveGame);
}
