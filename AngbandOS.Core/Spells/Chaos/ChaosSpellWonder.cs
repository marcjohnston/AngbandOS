// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellWonder : Spell
{
    private ChaosSpellWonder(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        int beam;
        switch (SaveGame.Player.BaseCharacterClass.ID)
        {
            case CharacterClass.Mage:
                beam = SaveGame.Player.ExperienceLevel;
                break;

            case CharacterClass.HighMage:
                beam = SaveGame.Player.ExperienceLevel + 10;
                break;

            default:
                beam = SaveGame.Player.ExperienceLevel / 2;
                break;
        }
        int die = Program.Rng.DieRoll(100) + (SaveGame.Player.ExperienceLevel / 5);
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
            SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get<MissileProjectile>(), dir,
                Program.Rng.DiceRoll(3 + ((SaveGame.Player.ExperienceLevel - 1) / 5), 4));
        }
        else if (die < 41)
        {
            SaveGame.ConfuseMonster(dir, SaveGame.Player.ExperienceLevel);
        }
        else if (die < 46)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<PoisProjectile>(), dir, 20 + (SaveGame.Player.ExperienceLevel / 2), 3);
        }
        else if (die < 51)
        {
            SaveGame.LightLine(dir);
        }
        else if (die < 56)
        {
            SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), dir,
                Program.Rng.DiceRoll(3 + ((SaveGame.Player.ExperienceLevel - 5) / 4), 8));
        }
        else if (die < 61)
        {
            SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir,
                Program.Rng.DiceRoll(5 + ((SaveGame.Player.ExperienceLevel - 5) / 4), 8));
        }
        else if (die < 66)
        {
            SaveGame.FireBoltOrBeam(beam, SaveGame.SingletonRepository.Projectiles.Get<AcidProjectile>(), dir,
                Program.Rng.DiceRoll(6 + ((SaveGame.Player.ExperienceLevel - 5) / 4), 8));
        }
        else if (die < 71)
        {
            SaveGame.FireBoltOrBeam(beam, SaveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir,
                Program.Rng.DiceRoll(8 + ((SaveGame.Player.ExperienceLevel - 5) / 4), 8));
        }
        else if (die < 76)
        {
            SaveGame.DrainLife(dir, 75);
        }
        else if (die < 81)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), dir, 30 + (SaveGame.Player.ExperienceLevel / 2), 2);
        }
        else if (die < 86)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<AcidProjectile>(), dir, 40 + SaveGame.Player.ExperienceLevel, 2);
        }
        else if (die < 91)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<IceProjectile>(), dir, 70 + SaveGame.Player.ExperienceLevel, 3);
        }
        else if (die < 96)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, 80 + SaveGame.Player.ExperienceLevel, 3);
        }
        else if (die < 101)
        {
            SaveGame.DrainLife(dir, 100 + SaveGame.Player.ExperienceLevel);
        }
        else if (die < 104)
        {
            SaveGame.Earthquake(SaveGame.Player.MapY, SaveGame.Player.MapX, 12);
        }
        else if (die < 106)
        {
            SaveGame.DestroyArea(SaveGame.Player.MapY, SaveGame.Player.MapX, 15);
        }
        else if (die < 108)
        {
            SaveGame.Carnage(true);
        }
        else if (die < 110)
        {
            SaveGame.DispelMonsters(120);
        }
        else
        {
            SaveGame.DispelMonsters(150);
            SaveGame.SlowMonsters();
            SaveGame.SleepMonsters();
            SaveGame.Player.RestoreHealth(300);
        }
    }
    public override void CastFailed()
    {
        DoWildChaoticMagic(8);
    }


    public override string Name => "Wonder";
    
    protected override string? Info()
    {
        return "random";
    }
}