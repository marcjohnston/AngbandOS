using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BlackMarketFloorTileType : BaseFloorTileType
{
    public override char Character => '7';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackMarket";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "BlackMarket";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Black Market";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
