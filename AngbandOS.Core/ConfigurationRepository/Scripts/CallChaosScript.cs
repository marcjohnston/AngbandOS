// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CallChaosScript : Script, IScript
{
    private CallChaosScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Randomly chooses a projectile and randomly fires a beam or a ball with random damage, sometimes allowing the choice of direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int plev = SaveGame.ExperienceLevel;
        bool lineChaos = false;
        Projectile[] hurtTypes =
        {
            SaveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(ArrowProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(PlasmaProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(HolyFireProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(WaterProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(LightProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(DarkProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(ForceProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(InertiaProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(ManaProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(MeteorProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(IceProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(ChaosProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(NetherProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(DisenchantProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(ExplodeProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(SoundProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(NexusProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(ConfusionProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(TimeProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(GravityProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(ShardProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(NukeProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(HellFireProjectile)),
            SaveGame.SingletonRepository.Projectiles.Get(nameof(DisintegrateProjectile))
        };
        Projectile chaosType = hurtTypes[SaveGame.Rng.DieRoll(30) - 1];
        if (SaveGame.Rng.DieRoll(4) == 1)
        {
            lineChaos = true;
        }
        if (SaveGame.Rng.DieRoll(6) == 1)
        {
            for (int dummy = 1; dummy < 10; dummy++)
            {
                if (dummy - 5 != 0)
                {
                    if (lineChaos)
                    {
                        SaveGame.FireBeam(chaosType, dummy, 75);
                    }
                    else
                    {
                        SaveGame.FireBall(chaosType, dummy, 75, 2);
                    }
                }
            }
        }
        else if (SaveGame.Rng.DieRoll(3) == 1)
        {
            SaveGame.FireBall(chaosType, 0, 300, 8);
        }
        else
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            if (lineChaos)
            {
                SaveGame.FireBeam(chaosType, dir, 150);
            }
            else
            {
                SaveGame.FireBall(chaosType, dir, 150, 3 + (plev / 35));
            }
        }
    }
}
