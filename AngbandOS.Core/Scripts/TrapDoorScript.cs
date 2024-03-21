// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TrapDoorScript : Script, IScript
{
    private TrapDoorScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
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
            if (SaveGame.Health.Value >= 0)
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
