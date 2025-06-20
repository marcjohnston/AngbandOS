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
            Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(PsiProjectile)), direction, Game.ExperienceLevel.IntValue);
        }
    }
}