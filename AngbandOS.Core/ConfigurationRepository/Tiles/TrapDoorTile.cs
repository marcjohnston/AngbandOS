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

    public override void StepOn(GridTile tile)
    {
        // Trap doors can be flown over with feather fall
        if (SaveGame.HasFeatherFall)
        {
            SaveGame.MsgPrint("You fly over a trap door.");
        }
        else
        {
            SaveGame.MsgPrint("You fell through a trap door!");
            // Trap doors do 2d8 fall damage
            int damage = SaveGame.DiceRoll(2, 8);
            string name = "a trap door";
            SaveGame.TakeHit(damage, name);
            // Even if we survived, we need a new level
            if (SaveGame.Health >= 0)
            {
                SaveGame.DoCmdSaveGame(true);
            }
            SaveGame.NewLevelFlag = true;
            // In dungeons we fall to a deeper level, but in towers we fall to a
            // shallower level because they go up instead of down
            if (SaveGame.CurDungeon.Tower)
            {
                SaveGame.CurrentDepth--;
            }
            else
            {
                SaveGame.CurrentDepth++;
            }
        }
    }
}
