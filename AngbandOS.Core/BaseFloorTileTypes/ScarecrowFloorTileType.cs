using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ScarecrowFloorTileType : BaseFloorTileType
{
    public override char Character => 't';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Scarecrow";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Scarecrow";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Tree;
    public override string Description => "scarecrow";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
