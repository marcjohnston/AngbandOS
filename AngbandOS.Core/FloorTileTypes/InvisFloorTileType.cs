namespace AngbandOS.Core;

[Serializable]
internal class InvisFloorTileType : FloorTileType
{
    public override char Character => '·';
    public override string Name => "Invis";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "Invis";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.UnidentifiedTrap;
    public override string Description => "invisible trap";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 5;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
