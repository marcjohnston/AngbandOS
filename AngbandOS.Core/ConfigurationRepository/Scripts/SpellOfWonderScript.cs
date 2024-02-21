// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpellOfWonderScript : Script, IScript
{
    private SpellOfWonderScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes a random spell in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int beam;
        switch (SaveGame.BaseCharacterClass.ID)
        {
            case CharacterClass.Mage:
                beam = SaveGame.ExperienceLevel;
                break;

            case CharacterClass.HighMage:
                beam = SaveGame.ExperienceLevel + 10;
                break;

            default:
                beam = SaveGame.ExperienceLevel / 2;
                break;
        }
        int die = SaveGame.DieRoll(100) + (SaveGame.ExperienceLevel / 5);
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (die > 100)
        {
            SaveGame.MsgPrint("You feel a surge of power!");
        }
        if (die < 8)
        {
            SaveGame.CloneMonster(dir);
        }
        else if (die < 14)
        {
            SaveGame.SpeedMonster(dir);
        }
        else if (die < 26)
        {
            SaveGame.HealMonster(dir);
        }
        else if (die < 31)
        {
            SaveGame.PolyMonster(dir);
        }
        else if (die < 36)
        {
            SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), dir,
                SaveGame.DiceRoll(3 + ((SaveGame.ExperienceLevel - 1) / 5), 4));
        }
        else if (die < 41)
        {
            SaveGame.ConfuseMonster(dir, SaveGame.ExperienceLevel);
        }
        else if (die < 46)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), dir, 20 + (SaveGame.ExperienceLevel / 2), 3);
        }
        else if (die < 51)
        {
            SaveGame.LightLine(dir);
        }
        else if (die < 56)
        {
            SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir,
                SaveGame.DiceRoll(3 + ((SaveGame.ExperienceLevel - 5) / 4), 8));
        }
        else if (die < 61)
        {
            SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), dir,
                SaveGame.DiceRoll(5 + ((SaveGame.ExperienceLevel - 5) / 4), 8));
        }
        else if (die < 66)
        {
            SaveGame.FireBoltOrBeam(beam, SaveGame.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir,
                SaveGame.DiceRoll(6 + ((SaveGame.ExperienceLevel - 5) / 4), 8));
        }
        else if (die < 71)
        {
            SaveGame.FireBoltOrBeam(beam, SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir,
                SaveGame.DiceRoll(8 + ((SaveGame.ExperienceLevel - 5) / 4), 8));
        }
        else if (die < 76)
        {
            SaveGame.DrainLife(dir, 75);
        }
        else if (die < 81)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, 30 + (SaveGame.ExperienceLevel / 2), 2);
        }
        else if (die < 86)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir, 40 + SaveGame.ExperienceLevel, 2);
        }
        else if (die < 91)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(IceProjectile)), dir, 70 + SaveGame.ExperienceLevel, 3);
        }
        else if (die < 96)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, 80 + SaveGame.ExperienceLevel, 3);
        }
        else if (die < 101)
        {
            SaveGame.DrainLife(dir, 100 + SaveGame.ExperienceLevel);
        }
        else if (die < 104)
        {
            SaveGame.Earthquake(SaveGame.MapY, SaveGame.MapX, 12);
        }
        else if (die < 106)
        {
            SaveGame.DestroyArea(SaveGame.MapY, SaveGame.MapX, 15);
        }
        else if (die < 108)
        {
            SaveGame.RunScript(nameof(GenocideScript));
        }
        else if (die < 110)
        {
            SaveGame.DispelMonsters(120);
        }
        else
        {
            SaveGame.DispelMonsters(150);
            SaveGame.RunScript(nameof(SlowMonstersScript));
            SaveGame.RunScript(nameof(SleepMonstersScript));
            SaveGame.RestoreHealth(300);
        }
    }
}
