using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class SpriteRace : Race
    {
        public override string Title => "Sprite";
        public override int[] AbilityBonus => new int[] { -4, 3, 3, 3, -2, 2 };
        public override int BaseDisarmBonus => 10;
        public override int BaseDeviceBonus => 10;
        public override int BaseSaveBonus => 10;
        public override int BaseStealthBonus => 4;
        public override int BaseSearchBonus => 10;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => -12;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 7;
        public override int ExperienceFactor => 175;
        public override int BaseAge => 50;
        public override int AgeRange => 25;
        public override int MaleBaseHeight => 32;
        public override int MaleHeightRange => 2;
        public override int MaleBaseWeight => 75;
        public override int MaleWeightRange => 2;
        public override int FemaleBaseHeight => 29;
        public override int FemaleHeightRange => 2;
        public override int FemaleBaseWeight => 65;
        public override int FemaleWeightRange => 2;
        public override int Infravision => 4;
        public override uint Choice => 0xBE5E;
        public override int Index => RaceId.Sprite;
        public override string Description => "Sprites are tiny fairies, distantly related to elves. They\nshare their relatives' resistance to light based attacks,\nand their wings both protect them from falling damage and\nallow them to move progressively faster if unencumbered.\nSprites glow in the dark and can learn to throw fairy dust\nto send their enemies to sleep (at lvl 12).";

    }
}