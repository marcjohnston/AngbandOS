// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class NaturesWrathScript : Script, IScript
{
    private NaturesWrathScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RunScript(nameof(DispelAllAtLos4xProjectileScript));
        Game.Earthquake(Game.MapY.IntValue, Game.MapX.IntValue, 20 + (Game.ExperienceLevel.IntValue / 2));
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(DisintegrateProjectile));
        projectile.Fire(0, 1 + (Game.ExperienceLevel.IntValue / 12), Game.MapY.IntValue, Game.MapX.IntValue, 100 + Game.ExperienceLevel.IntValue, kill: true, item: true, jump: false, beam: false, thru: false, hide: false, grid: false, stop: false);
    }
}
