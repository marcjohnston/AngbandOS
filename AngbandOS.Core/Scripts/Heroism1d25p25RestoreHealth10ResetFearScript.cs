﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Heroism1d25p25RestoreHealth10ResetFearScript : Script, IScript, INoticeableScript
{
    private Heroism1d25p25RestoreHealth10ResetFearScript(Game game) : base(game) { }

    public bool ExecuteNoticeableScript()
    {
        bool noticed = false;
        // Heroism removes fear, cures 10 health, and gives you timed heroism
        if (Game.FearTimer.ResetTimer())
        {
            noticed = true;
        }
        if (Game.HeroismTimer.AddTimer(Game.DieRoll(25) + 25))
        {
            noticed = true;
        }
        if (Game.RestoreHealth(10))
        {
            noticed = true;
        }
        return noticed;
    }

    /// <summary>
    /// Adds between 25 and 50 turns of heroism, restores 10 points of health and heals fear.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteNoticeableScript();
    }
}