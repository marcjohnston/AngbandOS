using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class WaterFloorTileType : BaseFloorTileType
{
    public override char Character => '~';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Water";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "Water";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "water";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
