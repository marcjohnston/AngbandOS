namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HaftedMace : HaftedItemClass
{
    private HaftedMace(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '\\';
    public override Colour Colour => Colour.Black;
    public override string Name => "Mace";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 130;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "& Mace~";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int? SubCategory => 5;
    public override int Weight => 120;
    public override Item CreateItem() => new MaceHaftedWeaponItem(SaveGame);
}
