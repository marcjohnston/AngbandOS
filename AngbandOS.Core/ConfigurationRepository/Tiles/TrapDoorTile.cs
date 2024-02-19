// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class TrapDoorTile : Tile
{
    private TrapDoorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    protected override string SymbolName => nameof(CaretSymbol);
    protected override string? AlterActionName => nameof(DisarmAlterAction);
    public override string Description => "trap door";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;

    /// <summary>
    /// Returns true, because this tile is a trap door.
    /// </summary>
    public override bool IsTrapDoor => true;

    protected override string? StepOnScriptName => nameof(TrapDoorScript);
}
