using AngbandOS.Core.Syllables;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HighElfRace : Race
    {
        public override string Title => "High Elf";
        public override int[] AbilityBonus => new int[] { 1, 3, 2, 3, 1, 5 };
        public override int BaseDisarmBonus => 4;
        public override int BaseDeviceBonus => 20;
        public override int BaseSaveBonus => 20;
        public override int BaseStealthBonus => 4;
        public override int BaseSearchBonus => 3;
        public override int BaseSearchFrequency => 14;
        public override int BaseMeleeAttackBonus => 10;
        public override int BaseRangedAttackBonus => 25;
        public override int HitDieBonus => 10;
        public override int ExperienceFactor => 200;
        public override int BaseAge => 100;
        public override int AgeRange => 30;
        public override int MaleBaseHeight => 90;
        public override int MaleHeightRange => 10;
        public override int MaleBaseWeight => 190;
        public override int MaleWeightRange => 20;
        public override int FemaleBaseHeight => 82;
        public override int FemaleHeightRange => 10;
        public override int FemaleBaseWeight => 180;
        public override int FemaleWeightRange => 15;
        public override int Infravision => 4;
        public override uint Choice => 0xBF5F;
        public override string Description => "High-Elves are the leaders of the elven race. They are\nmore magical than their lesser cousins, but retain their\naffinity with nature. High-elves resist light based attacks\nand their acute senses are able to see invisible creatures.";

        /// <summary>
        /// High-Elf 7->8->9->54->55->56->End 
        /// </summary>
        public override int Chart => 7;
        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            if (level > 19)
            {
                itemCharacteristics.SeeInvis = true;
            }
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new ElvishSyllables());
        public override void CalcBonuses(SaveGame saveGame)
        {
            saveGame.Player.HasSeeInvisibility = true;
        }
    }
}