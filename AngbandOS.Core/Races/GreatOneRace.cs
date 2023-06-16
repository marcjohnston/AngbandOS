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

    public override void CalcBonuses(SaveGame saveGame)
    {
        saveGame.Player.HasSustainConstitution = true;
        saveGame.Player.HasRegeneration = true;
    }

    public override void UseRacialPower(SaveGame saveGame)
    {
        // Great ones can heal themselves or swap to a new level
        int dreamPower;
        while (true)
        {
            if (!saveGame.GetCom("Use Dream [T]ravel or [D]reaming? ", out char ch))
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
            if (saveGame.CheckIfRacialPowerWorks(40, 75, Ability.Wisdom, 50))
            {
                saveGame.MsgPrint("You dream of a time of health and peace...");
                saveGame.Player.TimedPoison.ResetTimer();
                saveGame.Player.TimedHallucinations.ResetTimer();
                saveGame.Player.TimedStun.ResetTimer();
                saveGame.Player.TimedBleeding.ResetTimer();
                saveGame.Player.TimedBlindness.ResetTimer();
                saveGame.Player.TimedFear.ResetTimer();
                saveGame.Player.TryRestoringAbilityScore(Ability.Strength);
                saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence);
                saveGame.Player.TryRestoringAbilityScore(Ability.Wisdom);
                saveGame.Player.TryRestoringAbilityScore(Ability.Dexterity);
                saveGame.Player.TryRestoringAbilityScore(Ability.Constitution);
                saveGame.Player.TryRestoringAbilityScore(Ability.Charisma);
                saveGame.Player.RestoreLevel();
            }
        }
        else if (dreamPower == 2)
        {
            if (saveGame.CheckIfRacialPowerWorks(30, 50, Ability.Intelligence, 50))
            {
                saveGame.MsgPrint("You start walking around. Your surroundings change.");
                saveGame.DoCmdSaveGame(true);
                saveGame.NewLevelFlag = true;
                saveGame.CameFrom = LevelStart.StartRandom;
            }
        }
    }
}