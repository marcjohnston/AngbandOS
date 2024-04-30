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
        int tx = Game.MapX.IntValue + (99 * Game.KeypadDirectionXOffset[dir]); // TODO: Fix the 99*
        int ty = Game.MapY.IntValue + (99 * Game.KeypadDirectionYOffset[dir]); // TODO: Fix the 99*
        if (dir == 5 && Game.TargetWho != null)
        {
            GridCoordinate? target = Game.TargetWho.GetTargetLocation();
            if (target != null)
            {
                flg &= ~ProjectionFlag.ProjectStop;
                tx = target.X;
                ty = target.Y;
            }
        }
        Game.Project(0, 0, ty, tx, 1000000, Game.SingletonRepository.Get<Projectile>(nameof(WizardBoltProjectile)), flg);
    }
}
