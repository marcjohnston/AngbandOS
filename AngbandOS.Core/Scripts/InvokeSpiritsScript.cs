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
    private InvokeSpiritsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Does 150 points of dispel monster; slows and sleeps monsters; restores 300 points of health; and an additional random.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int beam;
        switch (SaveGame.BaseCharacterClass.ID)
        {
            case CharacterClass.Mage:
                beam = SaveGame.ExperienceLevel.Value;
                break;

            case CharacterClass.HighMage:
                beam = SaveGame.ExperienceLevel.Value + 10;
                break;

            default:
                beam = SaveGame.ExperienceLevel.Value / 2;
                break;
        }
        int die = SaveGame.DieRoll(100) + (SaveGame.ExperienceLevel.Value / 5);
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.MsgPrint("You call on the power of the dead...");
        if (die > 100)
        {
            SaveGame.MsgPrint("You feel a surge of eldritch force!");
        }
        if (die < 8)
        {
            SaveGame.MsgPrint("Oh no! Mouldering forms rise from the earth around you!");
            SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(UndeadMonsterFilter)));
        }
        if (die < 14)
        {
            SaveGame.MsgPrint("An unnamable evil brushes against your mind...");
            SaveGame.FearTimer.AddTimer(SaveGame.DieRoll(4) + 4);
        }
        if (die < 26)
        {
            SaveGame.MsgPrint("Your head is invaded by a horde of gibbering spectral voices...");
            SaveGame.ConfusedTimer.AddTimer(SaveGame.DieRoll(4) + 4);
        }
        if (die < 31)
        {
            SaveGame.PolyMonster(dir);
        }
        if (die < 36)
        {
            SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), dir,
                SaveGame.DiceRoll(3 + ((SaveGame.ExperienceLevel.Value - 1) / 5), 4));
        }
        if (die < 41)
        {
            SaveGame.ConfuseMonster(dir, SaveGame.ExperienceLevel.Value);
        }
        if (die < 46)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), dir, 20 + (SaveGame.ExperienceLevel.Value / 2), 3);
        }
        if (die < 51)
        {
            SaveGame.LightLine(dir);
        }
        if (die < 56)
        {
            SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, SaveGame.DiceRoll(3 + ((SaveGame.ExperienceLevel.Value - 5) / 4), 8));
        }
        if (die < 61)
        {
            SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), dir, SaveGame.DiceRoll(5 + ((SaveGame.ExperienceLevel.Value - 5) / 4), 8));
        }
        if (die < 66)
        {
            SaveGame.FireBoltOrBeam(beam, SaveGame.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir, SaveGame.DiceRoll(6 + ((SaveGame.ExperienceLevel.Value - 5) / 4), 8));
        }
        if (die < 71)
        {
            SaveGame.FireBoltOrBeam(beam, SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, SaveGame.DiceRoll(8 + ((SaveGame.ExperienceLevel.Value - 5) / 4), 8));
        }
        if (die < 76)
        {
            SaveGame.DrainLife(dir, 75);
        }
        if (die < 81)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, 30 + (SaveGame.ExperienceLevel.Value / 2), 2);
        }
        if (die < 86)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir, 40 + SaveGame.ExperienceLevel.Value, 2);
        }
        if (die < 91)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(IceProjectile)), dir, 70 + SaveGame.ExperienceLevel.Value, 3);
        }
        if (die < 96)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, 80 + SaveGame.ExperienceLevel.Value, 3);
        }
        if (die < 101)
        {
            SaveGame.DrainLife(dir, 100 + SaveGame.ExperienceLevel.Value);
        }
        if (die < 104)
        {
            SaveGame.Earthquake(SaveGame.MapY, SaveGame.MapX, 12);
        }
        if (die < 106)
        {
            SaveGame.DestroyArea(SaveGame.MapY, SaveGame.MapX, 15);
        }
        if (die < 108)
        {
            SaveGame.RunScript(nameof(GenocideScript));
        }
        if (die < 110)
        {
            SaveGame.DispelMonsters(120);
        }
        SaveGame.DispelMonsters(150);
        SaveGame.RunScript(nameof(SlowMonstersScript));
        SaveGame.RunScript(nameof(SleepMonstersScript));
        SaveGame.RestoreHealth(300);
        if (die < 31)
        {
            SaveGame.MsgPrint("Sepulchral voices chuckle. 'Soon you will join us, mortal.'");
        }
    }
}
