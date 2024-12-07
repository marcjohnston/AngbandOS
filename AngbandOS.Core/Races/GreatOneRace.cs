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
    private GreatOneRace(Game game) : base(game) { }
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
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new HumanSyllableSet());

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
        Game.HasSustainConstitution = true;
        Game.HasRegeneration = true;
    }

    public override void UseRacialPower()
    {
        // Great ones can heal themselves or swap to a new level
        int dreamPower;
        while (true)
        {
            if (!Game.GetCom("Use Dream [T]ravel or [D]reaming? ", out char ch))
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
            if (Game.CheckIfRacialPowerWorks(40, 75, AbilityEnum.Wisdom, 50))
            {
                Game.MsgPrint("You dream of a time of health and peace...");
                Game.PoisonTimer.ResetTimer();
                Game.HallucinationsTimer.ResetTimer();
                Game.StunTimer.ResetTimer();
                Game.BleedingTimer.ResetTimer();
                Game.BlindnessTimer.ResetTimer();
                Game.FearTimer.ResetTimer();
                Game.TryRestoringAbilityScore(AbilityEnum.Strength);
                Game.TryRestoringAbilityScore(AbilityEnum.Intelligence);
                Game.TryRestoringAbilityScore(AbilityEnum.Wisdom);
                Game.TryRestoringAbilityScore(AbilityEnum.Dexterity);
                Game.TryRestoringAbilityScore(AbilityEnum.Constitution);
                Game.TryRestoringAbilityScore(AbilityEnum.Charisma);
                Game.RunScript(nameof(RestoreLevelScript));
            }
        }
        else if (dreamPower == 2)
        {
            if (Game.CheckIfRacialPowerWorks(30, 50, AbilityEnum.Intelligence, 50))
            {
                Game.MsgPrint("You start walking around. Your surroundings change.");
                Game.DoCmdSaveGame(true);
                Game.NewLevelFlag = true;
                Game.CameFrom = LevelStartEnum.StartRandom;
            }
        }
    }
}