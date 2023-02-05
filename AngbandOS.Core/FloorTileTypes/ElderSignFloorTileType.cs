namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class ElderSignFloorTileType : FloorTileType
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "ElderSign";
    public override string AppearAs => "ElderSign";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Sigil;
    public override string Description => "Elder Sign";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override int MapPriority => 20;
}
