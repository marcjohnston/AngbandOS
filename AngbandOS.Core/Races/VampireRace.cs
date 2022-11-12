using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class VampireRace : Race
    {
        public override string Title => "Vampire";
        public override int[] AbilityBonus => new int[] { 3, 3, -1, -1, 1, 2 };
        public override int BaseDisarmBonus => 4;
        public override int BaseDeviceBonus => 10;
        public override int BaseSaveBonus => 10;
        public override int BaseStealthBonus => 4;
        public override int BaseSearchBonus => 1;
        public override int BaseSearchFrequency => 8;
        public override int BaseMeleeAttackBonus => 5;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 11;
        public override int ExperienceFactor => 200;
        public override int BaseAge => 100;
        public override int AgeRange => 30;
        public override int MaleBaseHeight => 72;
        public override int MaleHeightRange => 6;
        public override int MaleBaseWeight => 180;
        public override int MaleWeightRange => 25;
        public override int FemaleBaseHeight => 66;
        public override int FemaleHeightRange => 4;
        public override int FemaleBaseWeight => 150;
        public override int FemaleWeightRange => 20;
        public override int Infravision => 5;
        public override uint Choice => 0xFFFF;
        public override int Index => RaceId.Vampire;
        public override string Description => "Vampires are powerful undead. They resist darkness, nether,\ncold, poison, and having their life force drained. Vampires\nproduce their own ethereal light in the dark, but are hurt\nby direct sunlight. They can learn to drain the life force\nfrom their foes (at lvl 2).";

        /// <summary>
        /// Vampire 113->114->115->116->117->End
        /// </summary>
        public override int Chart => 113;

        public override string RacialPowersDescription(int lvl) => lvl < 2 ? "drain life         (racial, unusable until level 2)" : "drain life         (racial, cost 1 + lvl/3, based)";
        public override bool HasRacialPowers => true;
        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.HoldLife = true;
            itemCharacteristics.ResDark = true;
            itemCharacteristics.ResNether = true;
            itemCharacteristics.Lightsource = true;
            itemCharacteristics.ResPois = true;
            itemCharacteristics.ResCold = true;
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new HumanSyllables());

        public override string[]? SelfKnowledge(int level)
        {
            if (level > 1)
            {
                return new string[] { $"You can steal life from a foe, dam. {level + Math.Max(1, level / 10)}-{level + (level * Math.Max(1, level / 10))} (cost {1 + (level / 3)})." };
            }
            return null;
        }
        public override void CalcBonuses(SaveGame saveGame)
        {
            saveGame.Player.HasDarkResistance = true;
            saveGame.Player.HasHoldLife = true;
            saveGame.Player.HasNetherResistance = true;
            saveGame.Player.HasColdResistance = true;
            saveGame.Player.HasPoisonResistance = true;
            saveGame.Player.HasGlow = true;
        }
        public override bool RestsTillDuskInsteadOfDawn => true;
    }
}