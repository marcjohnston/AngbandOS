﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class VampiricDrainScript : Script, IScript
{
    private VampiricDrainScript(Game game) : base(game) { }

    /// <summary>
    /// Drains the health of a monster in a chosen direction and adds the same amount of health to the player.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int dummy = Game.ExperienceLevel.Value + (Game.DieRoll(Game.ExperienceLevel.Value) * Math.Max(1, Game.ExperienceLevel.Value / 10));
        if (!Game.DrainLife(dir, dummy))
        {
            return;
        }
        Game.RestoreHealth(dummy);
        dummy = Game.Food.Value + Math.Min(5000, 100 * dummy);
        if (Game.Food.Value < Constants.PyFoodMax)
        {
            Game.SetFood(dummy >= Constants.PyFoodMax ? Constants.PyFoodMax - 1 : dummy);
        }
    }
}