using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class MagmaVisTreasFloorTileType : FloorTileType
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "MagmaVisTreas";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "MagmaVisTreas";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Vein;
    public override string Description => "magma vein with treasure";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 19;
    public override bool RunPast => true;
}
