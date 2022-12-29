namespace AngbandOS.Core;

[Serializable]
internal class OpenDoorFloorTileType : FloorTileType
{
    public override char Character => '\'';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "OpenDoor";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Close;
    public override string AppearAs => "OpenDoor";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.OpenDoorway;
    public override string Description => "open door";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 17;
}
