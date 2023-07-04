// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class TrapDoorTile : Tile
{
    private TrapDoorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CaretSymbol>();
    public override string Name => "TrapDoor";
    public override AlterAction? AlterAction => new DisarmAlterAction();
    public override string AppearAs => "TrapDoor";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.TrapDoor;
    public override string Description => "trap door";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
