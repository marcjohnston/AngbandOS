// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DispelLivingScript : Script, IScript, IScriptInt
{
    private DispelLivingScript(Game game) : base(game) { }

    /// <summary>
    /// Dispels living.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptInt(int dam)
    {
        Game.ProjectAtAllInLos(Game.SingletonRepository.Get<Projectile>(nameof(DispLivingProjectile)), dam);
    }

    /// <summary>
    /// Executes the Int script with a predefined damage of 3x the players experience.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteScriptInt(Game.ExperienceLevel.IntValue * 3);
    }
}
