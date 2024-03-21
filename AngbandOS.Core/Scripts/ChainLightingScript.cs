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
    private ChainLightingScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Fires a beam of electricity in all directions.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int dir = 0; dir <= 9; dir++)
        {
            SaveGame.FireBeam(SaveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, SaveGame.DiceRoll(5 + (SaveGame.ExperienceLevel.Value / 10), 8));
        }
    }
}
