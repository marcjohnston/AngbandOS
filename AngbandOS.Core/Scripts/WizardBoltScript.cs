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
    private WizardBoltScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int tx = Game.MapX + (99 * Game.KeypadDirectionXOffset[dir]);
        int ty = Game.MapY + (99 * Game.KeypadDirectionYOffset[dir]);
        if (dir == 5 && Game.TargetOkay())
        {
            flg &= ~ProjectionFlag.ProjectStop;
            tx = Game.TargetCol;
            ty = Game.TargetRow;
        }
        Game.Project(0, 0, ty, tx, 1000000, Game.SingletonRepository.Projectiles.Get(nameof(WizardBoltProjectile)), flg);
    }
}
