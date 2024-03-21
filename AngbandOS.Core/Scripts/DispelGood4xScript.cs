// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DispelGood4xScript : Script, IScript
{
    private DispelGood4xScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Projects a dispeal good to all monsters in the line-of-sight.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.ProjectAtAllInLos(SaveGame.SingletonRepository.Projectiles.Get(nameof(DispGoodProjectile)), SaveGame.ExperienceLevel.Value * 4);
    }
}
