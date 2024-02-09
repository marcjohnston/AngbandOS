// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class BrokenDoorTile : Tile
{
    private BrokenDoorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(SingleQuoteSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "BrokenDoor";
    public override AlterAction? AlterAction => SaveGame.SingletonRepository.AlterActions.Get(nameof(CloseAlterAction));
    public override string Description => "broken door";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 17;

    /// <summary>
    /// Returns true, because this tile is an open door.
    /// </summary>
    public override bool IsOpenDoor => true;
}
