// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class LockedDoor6Tile : Tile
{
    private LockedDoor6Tile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(PlusSignSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "LockedDoor6";
    public override AlterAction? AlterAction => SaveGame.SingletonRepository.AlterActions.Get(nameof(OpenAlterAction));
    protected override string? MimicTileName => "LockedDoor0";
    public override bool BlocksLos => true;
    public override string Description => "locked door";
    public override bool DimsOutsideLOS => true;
    public override bool IsVisibleDoor => true;
    public override int MapPriority => 17;

    /// <summary>
    /// Returns true, because this tile is a locked door.
    /// </summary>
    public override bool IsClosedDoor => true;
}
