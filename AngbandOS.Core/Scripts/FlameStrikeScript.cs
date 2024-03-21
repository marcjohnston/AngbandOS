// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class FlameStrikeScript : Script, IScript
{
    private FlameStrikeScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Fires a ball of fire at the location of the player.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), 0, 150 + (2 * SaveGame.ExperienceLevel.Value), 8);
    }
}
