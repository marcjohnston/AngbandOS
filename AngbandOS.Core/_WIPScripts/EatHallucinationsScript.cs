﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatHallucinationsScript : Script, IEatOrQuaffScript
{
    private EatHallucinationsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (!Game.HasChaosResistance)
        {
            if (Game.HallucinationsTimer.AddTimer(Game.RandomLessThan(250) + 250))
            {
                return IdentifiedResultEnum.True;
            }
        }
        return IdentifiedResultEnum.False;
    }
}
