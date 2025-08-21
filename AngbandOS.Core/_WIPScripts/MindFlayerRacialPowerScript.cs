using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Scripts;

// Mind Flayers can shoot psychic bolts
[Serializable]
internal class MindFlayerRacialPowerScript : Script, IScript
{
    private MindFlayerRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        if (Game.GetDirectionWithAim(out int direction))
        {
            Game.MsgPrint("You concentrate and your eyes glow red...");
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PsiProjectile));
            projectile.TargetedFire(direction, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
    }
}