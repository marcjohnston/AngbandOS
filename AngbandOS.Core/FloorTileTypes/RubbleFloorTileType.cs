namespace AngbandOS.Core;

[Serializable]
internal class RubbleFloorTileType : FloorTileType
{
    public override char Character => ':';
    public override string Name => "Rubble";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Rubble";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Rubble;
    public override string Description => "pile of rubble";
    public override bool DimsOutsideLOS => true;
    public override bool IsInteresting => true;
    public override int MapPriority => 12;
    public override bool YellowInTorchlight => true;
}
