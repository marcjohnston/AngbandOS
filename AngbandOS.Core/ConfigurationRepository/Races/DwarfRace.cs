﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class DwarfRace : Race
{
    private DwarfRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Dwarf";
    public override int[] AbilityBonus => new int[] { 2, -2, 2, -2, 2, -3 };
    public override int BaseDisarmBonus => 2;
    public override int BaseDeviceBonus => 9;
    public override int BaseSaveBonus => 10;
    public override int BaseStealthBonus => -1;
    public override int BaseSearchBonus => 7;
    public override int BaseSearchFrequency => 10;
    public override int BaseMeleeAttackBonus => 15;
    public override int BaseRangedAttackBonus => 0;
    public override int HitDieBonus => 11;
    public override int ExperienceFactor => 125;
    public override int BaseAge => 35;
    public override int AgeRange => 15;
    public override int MaleBaseHeight => 48;
    public override int MaleHeightRange => 3;
    public override int MaleBaseWeight => 150;
    public override int MaleWeightRange => 10;
    public override int FemaleBaseHeight => 46;
    public override int FemaleHeightRange => 3;
    public override int FemaleBaseWeight => 120;
    public override int FemaleWeightRange => 10;
    public override int Infravision => 5;
    public override uint Choice => 0x4805;
    public override string Description => "Dwarves are short and stocky, and although not noted for\ntheir intelligence or subtlety they are generally very\npious. They are also rather resistant to spells. As natural\nminers, used to feeling their way around in the dark,\ndwarves are immune to all forms of blindness and can learn\nto detect secret doors and traps (at lvl 5).";

    /// <summary>
    /// Dwarf 16->17->18->57->58->59->60->61->End
    /// </summary>
    public override int Chart => 16;
    public override string RacialPowersDescription(int lvl) => lvl < 5 ? "detect doors+traps (racial, unusable until level 5)" : "detect doors+traps (racial, cost 5, WIS based)";
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.ResBlind = true;
    }
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new DwarvenSyllables());
    public override string[]? SelfKnowledge(int level)
    {
        if (level > 4)
        {
            return new string[] { "You can find traps, doors and stairs (cost 5)." };
        }
        return null;
    }

    public override void CalcBonuses()
    {
        SaveGame.HasBlindnessResistance = true;
    }
    public override void UseRacialPower()
    {
        // Dwarves can detect traps, doors, and stairs
        if (SaveGame.CheckIfRacialPowerWorks(5, 5, Ability.Wisdom, 12))
        {
            SaveGame.MsgPrint("You examine your surroundings.");
            SaveGame.DetectTraps();
            SaveGame.DetectDoors();
            SaveGame.DetectStairs();
        }
    }
}