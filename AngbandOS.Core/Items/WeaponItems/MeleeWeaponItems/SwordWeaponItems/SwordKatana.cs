namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SwordKatana : SwordItemClass
{
    private SwordKatana(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Katana";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 400;
    public override int Dd => 3;
    public override int Ds => 4;
    public override string FriendlyName => "& Katana~";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int? SubCategory => 20;
    public override int Weight => 120;
    public override Item CreateItem() => new KatanaSwordWeaponItem(SaveGame);
}
