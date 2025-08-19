// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TrapAndDoorDestructionScript : Script, IScript, ICastSpellScript
{
    private TrapAndDoorDestructionScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(DestroyTrapOrDoorProjectile));
        projectile.TargetedFire(dir, 0, 0, beam: true, grid: true, item: true, jump: false, stop: false, kill: false, thru: true, hide: false);
    }
    public string LearnedDetails => "";
}
