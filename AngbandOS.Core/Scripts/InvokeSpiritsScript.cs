// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class InvokeSpiritsScript : Script, IScript, ICastSpellScript
{
    private InvokeSpiritsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Does 150 points of dispel monster; slows and sleeps monsters; restores 300 points of health; and an additional random.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int beam;
        switch (Game.BaseCharacterClass.ID)
        {
            case CharacterClassEnum.Mage:
                beam = Game.ExperienceLevel.IntValue;
                break;

            case CharacterClassEnum.HighMage:
                beam = Game.ExperienceLevel.IntValue + 10;
                break;

            default:
                beam = Game.ExperienceLevel.IntValue / 2;
                break;
        }
        int die = Game.DieRoll(100) + (Game.ExperienceLevel.IntValue / 5);
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.MsgPrint("You call on the power of the dead...");
        if (die > 100)
        {
            Game.MsgPrint("You feel a surge of eldritch force!");
        }
        if (die < 8)
        {
            Game.MsgPrint("Oh no! Mouldering forms rise from the earth around you!");
            Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(UndeadMonsterRaceFilter)), true, false);
        }
        if (die < 14)
        {
            Game.MsgPrint("An unnamable evil brushes against your mind...");
            Game.FearTimer.AddTimer(Game.DieRoll(4) + 4);
        }
        if (die < 26)
        {
            Game.MsgPrint("Your head is invaded by a horde of gibbering spectral voices...");
            Game.ConfusedTimer.AddTimer(Game.DieRoll(4) + 4);
        }
        if (die < 31)
        {
            Game.RunIdentifiedScriptDirection(nameof(OldPolymorph1xProjectileScript), dir);
        }
        if (die < 36)
        {
            Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), dir,
                Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 5), 4));
        }
        if (die < 41)
        {
            Game.ConfuseMonster(dir, Game.ExperienceLevel.IntValue);
        }
        if (die < 46)
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(PoisonGasProjectile)), dir, 20 + (Game.ExperienceLevel.IntValue / 2), 3);
        }
        if (die < 51)
        {
            Game.LightLine(dir);
        }
        if (die < 56)
        {
            Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Get<Projectile>(nameof(ElectricityProjectile)), dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
        }
        if (die < 61)
        {
            Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, Game.DiceRoll(5 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
        }
        if (die < 66)
        {
            Game.FireBoltOrBeam(beam, Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, Game.DiceRoll(6 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
        }
        if (die < 71)
        {
            Game.FireBoltOrBeam(beam, Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, Game.DiceRoll(8 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
        }
        if (die < 76)
        {
            Game.RunIdentifiedScript(nameof(OldDrainLife75ProjectileScript));
        }
        if (die < 81)
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElectricityProjectile)), dir, 30 + (Game.ExperienceLevel.IntValue / 2), 2);
        }
        if (die < 86)
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, 40 + Game.ExperienceLevel.IntValue, 2);
        }
        if (die < 91)
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(IceProjectile)), dir, 70 + Game.ExperienceLevel.IntValue, 3);
        }
        if (die < 96)
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, 80 + Game.ExperienceLevel.IntValue, 3);
        }
        if (die < 101)
        {
            Game.RunScript(nameof(OldDrainLife1xp100ProjectileScript));
        }
        if (die < 104)
        {
            Game.Earthquake(Game.MapY.IntValue, Game.MapX.IntValue, 12);
        }
        if (die < 106)
        {
            Game.DestroyArea(Game.MapY.IntValue, Game.MapX.IntValue, 15);
        }
        if (die < 108)
        {
            Game.RunScript(nameof(GenocideScript));
        }
        if (die < 110)
        {
            Game.RunScript(nameof(DispelAllAtLos120ProjectileScript));
        }
        Game.RunScript(nameof(DispelAllAtLos150ProjectileScript));
        Game.RunScript(nameof(OldSlowAtLos1xProjectileScript));
        Game.RunScript(nameof(OldSleepAtLos1xProjectileScript));
        Game.RestoreHealth(300);
        if (die < 31)
        {
            Game.MsgPrint("Sepulchral voices chuckle. 'Soon you will join us, mortal.'");
        }
    }
}
