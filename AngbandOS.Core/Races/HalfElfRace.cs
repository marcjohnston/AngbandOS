using AngbandOS.Core.Syllables;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HalfElfRace : Race
    {
        private HalfElfRace(SaveGame saveGame) : base(saveGame) { }
        public override string Title => "Half Elf";
        public override int[] AbilityBonus => new int[] { -1, 1, 1, 1, -1, 1 };
        public override int BaseDisarmBonus => 2;
        public override int BaseDeviceBonus => 3;
        public override int BaseSaveBonus => 3;
        public override int BaseStealthBonus => 1;
        public override int BaseSearchBonus => 6;
        public override int BaseSearchFrequency => 11;
        public override int BaseMeleeAttackBonus => -1;
        public override int BaseRangedAttackBonus => 5;
        public override int HitDieBonus => 9;
        public override int ExperienceFactor => 110;
        public override int BaseAge => 24;
        public override int AgeRange => 16;
        public override int MaleBaseHeight => 66;
        public override int MaleHeightRange => 6;
        public override int MaleBaseWeight => 130;
        public override int MaleWeightRange => 15;
        public override int FemaleBaseHeight => 62;
        public override int FemaleHeightRange => 6;
        public override int FemaleBaseWeight => 100;
        public override int FemaleWeightRange => 10;
        public override int Infravision => 2;
        public override uint Choice => 0xFFFF;
        public override string Description => "Half-Elves inherit better ability scores and skills from\ntheir elven parent, but none of that parent's special\nabilities. However, a half elf will advance in level more\nquickly than a full elf.";

        /// <summary>
        /// Half-Elf 4->1->2->3->50->51->52->53->End
        /// </summary>
        public override int Chart => 4;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.ResLight = true;
            itemCharacteristics.SeeInvis = true;
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new ElvishSyllables());
        public override void CalcBonuses(SaveGame saveGame)
        {
            saveGame.Player.HasLightResistance = true;
        }
    }
}