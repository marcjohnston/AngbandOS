namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class LockedDoor6FloorTileType : FloorTileType
{
    private LockedDoor6FloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '+';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "LockedDoor6";
    public override AlterAction? AlterAction => new OpenAlterAction();
    public override string AppearAs => "LockedDoor0";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.LockedDoor;
    public override string Description => "locked door";
    public override bool DimsOutsideLOS => true;
    public override bool IsClosedDoor => true;
    public override int MapPriority => 17;
}
