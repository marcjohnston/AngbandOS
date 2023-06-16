namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SoftArmorLeatherScaleMail : SoftArmorItemClass
{
    private SoftArmorLeatherScaleMail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Leather Scale Mail";

    public override int Ac => 11;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 450;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Leather Scale Mail~";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int? SubCategory => 11;
    public override int ToH => -1;
    public override int Weight => 140;
    public override Item CreateItem() => new LeatherScaleMailSoftArmorItem(SaveGame);
}
