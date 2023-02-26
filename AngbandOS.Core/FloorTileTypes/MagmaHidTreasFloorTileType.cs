namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class MagmaHidTreasFloorTileType : FloorTileType
{
    private MagmaHidTreasFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override Colour Colour => Colour.Grey;
    public override string Name => "MagmaHidTreas";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Magma";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Vein;
    public override string Description => "magma vein";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 11;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
