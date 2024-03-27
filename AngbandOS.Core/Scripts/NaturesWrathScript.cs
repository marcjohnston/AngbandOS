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
        Game.DispelMonsters(Game.ExperienceLevel.Value * 4);
        Game.Earthquake(Game.MapY.Value, Game.MapX.Value, 20 + (Game.ExperienceLevel.Value / 2));
        Game.Project(0, 1 + (Game.ExperienceLevel.Value / 12), Game.MapY.Value, Game.MapX.Value, 100 + Game.ExperienceLevel.Value, Game.SingletonRepository.Projectiles.Get(nameof(DisintegrateProjectile)), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectItem);
    }
}
