using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class RoofFloorTileType : BaseFloorTileType
{
    public override char Character => '#';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Roof";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Roof";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "building";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override bool IsWall => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
}
