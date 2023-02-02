using AngbandOS;

namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class MindcrafterCharacterClass : BaseCharacterClass
    {
        private MindcrafterCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 9;
        public override string Title => "Mindcrafter";
        public override int[] AbilityBonus => new[] { -1, 0, 3, -1, -1, 2 };
        public override int BaseDisarmBonus => 30;
        public override int BaseDeviceBonus => 30;
        public override int BaseSaveBonus => 30;
        public override int BaseStealthBonus => 3;
        public override int BaseSearchBonus => 22;
        public override int BaseSearchFrequency => 16;
        public override int BaseMeleeAttackBonus => 50;
        public override int BaseRangedAttackBonus => 40;
        public override int DisarmBonusPerLevel => 10;
        public override int DeviceBonusPerLevel => 10;
        public override int SaveBonusPerLevel => 10;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 20;
        public override int RangedAttackBonusPerLevel => 30;
        public override int HitDieBonus => 2;
        public override int ExperienceFactor => 25;
        public override int PrimeStat => Ability.Wisdom;
        public override string[] Info => new string[] {
            "Disciples of the psionic arts, Mindcrafters learn a range",
            "of mental abilities; which they power using WIS. As well",
            "as their powers, they learn to resist fear (at lvl 10),",
            "prevent wis drain (at lvl 20), resist confusion",
            "(at lvl 30), and gain telepathy (at lvl 40)."
        };
        public override int SpellWeight => 300;
        public override CastingType SpellCastingType => CastingType.Mentalism;
        public override int SpellStat => Ability.Wisdom;
        public override IArtifactBias? ArtifactBias => (Program.Rng.DieRoll(5) > 2 ? new PriestlyArtifactBias() : null);
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(55000 / ((level * level) + 40)));
    }
}
