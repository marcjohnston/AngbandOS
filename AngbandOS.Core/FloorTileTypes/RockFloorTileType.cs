namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class RockFloorTileType : FloorTileType
{
    private RockFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ':';
    public override string Name => "Rock";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Rock";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "rock";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
    public override bool YellowInTorchlight => true;
}
