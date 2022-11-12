using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class SkeletonRace : Race
    {
        public override string Title => "Skeleton";
        public override int[] AbilityBonus => new int[] { 0, -2, -2, 0, 1, -4 };
        public override int BaseDisarmBonus => -5;
        public override int BaseDeviceBonus => -5;
        public override int BaseSaveBonus => 5;
        public override int BaseStealthBonus => -1;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 8;
        public override int BaseMeleeAttackBonus => 10;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 10;
        public override int ExperienceFactor => 145;
        public override int BaseAge => 100;
        public override int AgeRange => 35;
        public override int MaleBaseHeight => 72;
        public override int MaleHeightRange => 6;
        public override int MaleBaseWeight => 50;
        public override int MaleWeightRange => 5;
        public override int FemaleBaseHeight => 66;
        public override int FemaleHeightRange => 4;
        public override int FemaleBaseWeight => 50;
        public override int FemaleWeightRange => 5;
        public override int Infravision => 2;
        public override uint Choice => 0x5F0F;
        public override int Index => RaceId.Skeleton;
        public override string Description => "Skeletons are undead creatures. Being without eyes, they\nuse magical sight which can see invisible creatures. Their\nlack of flesh means that they resist poison and shards, and\ntheir life force is hard to drain. They can learn to resist\ncold (at lvl 10), and restore their life force (at lvl 30).";

        /// <summary>
        /// Skeleton 102->103->104->105->106->End
        /// </summary>
        public override int Chart => 102;
        public override string RacialPowersDescription(int lvl) => lvl < 30 ? "restore life       (racial, unusable until level 30)" : "restore life       (racial, cost 30, WIS based)";
        public override bool HasRacialPowers => true;
        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.SeeInvis = true;
            itemCharacteristics.ResShards = true;
            itemCharacteristics.HoldLife = true;
            itemCharacteristics.ResPois = true;
            if (level > 9)
            {
                itemCharacteristics.ResCold = true;
            }
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new HumanSyllables());
        public override string[]? SelfKnowledge(int level)
        {
            if (level > 29)
            {
                return new string[] { "You can restore lost life forces (cost 30)." };
            }
            return null;
        }
        public override void CalcBonuses(SaveGame saveGame)
        {
            saveGame.Player.HasShardResistance = true;
            saveGame.Player.HasHoldLife = true;
            saveGame.Player.HasSeeInvisibility = true;
            saveGame.Player.HasPoisonResistance = true;
            if (saveGame.Player.Level > 9)
            {
                saveGame.Player.HasColdResistance = true;
            }
        }
        public override bool RestsTillDuskInsteadOfDawn => true;
    }
}