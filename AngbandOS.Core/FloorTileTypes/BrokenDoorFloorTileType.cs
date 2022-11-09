using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BrokenDoorFloorTileType : FloorTileType
{
    public override char Character => '\'';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrokenDoor";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Close;
    public override string AppearAs => "BrokenDoor";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.OpenDoorway;
    public override string Description => "broken door";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 17;
}
