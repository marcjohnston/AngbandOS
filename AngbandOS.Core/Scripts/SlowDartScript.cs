﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SlowDartScript : Script, IScript
{
    private SlowDartScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Dart traps need a to-hit roll
        if (Game.TrapCheckHitOnPlayer(125))
        {
            Game.MsgPrint("A small dart hits you!");
            // Do 1d4 damage plus slow
            int damage = Game.DiceRoll(1, 4);
            string name = "a trap";
            Game.TakeHit(damage, name);
            Game.SlowTimer.AddTimer(Game.RandomLessThan(20) + 20);
        }
        else
        {
            Game.MsgPrint("A small dart barely misses you.");
        }
    }
}