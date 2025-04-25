// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CallChaosCancellableScript : Script, IScript, ICastSpellScript, IActivateItemScript
{
    private CallChaosCancellableScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Runs the script and returns true because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public UsedResult ExecuteActivateItemScript(Item item)
    {
        ExecuteScript();
        return new UsedResult(true);
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
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ElectricityProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.PoisonGasProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.AcidProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ColdProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.FireProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.MissileProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ArrowProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.PlasmaProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.HolyFireProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.WaterProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.LightProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.DarknessProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ForceProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.InertiaProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ManaProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.MeteorProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.IceProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ChaosProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.NetherProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.DisenchantProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ExplodeProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.SoundProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.NexusProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ConfusionProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.TimeProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.GravityProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ShardProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.NukeProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.HellfireProjectile)),
            Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.DisintegrateProjectile))
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
