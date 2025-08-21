// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CallSunlightScript : Script, IScript, ICastSpellScript
{
    private CallSunlightScript(Game game) : base(game) { }

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
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(LightProjectile));
        projectile.TargetedFire(0, 150, 8, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        Game.RunScript(nameof(LightScript));
        if (!Game.Race.IsBurnedBySunlight || Game.HasLightResistance)
        {
            return;
        }
        Game.MsgPrint("The sunlight scorches your flesh!");
        Game.TakeHit(50, "sunlight");
    }
    public string LearnedDetails => "dam 150";
}
