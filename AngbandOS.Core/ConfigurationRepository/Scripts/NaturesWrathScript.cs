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
    private NaturesWrathScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.DispelMonsters(SaveGame.ExperienceLevel.Value * 4);
        SaveGame.Earthquake(SaveGame.MapY, SaveGame.MapX, 20 + (SaveGame.ExperienceLevel.Value / 2));
        SaveGame.Project(0, 1 + (SaveGame.ExperienceLevel.Value / 12), SaveGame.MapY, SaveGame.MapX, 100 + SaveGame.ExperienceLevel.Value, SaveGame.SingletonRepository.Projectiles.Get(nameof(DisintegrateProjectile)), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectItem);
    }
}
