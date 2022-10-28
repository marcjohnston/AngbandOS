using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ArmouryFloorTileType : BaseFloorTileType
{
    public override char Character => '2';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Armoury";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "Armoury";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Armoury";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
