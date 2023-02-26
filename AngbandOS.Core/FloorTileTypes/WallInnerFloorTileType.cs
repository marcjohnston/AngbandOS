namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class WallInnerFloorTileType : FloorTileType
{
    private WallInnerFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "WallInner";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "WallBasic";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "granite wall";
    public override bool DimsOutsideLOS => true;
    public override bool IsBasicWall => true;
    public override bool IsWall => true;
    public override int MapPriority => 10;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
