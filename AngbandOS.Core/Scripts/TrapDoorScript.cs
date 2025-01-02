// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TrapDoorScript : Script, IScript, ICastSpellScript
{
    private TrapDoorScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Trap doors can be flown over with feather fall
        if (Game.HasFeatherFall)
        {
            Game.MsgPrint("You fly over a trap door.");
        }
        else
        {
            Game.MsgPrint("You fell through a trap door!");
            // Trap doors do 2d8 fall damage
            int damage = Game.DiceRoll(2, 8);
            string name = "a trap door";
            Game.TakeHit(damage, name);
            // Even if we survived, we need a new level
            if (Game.Health.IntValue >= 0)
            {
                Game.DoCmdSaveGame(true);
            }
            Game.NewLevelFlag = true;
            // In dungeons we fall to a deeper level, but in towers we fall to a
            // shallower level because they go up instead of down
            if (Game.CurDungeon.Tower)
            {
                Game.CurrentDepth--;
            }
            else
            {
                Game.CurrentDepth++;
            }
        }
    }
}
