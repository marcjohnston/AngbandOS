using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class QuartzHidTreasFloorTileType : FloorTileType
{
    public override char Character => '#';
    public override string Name => "QuartzHidTreas";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Quartz";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Vein;
    public override string Description => "quartz vein";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 11;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
