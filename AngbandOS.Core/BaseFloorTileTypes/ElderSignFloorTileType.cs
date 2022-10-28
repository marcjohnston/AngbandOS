using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ElderSignFloorTileType : BaseFloorTileType
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "ElderSign";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "ElderSign";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Sigil;
    public override string Description => "Elder Sign";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override int MapPriority => 20;
}
