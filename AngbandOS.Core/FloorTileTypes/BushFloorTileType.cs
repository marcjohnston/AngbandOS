using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BushFloorTileType : FloorTileType
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Bush";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Bush";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Tree;
    public override string Description => "bush";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 0;
}
