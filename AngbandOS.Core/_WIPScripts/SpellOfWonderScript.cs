// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpellOfWonderScript : Script, IScript, ICastSpellScript
{
    private SpellOfWonderScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes a random spell in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        IntegerExpression roll = Game.ComputeIntegerExpression(Game.CharacterClass.SpellOfWonderBeamProbabilityRoll);
        int beam = roll.Value;
        int die = Game.DieRoll(100) + (Game.ExperienceLevel.IntValue / 5);
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (die > 100)
        {
            Game.MsgPrint("You feel a surge of power!");
        }
        if (die < 8)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(OldCloneProjectile));
            projectile.TargetedFire(dir, 0, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
        else if (die < 14)
        {
            Game.RunScript(nameof(OldSpeed1xProjectileScript));
        }
        else if (die < 26)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(OldHealProjectile));
            projectile.TargetedFire(dir, Game.DiceRoll(4, 6), 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
        else if (die < 31)
        {
            Game.RunIdentifiedScriptDirection(nameof(OldPolymorph1xProjectileScript), dir);
        }
        else if (die < 36)
        {
            Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 5), 4));
        }
        else if (die < 41)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(OldConfuseProjectile));
             projectile.TargetedFire(dir, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
        else if (die < 46)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PoisonGasProjectile));
            projectile.TargetedFire(dir, 20 + (Game.ExperienceLevel.IntValue / 2), 3, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
        else if (die < 51)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(LightWeakProjectile));
            projectile.TargetedFire(dir, Game.DiceRoll(6, 8), 0, beam: true, grid: true, kill: true, jump: false, stop: false, item: false, thru: true, hide: false);
        }
        else if (die < 56)
        {
            Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Get<Projectile>(nameof(ElectricityProjectile)), dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
        }
        else if (die < 61)
        {
            Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, Game.DiceRoll(5 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
        }
        else if (die < 66)
        {
            Game.FireBoltOrBeam(beam, Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, Game.DiceRoll(6 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
        }
        else if (die < 71)
        {
            Game.FireBoltOrBeam(beam, Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, Game.DiceRoll(8 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
        }
        else if (die < 76)
        {
            Game.RunIdentifiedScript(nameof(OldDrainLife75ProjectileScript));
        }
        else if (die < 81)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ElectricityProjectile));
            projectile.TargetedFire(dir, 30 + (Game.ExperienceLevel.IntValue / 2), 2, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
        else if (die < 86)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile));
            projectile.TargetedFire(dir, 40 + Game.ExperienceLevel.IntValue, 2, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
        else if (die < 91)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(IceProjectile));
            projectile.TargetedFire(dir, 70 + Game.ExperienceLevel.IntValue, 3, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
        else if (die < 96)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile));
            projectile.TargetedFire(dir, 80 + Game.ExperienceLevel.IntValue, 3, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
        else if (die < 101)
        {
            Game.RunScript(nameof(OldDrainLife1xp100ProjectileScript));
        }
        else if (die < 104)
        {
            Game.Earthquake(Game.MapY.IntValue, Game.MapX.IntValue, 12);
        }
        else if (die < 106)
        {
            Game.DestroyArea(Game.MapY.IntValue, Game.MapX.IntValue, 15);
        }
        else if (die < 108)
        {
            Game.RunScript(nameof(GenocideScript));
        }
        else if (die < 110)
        {
            Game.RunScript(nameof(DispelAllAtLos120ProjectileScript));
        }
        else
        {
            Game.RunScript(nameof(DispelAllAtLos150ProjectileScript));
            Game.RunScript(nameof(OldSlowAtLos1xProjectileScript));
            Game.RunScript(nameof(OldSleepAtLos1xProjectileScript));
            Game.RestoreHealth(300);
        }
    }
    public string LearnedDetails => "random";
}
