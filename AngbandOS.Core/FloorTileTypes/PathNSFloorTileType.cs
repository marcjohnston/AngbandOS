using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PathNSFloorTileType : FloorTileType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathNS";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "PathNS";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "path";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
}
