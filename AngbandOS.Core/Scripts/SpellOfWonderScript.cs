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
        if (die > 100)
        {
            Game.MsgPrint("You feel a surge of power!");
        }
        if (die < 8)
        {
            Game.CloneMonster(dir);
        }
        else if (die < 14)
        {
            Game.RunScript(nameof(OldSpeed1xProjectileScript));
        }
        else if (die < 26)
        {
            Game.HealMonster(dir);
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
            Game.ConfuseMonster(dir, Game.ExperienceLevel.IntValue);
        }
        else if (die < 46)
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(PoisonGasProjectile)), dir, 20 + (Game.ExperienceLevel.IntValue / 2), 3);
        }
        else if (die < 51)
        {
            Game.LightLine(dir);
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
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElectricityProjectile)), dir, 30 + (Game.ExperienceLevel.IntValue / 2), 2);
        }
        else if (die < 86)
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, 40 + Game.ExperienceLevel.IntValue, 2);
        }
        else if (die < 91)
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(IceProjectile)), dir, 70 + Game.ExperienceLevel.IntValue, 3);
        }
        else if (die < 96)
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, 80 + Game.ExperienceLevel.IntValue, 3);
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
}
