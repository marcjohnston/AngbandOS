﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BreatheLightningScript : Script, IScript
{
    private BreatheLightningScript(Game game) : base(game) { }

    /// <summary>
    /// Allows a direction to be chosen, then fires a chaos ball projectile with a damage that matches the players health with a radius of -2.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.MsgPrint("You breathe lightning.");
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), dir, 100, -2);
    }
}