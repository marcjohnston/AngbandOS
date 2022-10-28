using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class WallPermSolidFloorTileType : BaseFloorTileType
{
    public override char Character => '#';
    public override string Name => "WallPermSolid";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "WallPermInner";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "magically reinforced wall";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override bool IsWall => true;
    public override int MapPriority => 10;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
