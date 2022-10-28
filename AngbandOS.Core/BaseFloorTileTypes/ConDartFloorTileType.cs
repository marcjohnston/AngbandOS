using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ConDartFloorTileType : BaseFloorTileType
{
    public override char Character => '^';
    public override Colour Colour => Colour.Red;
    public override string Name => "ConDart";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Disarm;
    public override string AppearAs => "ConDart";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "dart trap";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
