using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HomeFloorTileType : BaseFloorTileType
{
    public override char Character => '@';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Home";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "Home";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Home";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
