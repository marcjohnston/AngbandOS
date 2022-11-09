using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class FountainFloorTileType : FloorTileType
{
    public override char Character => '~';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Fountain";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Fountain";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "fountain";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
