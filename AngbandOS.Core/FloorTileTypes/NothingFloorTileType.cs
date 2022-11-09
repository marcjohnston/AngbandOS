using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class NothingFloorTileType : FloorTileType
{
    public override char Character => ' ';
    public override string Name => "Nothing";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "Nothing";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "nothing";
    public override int MapPriority => 0;
}
