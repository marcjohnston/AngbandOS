namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PolearmBattleAxe : PolearmItemClass
{
    private PolearmBattleAxe(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Battle Axe";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 334;
    public override int Dd => 2;
    public override int Ds => 8;
    public override string FriendlyName => "& Battle Axe~";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int? SubCategory => 22;
    public override int Weight => 170;
    public override Item CreateItem() => new BattleAxePolearmWeaponItem(SaveGame);
}
