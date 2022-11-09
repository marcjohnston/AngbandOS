using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class JammedDoor7FloorTileType : FloorTileType
{
    public override char Character => '+';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "JammedDoor7";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Bash;
    public override string AppearAs => "LockedDoor0";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.JammedDoor;
    public override string Description => "jammed door";
    public override bool DimsOutsideLOS => true;
    public override bool IsClosedDoor => true;
    public override int MapPriority => 17;
}
