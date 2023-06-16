namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffDetectInvisible : StaffItemClass
{
    private StaffDetectInvisible(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '_';
    public override string Name => "Detect Invisible";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 200;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Detect Invisible";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int? SubCategory => 14;
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (eventArgs.SaveGame.DetectMonstersInvis())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new DetectInvisibleStaffItem(SaveGame);
}
