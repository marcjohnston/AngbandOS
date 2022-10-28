using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PathBaseFloorTileType : BaseFloorTileType
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathBase";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "PathBase";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "path base";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
}
