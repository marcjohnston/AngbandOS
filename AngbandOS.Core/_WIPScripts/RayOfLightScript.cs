// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RayOfLightScript : Script, IScript, ICastSpellScript
{
    private RayOfLightScript(Game game) : base(game) { }

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
        Game.MsgPrint("A line of light appears.");
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(LightWeakProjectile));
        projectile.TargetedFire(dir, Game.DiceRoll(6, 8), 0, beam: true, grid: true, kill: true, jump: false, stop: false, item: false, thru: true, hide: false);
    }
    public string LearnedDetails => "dam 6d8";
}
