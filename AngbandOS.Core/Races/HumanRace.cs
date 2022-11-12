using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HumanRace : Race
    {
        public override string Title => "Human";
        public override int[] AbilityBonus => new int[] { 0, 0, 0, 0, 0, 0 };
        public override int BaseDisarmBonus => 0;
        public override int BaseDeviceBonus => 0;
        public override int BaseSaveBonus => 0;
        public override int BaseStealthBonus => 0;
        public override int BaseSearchBonus => 0;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => 0;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 10;
        public override int ExperienceFactor => 100;
        public override int BaseAge => 14;
        public override int AgeRange => 6;
        public override int MaleBaseHeight => 72;
        public override int MaleHeightRange => 6;
        public override int MaleBaseWeight => 180;
        public override int MaleWeightRange => 25;
        public override int FemaleBaseHeight => 66;
        public override int FemaleHeightRange => 4;
        public override int FemaleBaseWeight => 150;
        public override int FemaleWeightRange => 20;
        public override int Infravision => 0;
        public override uint Choice => 0xFFFF;
        public override int Index => RaceId.Human;
        public override string Description => "Hopefully you know all about humans already because you\nare one! In game terms, humans are the average around which\nthe other races are measured. As such, humans get no\nspecial abilities, but they increase in level quicker than\nany other race. Humans are recommended for new players.";

        /// <summary>
        /// Human 1->2->3->50->51->52->53->End
        /// </summary>
        public override int Chart => 1;
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new HumanSyllables());
    }
}