// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class HalfOrcRace : Race
{
    private HalfOrcRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Half Orc";
    public override int[] AbilityBonus => new int[] { 2, -1, 0, 0, 1, -4 };
    public override int BaseDisarmBonus => -3;
    public override int BaseDeviceBonus => -3;
    public override int BaseSaveBonus => -3;
    public override int BaseStealthBonus => -1;
    public override int BaseSearchBonus => 0;
    public override int BaseSearchFrequency => 7;
    public override int BaseMeleeAttackBonus => 12;
    public override int BaseRangedAttackBonus => -5;
    public override int HitDieBonus => 10;
    public override int ExperienceFactor => 110;
    public override int BaseAge => 11;
    public override int AgeRange => 4;
    public override int MaleBaseHeight => 66;
    public override int MaleHeightRange => 1;
    public override int MaleBaseWeight => 150;
    public override int MaleWeightRange => 5;
    public override int FemaleBaseHeight => 62;
    public override int FemaleHeightRange => 1;
    public override int FemaleBaseWeight => 120;
    public override int FemaleWeightRange => 5;
    public override int Infravision => 3;
    public override uint Choice => 0x898D;
    public override string Description => "Half-Orcs are stronger than humans, and less dimwitted\ntheir orcish parentage would lead you to assume.\nHalf-Orcs are born of darkness and are resistant to that\nform of attack. They are also able to learn to shrug off\nmagical fear (at lvl 5).";

    /// <summary>
    /// Half-Orc 19->20->2->3->50->51->52->53->End
    /// </summary>
    public override int Chart => 19;

    public override string RacialPowersDescription(int lvl) => lvl < 3 ? "remove fear        (racial, unusable until level 3)" : "remove fear        (racial, cost 5, WIS based)";
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.ResDark = true;
    }
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new OrcishSyllables());

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 2)
        {
            return new string[] { "You can remove fear (cost 5)." };
        }
        return null;
    }

    public override void CalcBonuses(SaveGame saveGame)
    {
        saveGame.HasDarkResistance = true;
    }

    public override void UseRacialPower(SaveGame saveGame)
    {
        // Half-orcs can remove fear
        if (saveGame.CheckIfRacialPowerWorks(3, 5, Ability.Wisdom, saveGame.BaseCharacterClass.ID == CharacterClass.Warrior ? 5 : 10))
        {
            saveGame.MsgPrint("You play tough.");
            saveGame.TimedFear.ResetTimer();
        }
    }
}