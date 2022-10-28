using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TrapDoorFloorTileType : BaseFloorTileType
{
    public override char Character => '^';
    public override string Name => "TrapDoor";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Disarm;
    public override string AppearAs => "TrapDoor";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.TrapDoor;
    public override string Description => "trap door";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
