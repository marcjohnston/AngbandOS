using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PoisonGasFloorTileType : FloorTileType
{
    public override char Character => '^';
    public override Colour Colour => Colour.Green;
    public override string Name => "PoisonGas";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Disarm;
    public override string AppearAs => "PoisonGas";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "gas trap";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
