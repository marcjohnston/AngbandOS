namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class QuartzHidTreasFloorTileType : FloorTileType
{
    private QuartzHidTreasFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "QuartzHidTreas";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Quartz";
    public override bool BlocksLos => true;
    public override string? HiddenTreasureFor => "QuartzVisTreas";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Vein;
    public override string Description => "quartz vein";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 11;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
