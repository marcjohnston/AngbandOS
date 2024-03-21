// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class InvokeSpiritsScript : Script, IScript
{
    private InvokeSpiritsScript(Game game) : base(game) { }

    /// <summary>
    /// Does 150 points of dispel monster; slows and sleeps monsters; restores 300 points of health; and an additional random.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int beam;
        switch (Game.BaseCharacterClass.ID)
        {
            case CharacterClass.Mage:
                beam = Game.ExperienceLevel.Value;
                break;

            case CharacterClass.HighMage:
                beam = Game.ExperienceLevel.Value + 10;
                break;

            default:
                beam = Game.ExperienceLevel.Value / 2;
                break;
        }
        int die = Game.DieRoll(100) + (Game.ExperienceLevel.Value / 5);
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
            Game.SummonSpecific(Game.MapY, Game.MapX, Game.Difficulty, Game.SingletonRepository.MonsterFilters.Get(nameof(UndeadMonsterFilter)));
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
            Game.PolyMonster(dir);
        }
        if (die < 36)
        {
            Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), dir,
                Game.DiceRoll(3 + ((Game.ExperienceLevel.Value - 1) / 5), 4));
        }
        if (die < 41)
        {
            Game.ConfuseMonster(dir, Game.ExperienceLevel.Value);
        }
        if (die < 46)
        {
            Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), dir, 20 + (Game.ExperienceLevel.Value / 2), 3);
        }
        if (die < 51)
        {
            Game.LightLine(dir);
        }
        if (die < 56)
        {
            Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.Value - 5) / 4), 8));
        }
        if (die < 61)
        {
            Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), dir, Game.DiceRoll(5 + ((Game.ExperienceLevel.Value - 5) / 4), 8));
        }
        if (die < 66)
        {
            Game.FireBoltOrBeam(beam, Game.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir, Game.DiceRoll(6 + ((Game.ExperienceLevel.Value - 5) / 4), 8));
        }
        if (die < 71)
        {
            Game.FireBoltOrBeam(beam, Game.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, Game.DiceRoll(8 + ((Game.ExperienceLevel.Value - 5) / 4), 8));
        }
        if (die < 76)
        {
            Game.DrainLife(dir, 75);
        }
        if (die < 81)
        {
            Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, 30 + (Game.ExperienceLevel.Value / 2), 2);
        }
        if (die < 86)
        {
            Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir, 40 + Game.ExperienceLevel.Value, 2);
        }
        if (die < 91)
        {
            Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(IceProjectile)), dir, 70 + Game.ExperienceLevel.Value, 3);
        }
        if (die < 96)
        {
            Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, 80 + Game.ExperienceLevel.Value, 3);
        }
        if (die < 101)
        {
            Game.DrainLife(dir, 100 + Game.ExperienceLevel.Value);
        }
        if (die < 104)
        {
            Game.Earthquake(Game.MapY, Game.MapX, 12);
        }
        if (die < 106)
        {
            Game.DestroyArea(Game.MapY, Game.MapX, 15);
        }
        if (die < 108)
        {
            Game.RunScript(nameof(GenocideScript));
        }
        if (die < 110)
        {
            Game.DispelMonsters(120);
        }
        Game.DispelMonsters(150);
        Game.RunScript(nameof(SlowMonstersScript));
        Game.RunScript(nameof(SleepMonstersScript));
        Game.RestoreHealth(300);
        if (die < 31)
        {
            Game.MsgPrint("Sepulchral voices chuckle. 'Soon you will join us, mortal.'");
        }
    }
}
