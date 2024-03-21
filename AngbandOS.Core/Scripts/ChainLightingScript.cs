// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ChainLightingScript : Script, IScript
{
    private ChainLightingScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a beam of electricity in all directions.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int dir = 0; dir <= 9; dir++)
        {
            Game.FireBeam(Game.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, Game.DiceRoll(5 + (Game.ExperienceLevel.Value / 10), 8));
        }
    }
}
