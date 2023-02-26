namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class PillarFloorTileType : FloorTileType
{
    private PillarFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Pillar";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Pillar";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "pillar";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 12;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
