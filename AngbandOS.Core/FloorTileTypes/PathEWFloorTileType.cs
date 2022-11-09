using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PathEWFloorTileType : FloorTileType
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathEW";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "PathEW";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "path";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
}
