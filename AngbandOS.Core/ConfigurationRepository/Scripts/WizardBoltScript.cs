// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WizardBoltScript : Script, IScript
{
    private WizardBoltScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int tx = SaveGame.MapX + (99 * SaveGame.KeypadDirectionXOffset[dir]);
        int ty = SaveGame.MapY + (99 * SaveGame.KeypadDirectionYOffset[dir]);
        if (dir == 5 && SaveGame.TargetOkay())
        {
            flg &= ~ProjectionFlag.ProjectStop;
            tx = SaveGame.TargetCol;
            ty = SaveGame.TargetRow;
        }
        SaveGame.Project(0, 0, ty, tx, 1000000, SaveGame.SingletonRepository.Projectiles.Get(nameof(WizardBoltProjectile)), flg);
    }
}
