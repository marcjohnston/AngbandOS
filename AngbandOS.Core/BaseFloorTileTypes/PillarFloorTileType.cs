using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PillarFloorTileType : BaseFloorTileType
{
    public override char Character => '#';
    public override string Name => "Pillar";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Pillar";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "pillar";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 12;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
