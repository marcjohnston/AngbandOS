// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CallChaosCancellableScript : Script, IScript, ICancellableScript, ICancellableScriptItem
{
    private CallChaosCancellableScript(Game game) : base(game) { }

    /// <summary>
    /// Runs the script and returns true because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScriptItem(Item item)
    {
        ExecuteScript();
        return true;
    }

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
        int plev = Game.ExperienceLevel.IntValue;
        bool lineChaos = false;
        Projectile[] hurtTypes =
        {
            Game.SingletonRepository.Get<Projectile>(nameof(ElectricityProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(PoisonGasProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ArrowProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(PlasmaProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(HolyFireProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(WaterProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(LightProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(DarkProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ForceProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(InertiaProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(MeteorProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(IceProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(NetherProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(DisenchantProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ExplodeProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(SoundProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(NexusProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ConfusionProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(TimeProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(GravityProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ShardProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(NukeProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(HellfireProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(DisintegrateProjectile))
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
