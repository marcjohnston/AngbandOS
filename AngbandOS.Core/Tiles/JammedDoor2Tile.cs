// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class JammedDoor2Tile : Tile
{
    private JammedDoor2Tile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    protected override string SymbolName => nameof(PlusSignSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    protected override string? AlterActionName => nameof(BashAlterAction);
    protected override string? OnJammedTileName => nameof(JammedDoor3Tile);
    protected override string? MimicTileName => nameof(LockedDoor0Tile);
    public override bool BlocksLos => true;
    public override string Description => "jammed door";
    public override bool DimsOutsideLOS => true;
    public override bool IsVisibleDoor => true;
    public override int MapPriority => 17;
    public override int LockLevel => 2;

    /// <summary>
    /// Returns true, because this tile is a jammed door.
    /// </summary>
    public override bool IsJammedClosedDoor => true;
}
