﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CallSunlightScript : Script, IScript
{
    private CallSunlightScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(LightProjectile)), 0, 150, 8);
        Game.RunScript(nameof(LightScript));
        if (!Game.Race.IsBurnedBySunlight || Game.HasLightResistance)
        {
            return;
        }
        Game.MsgPrint("The sunlight scorches your flesh!");
        Game.TakeHit(50, "sunlight");
    }
}