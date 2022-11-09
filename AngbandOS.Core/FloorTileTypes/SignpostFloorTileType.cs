using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SignpostFloorTileType : FloorTileType
{
    public override char Character => ':';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Signpost";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Signpost";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Tree;
    public override string Description => "signpost";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
