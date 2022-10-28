using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class GraveFloorTileType : BaseFloorTileType
{
    public override char Character => '+';
    public override string Name => "Grave";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Grave";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "grave";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
