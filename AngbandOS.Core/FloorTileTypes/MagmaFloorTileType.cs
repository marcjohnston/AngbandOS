using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class MagmaFloorTileType : FloorTileType
{
    public override char Character => '#';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Magma";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Magma";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Vein;
    public override string Description => "magma vein";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 11;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
