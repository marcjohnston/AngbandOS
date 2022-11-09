using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PathBorderEWFloorTileType : FloorTileType
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathBorderEW";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "PathBorderEW";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Border;
    public override string Description => "path";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 0;
}
