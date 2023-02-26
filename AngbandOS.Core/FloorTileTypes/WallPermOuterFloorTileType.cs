namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class WallPermOuterFloorTileType : FloorTileType
{
    private WallPermOuterFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "WallPermOuter";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "WallPermInner";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "magically reinforced wall";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override bool IsWall => true;
    public override int MapPriority => 10;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
