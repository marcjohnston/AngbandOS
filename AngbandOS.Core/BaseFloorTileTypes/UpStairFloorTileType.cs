using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class UpStairFloorTileType : BaseFloorTileType
{
    public override char Character => '<';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "UpStair";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "UpStair";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.UpStair;
    public override string Description => "up staircase";
    public override bool DimsOutsideLOS => true;
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 25;
}
