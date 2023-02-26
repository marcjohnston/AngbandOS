namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class InvisFloorTileType : FloorTileType
{
    private InvisFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override string Name => "Invis";
    public override string AppearAs => "Invis";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.UnidentifiedTrap;
    public override string Description => "invisible trap";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 5;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
