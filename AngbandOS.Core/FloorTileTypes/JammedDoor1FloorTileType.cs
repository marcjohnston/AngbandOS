// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class JammedDoor1FloorTileType : FloorTileType
{
    private JammedDoor1FloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '+';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "JammedDoor1";
    public override AlterAction? AlterAction => new BashAlterAction();
    public override string AppearAs => "LockedDoor0";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.JammedDoor;
    public override string Description => "jammed door";
    public override bool DimsOutsideLOS => true;
    public override bool IsClosedDoor => true;
    public override int MapPriority => 17;
}
