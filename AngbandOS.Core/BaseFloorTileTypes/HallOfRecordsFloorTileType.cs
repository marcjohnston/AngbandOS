using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HallOfRecordsFloorTileType : BaseFloorTileType
{
    public override char Character => '8';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "HallOfRecords";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "HallOfRecords";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Hall of Records";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
