using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class DraconianRace : Race
    {
        public override string Title => "Draconian";
        public override int[] AbilityBonus => new int[] { 2, 1, 1, 1, 2, -3 };
        public override int BaseDisarmBonus => -2;
        public override int BaseDeviceBonus => 5;
        public override int BaseSaveBonus => 3;
        public override int BaseStealthBonus => 0;
        public override int BaseSearchBonus => 1;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => 5;
        public override int BaseRangedAttackBonus => 5;
        public override int HitDieBonus => 11;
        public override int ExperienceFactor => 250;
        public override int BaseAge => 75;
        public override int AgeRange => 33;
        public override int MaleBaseHeight => 76;
        public override int MaleHeightRange => 1;
        public override int MaleBaseWeight => 160;
        public override int MaleWeightRange => 5;
        public override int FemaleBaseHeight => 72;
        public override int FemaleHeightRange => 1;
        public override int FemaleBaseWeight => 130;
        public override int FemaleWeightRange => 5;
        public override int Infravision => 2;
        public override uint Choice => 0xDF57;
        public override int Index => RaceId.Draconian;
        public override string Description => "Draconians are related to dragons and this shows both in\ntheir physical superiority and their legendary arrogance.\nAs well as having a breath weapon, their wings let them\navoid falling damage, and they can learn to resist fire\n(at lvl 5), cold (at lvl 10), acid (at lvl 15), lightning\n(at lvl 20), and poison (at lvl 35).";

        /// <summary>
        /// Draconian 89->90->91->End
        /// </summary>
        public override int Chart => 89;

        public override string RacialPowersDescription(int lvl) => "breath weapon      (racial, cost lvl, dam 2*lvl, CON based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.Feather = true;
            if (level > 4)
            {
                itemCharacteristics.ResFire = true;
            }
            if (level > 9)
            {
                itemCharacteristics.ResCold = true;
            }
            if (level > 14)
            {
                itemCharacteristics.ResAcid = true;
            }
            if (level > 19)
            {
                itemCharacteristics.ResElec = true;
            }
            if (level > 34)
            {
                itemCharacteristics.ResPois = true;
            }
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new GnomishSyllables());
    }
}