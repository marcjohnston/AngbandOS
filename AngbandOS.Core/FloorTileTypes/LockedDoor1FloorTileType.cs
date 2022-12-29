namespace AngbandOS.Core;

[Serializable]
internal class LockedDoor1FloorTileType : FloorTileType
{
    public override char Character => '+';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "LockedDoor1";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Open;
    public override string AppearAs => "LockedDoor0";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.LockedDoor;
    public override string Description => "locked door";
    public override bool DimsOutsideLOS => true;
    public override bool IsClosedDoor => true;
    public override int MapPriority => 17;
}
