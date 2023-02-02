using AngbandOS;

namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class MonkCharacterClass : BaseCharacterClass
    {
        private MonkCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 8;
        public override string Title => "Monk";
        public override int[] AbilityBonus => new[] { 2, -1, 1, 3, 2, 1 };
        public override int BaseDisarmBonus => 45;
        public override int BaseDeviceBonus => 32;
        public override int BaseSaveBonus => 28;
        public override int BaseStealthBonus => 5;
        public override int BaseSearchBonus => 32;
        public override int BaseSearchFrequency => 24;
        public override int BaseMeleeAttackBonus => 64;
        public override int BaseRangedAttackBonus => 50;
        public override int DisarmBonusPerLevel => 15;
        public override int DeviceBonusPerLevel => 12;
        public override int SaveBonusPerLevel => 10;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 40;
        public override int RangedAttackBonusPerLevel => 30;
        public override int HitDieBonus => 6;
        public override int ExperienceFactor => 40;

        public override string ClassSubName(Realm realm)
        {
            switch (realm)
            {
                case Realm.Corporeal:
                    return "Ascetic";

                case Realm.Tarot:
                    return "Ninja";

                case Realm.Chaos:
                    return "Street Fighter";

                default:
                    return "Monk";
            }
        }
        public override int PrimeStat => Ability.Dexterity;
        public override string[] Info => new string[] {
            "Masters of unarmed combat. While wearing only light armour",
            "they can move faster and dodge blows and can learn to",
            "resist paralysis (at lvl 25). While not wielding a weapon",
            "they have extra attacks and do increased damage. They are",
            "WIS based casters using Chaos, Tarot or Corporeal magic."
        };
        public override int SpellWeight => 300;
        public override CastingType SpellCastingType => CastingType.Divine;
        public override int SpellStat => Ability.Wisdom;
        public override int MaximumMeleeAttacksPerRound(int level) => level < 40 ? 3 : 4;
        public override int MaximumWeight => 40;
        public override int AttackSpeedMultiplier => 4;
        public override IArtifactBias? ArtifactBias => new PriestlyArtifactBias();
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(20000 / ((level * level) + 40)));
    }
}
