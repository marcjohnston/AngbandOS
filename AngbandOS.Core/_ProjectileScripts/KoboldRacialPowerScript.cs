namespace AngbandOS.Core.Scripts;

// Kobolds can throw poison darts
[Serializable]
internal class KoboldRacialPowerScript : Script, IScript
{
    private KoboldRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        if (Game.GetDirectionWithAim(out int direction))
        {
            Game.MsgPrint("You throw a dart of poison.");
            Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(PoisonGasProjectile)), direction, Game.ExperienceLevel.IntValue);
        }
    }
}