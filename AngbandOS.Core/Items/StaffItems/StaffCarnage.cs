namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffCarnage : StaffItemClass
{
    private StaffCarnage(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '_';
    public override string Name => "Carnage";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 3500;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Carnage";
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int? SubCategory => 27;
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        eventArgs.SaveGame.Carnage(true);
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new CarnageStaffItem(SaveGame);
}
