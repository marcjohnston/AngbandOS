﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class DarkElfRace : Race
{
    private DarkElfRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Dark Elf";
    public override int[] AbilityBonus => new int[] { -1, 3, 2, 2, -2, 1 };
    public override int BaseDisarmBonus => 5;
    public override int BaseDeviceBonus => 15;
    public override int BaseSaveBonus => 20;
    public override int BaseStealthBonus => 3;
    public override int BaseSearchBonus => 8;
    public override int BaseSearchFrequency => 12;
    public override int BaseMeleeAttackBonus => -5;
    public override int BaseRangedAttackBonus => 10;
    public override int HitDieBonus => 9;
    public override int ExperienceFactor => 150;
    public override int BaseAge => 75;
    public override int AgeRange => 75;
    public override int MaleBaseHeight => 60;
    public override int MaleHeightRange => 4;
    public override int MaleBaseWeight => 100;
    public override int MaleWeightRange => 6;
    public override int FemaleBaseHeight => 54;
    public override int FemaleHeightRange => 4;
    public override int FemaleBaseWeight => 80;
    public override int FemaleWeightRange => 6;
    public override int Infravision => 5;
    public override uint Choice => 0xBFDF;
    public override string Description => "Dark elves are underground elves who have a kinship with\nfungi the way that surface elves have a kinship with trees.\nThe innately magical nature of dark elves lets them learn\nto fire magical missiles at their opponents (at lvl 2).\nThey also resist dark-based attacks and can learn to see\ninvisible creatures (at lvl 20).";

    /// <summary>
    /// Dark-Elf 68->70->71->72->73->End
    /// </summary>
    public override int Chart => 69;

    public override string RacialPowersDescription(int lvl) => lvl < 2 ? "magic missile      (racial, unusable until level 2)" : "magic missile      (racial, cost 2, INT based)";
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.ResDark = true;
    }
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new ElvishSyllables());

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 1)
        {
            return new string[] { $"You can cast a Magic Missile, dam {3 + ((level - 1) / 5)} (cost 2)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        SaveGame.HasDarkResistance = true;
        if (SaveGame.ExperienceLevel > 19)
        {
            SaveGame.HasSeeInvisibility = true;
        }
    }

    public override void UseRacialPower()
    {
        // Dark elves can cast magic missile
        if (SaveGame.CheckIfRacialPowerWorks(2, 2, Ability.Intelligence, 9))
        {
            if (SaveGame.GetDirectionWithAim(out int direction))
            {
                SaveGame.MsgPrint("You cast a magic missile.");
                SaveGame.FireBoltOrBeam(10, SaveGame.SingletonRepository.Projectiles.Get<MissileProjectile>(), direction, SaveGame.Rng.DiceRoll(3 + ((SaveGame.ExperienceLevel - 1) / 5), 4));
            }
        }
    }
}