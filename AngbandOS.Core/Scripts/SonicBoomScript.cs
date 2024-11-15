// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SonicBoomScript : Script, IScript
{
    private SonicBoomScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(SoundProjectile));
        projectile.Fire(0, 2 + (Game.ExperienceLevel.IntValue / 10), Game.MapY.IntValue, Game.MapX.IntValue, 45 + Game.ExperienceLevel.IntValue, item: true, kill: true);
    }
}
