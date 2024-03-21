// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CallChaosScript : Script, IScript, ICancellableScript
{
    private CallChaosScript(Game game) : base(game) { }

    /// <summary>
    /// Runs the script and returns true because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScript()
    {
        ExecuteScript();
        return true;
    }

    /// <summary>
    /// Randomly chooses a projectile and randomly fires a beam or a ball with random damage, sometimes allowing the choice of direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int plev = Game.ExperienceLevel.Value;
        bool lineChaos = false;
        Projectile[] hurtTypes =
        {
            Game.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(FireProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(ArrowProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(PlasmaProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(HolyFireProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(WaterProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(LightProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(DarkProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(ForceProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(InertiaProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(ManaProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(MeteorProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(IceProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(ChaosProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(NetherProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(DisenchantProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(ExplodeProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(SoundProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(NexusProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(ConfusionProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(TimeProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(GravityProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(ShardProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(NukeProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(HellfireProjectile)),
            Game.SingletonRepository.Projectiles.Get(nameof(DisintegrateProjectile))
        };
        Projectile chaosType = hurtTypes[Game.DieRoll(30) - 1];
        if (Game.DieRoll(4) == 1)
        {
            lineChaos = true;
        }
        if (Game.DieRoll(6) == 1)
        {
            for (int dummy = 1; dummy < 10; dummy++)
            {
                if (dummy - 5 != 0)
                {
                    if (lineChaos)
                    {
                        Game.FireBeam(chaosType, dummy, 75);
                    }
                    else
                    {
                        Game.FireBall(chaosType, dummy, 75, 2);
                    }
                }
            }
        }
        else if (Game.DieRoll(3) == 1)
        {
            Game.FireBall(chaosType, 0, 300, 8);
        }
        else
        {
            if (!Game.GetDirectionWithAim(out int dir))
            {
                return;
            }
            if (lineChaos)
            {
                Game.FireBeam(chaosType, dir, 150);
            }
            else
            {
                Game.FireBall(chaosType, dir, 150, 3 + (plev / 35));
            }
        }
    }
}
