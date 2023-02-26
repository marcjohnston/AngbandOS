namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class GraveFloorTileType : FloorTileType
{
    private GraveFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '+';
    public override string Name => "Grave";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Grave";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "grave";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
