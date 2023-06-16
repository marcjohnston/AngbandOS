namespace AngbandOS.Core.Races;

[Serializable]
internal class MiriNigriRace : Race
{
    private MiriNigriRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Miri Nigri";
    public override int[] AbilityBonus => new int[] { 2, -2, -1, -1, 2, -4 };
    public override int BaseDisarmBonus => -5;
    public override int BaseDeviceBonus => -2;
    public override int BaseSaveBonus => -1;
    public override int BaseStealthBonus => -1;
    public override int BaseSearchBonus => -1;
    public override int BaseSearchFrequency => 5;
    public override int BaseMeleeAttackBonus => 12;
    public override int BaseRangedAttackBonus => 5;
    public override int HitDieBonus => 11;
    public override int ExperienceFactor => 140;
    public override int BaseAge => 14;
    public override int AgeRange => 6;
    public override int MaleBaseHeight => 65;
    public override int MaleHeightRange => 6;
    public override int MaleBaseWeight => 150;
    public override int MaleWeightRange => 20;
    public override int FemaleBaseHeight => 61;
    public override int FemaleHeightRange => 6;
    public override int FemaleBaseWeight => 120;
    public override int FemaleWeightRange => 15;
    public override int Infravision => 0;
    public override uint Choice => 0xDFCF;
    public override string Description => "Miri-Nigri are squat, toad-like chaos beasts. Their\nclose ties to chaos render them resistant to sound and\nimmune to confusion. However, their chaotic nature also\nmakes them prone to random mutation. Also, the outer gods\npay special attention to miri-nigri servants and they\nare more likely to interfere with them for good or ill.";

    /// <summary>
    /// Miri-Nigri 129->130->131->132->133->End
    /// </summary>
    public override int Chart => 129;

    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.ResSound = true;
        itemCharacteristics.ResConf = true;
    }
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new CthuloidSyllables());
    public override void CalcBonuses(SaveGame saveGame)
    {
        saveGame.Player.HasConfusionResistance = true;
        saveGame.Player.HasSoundResistance = true;
    }

    public override bool AutomaticallyGainsFirstLevelMutationAtBirth => true;
}