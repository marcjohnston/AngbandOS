// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class GreatOneRace : Race
{
    private GreatOneRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Great One";
    public override int[] AbilityBonus => new int[] { 1, 2, 2, 2, 3, 2 };
    public override int BaseDisarmBonus => 4;
    public override int BaseDeviceBonus => 5;
    public override int BaseSaveBonus => 5;
    public override int BaseStealthBonus => 2;
    public override int BaseSearchBonus => 3;
    public override int BaseSearchFrequency => 13;
    public override int BaseMeleeAttackBonus => 15;
    public override int BaseRangedAttackBonus => 10;
    public override int HitDieBonus => 10;
    public override int ExperienceFactor => 225;
    public override int BaseAge => 50;
    public override int AgeRange => 50;
    public override int MaleBaseHeight => 82;
    public override int MaleHeightRange => 5;
    public override int MaleBaseWeight => 190;
    public override int MaleWeightRange => 20;
    public override int FemaleBaseHeight => 78;
    public override int FemaleHeightRange => 6;
    public override int FemaleBaseWeight => 180;
    public override int FemaleWeightRange => 15;
    public override int Infravision => 0;
    public override uint Choice => 0xFFFF;
    public override string Description => "Great-Ones are the offspring of the petty gods that rule\nDreamlands. As such they are somewhat more than human.\nTheir constitution cannot be reduced, and they heal\nquickly. They can also learn to travel through dreams\n(at lvl 30) and restore their health (at lvl 40).";

    /// <summary>
    /// Great One 67->68->50->51->52->53->End 
    /// </summary>
    public override int Chart => 67;

    public override string RacialPowersDescription(int lvl) => "dream powers    (unusable until level 30/40)";
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.SustCon = true;
        itemCharacteristics.Regen = true;
    }
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new HumanSyllables());

    public override string[]? SelfKnowledge(int level)
    {
        List<string> values = new List<string>();
        if (level > 29)
        {
            values.Add("You can dream travel (cost 50).");
        }
        if (level > 39)
        {
            values.Add("You can dream a better self (cost 75).");
        }
        if (values.Count == 0)
            return null;
        return values.ToArray();
    }

    public override void CalcBonuses()
    {
        SaveGame.HasSustainConstitution = true;
        SaveGame.HasRegeneration = true;
    }

    public override void UseRacialPower()
    {
        // Great ones can heal themselves or swap to a new level
        int dreamPower;
        while (true)
        {
            if (!SaveGame.GetCom("Use Dream [T]ravel or [D]reaming? ", out char ch))
            {
                dreamPower = 0;
                break;
            }
            if (ch == 'D' || ch == 'd')
            {
                dreamPower = 1;
                break;
            }
            if (ch == 'T' || ch == 't')
            {
                dreamPower = 2;
                break;
            }
        }
        if (dreamPower == 1)
        {
            if (SaveGame.CheckIfRacialPowerWorks(40, 75, Ability.Wisdom, 50))
            {
                SaveGame.MsgPrint("You dream of a time of health and peace...");
                SaveGame.TimedPoison.ResetTimer();
                SaveGame.TimedHallucinations.ResetTimer();
                SaveGame.TimedStun.ResetTimer();
                SaveGame.TimedBleeding.ResetTimer();
                SaveGame.TimedBlindness.ResetTimer();
                SaveGame.TimedFear.ResetTimer();
                SaveGame.TryRestoringAbilityScore(Ability.Strength);
                SaveGame.TryRestoringAbilityScore(Ability.Intelligence);
                SaveGame.TryRestoringAbilityScore(Ability.Wisdom);
                SaveGame.TryRestoringAbilityScore(Ability.Dexterity);
                SaveGame.TryRestoringAbilityScore(Ability.Constitution);
                SaveGame.TryRestoringAbilityScore(Ability.Charisma);
                SaveGame.RestoreLevel();
            }
        }
        else if (dreamPower == 2)
        {
            if (SaveGame.CheckIfRacialPowerWorks(30, 50, Ability.Intelligence, 50))
            {
                SaveGame.MsgPrint("You start walking around. Your surroundings change.");
                SaveGame.DoCmdSaveGame(true);
                SaveGame.NewLevelFlag = true;
                SaveGame.CameFrom = LevelStart.StartRandom;
            }
        }
    }
}