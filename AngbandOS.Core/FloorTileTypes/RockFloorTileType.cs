using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class RockFloorTileType : FloorTileType
{
    public override char Character => ':';
    public override string Name => "Rock";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Rock";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "rock";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
    public override bool YellowInTorchlight => true;
}
