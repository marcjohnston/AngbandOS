namespace AngbandOS.Core;

[Serializable]
internal class TeleportRuneFloorTileType : FloorTileType
{
    public override char Character => '^';
    public override Colour Colour => Colour.Purple;
    public override string Name => "TeleportRune";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Disarm;
    public override string AppearAs => "TeleportRune";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "strange rune";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
