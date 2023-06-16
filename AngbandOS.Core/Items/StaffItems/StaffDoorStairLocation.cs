namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffDoorStairLocation : StaffItemClass
{
    private StaffDoorStairLocation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '_';
    public override string Name => "Door/Stair Location";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 350;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Door/Stair Location";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int? SubCategory => 13;
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (eventArgs.SaveGame.DetectDoors())
        {
            eventArgs.Identified = true;
        }
        if (eventArgs.SaveGame.DetectStairs())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new DoorStairLocationStaffItem(SaveGame);
}
