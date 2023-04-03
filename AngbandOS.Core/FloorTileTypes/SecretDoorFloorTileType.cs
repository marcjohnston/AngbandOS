namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class SecretDoorFloorTileType : FloorTileType
{
    private SecretDoorFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "SecretDoor";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "WallBasic";
    public override bool BlocksLos => true;

    /// <summary>
    /// Returns false, because secret doors allow the scent trail to pass through.
    /// </summary>
    public override bool BlocksScent => false;

    public override FloorTileTypeCategory Category => FloorTileTypeCategory.SecretDoor;
    public override string Description => "granite wall";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 10;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
