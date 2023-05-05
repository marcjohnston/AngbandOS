namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class HighMageCharacterClass : BaseCharacterClass
    {
        private HighMageCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 10;
        public override string Title => "High-Mage";
        public override int[] AbilityBonus => new[] { -5, 4, 0, 0, -2, 1 };
        public override int BaseDisarmBonus => 30;
        public override int BaseDeviceBonus => 38;
        public override int BaseSaveBonus => 30;
        public override int BaseStealthBonus => 2;
        public override int BaseSearchBonus => 16;
        public override int BaseSearchFrequency => 20;
        public override int BaseMeleeAttackBonus => 34;
        public override int BaseRangedAttackBonus => 20;
        public override int DisarmBonusPerLevel => 7;
        public override int DeviceBonusPerLevel => 13;
        public override int SaveBonusPerLevel => 9;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 15;
        public override int RangedAttackBonusPerLevel => 15;
        public override int HitDieBonus => 0;
        public override int ExperienceFactor => 30;

        public override string ClassSubName(BaseRealm? realm)
        {
            switch (realm)
            {
                case LifeRealm:
                    return "Vivimancer";

                case SorceryRealm:
                    return "Sorcerer";

                case NatureRealm:
                    return "Naturist";

                case ChaosRealm:
                    return "Warlock";

                case DeathRealm:
                    return "Necromancer";

                case TarotRealm:
                    return "Summoner";

                case FolkRealm:
                    return "Hedge Wizard";

                case CorporealRealm:
                    return "Zen Master";

                default:
                    return "High Mage";
            }
        }
        public override int PrimeStat => Ability.Intelligence;
        public override string[] Info => new string[] {
            "INT based spell casters who specialise in a single realm",
            "of magic. They may choose any realm, and are better at",
            "casting spells from that realm than a normal mage. High",
            "mages also get more mana than other spell casters do.",
            "Wearing too much armour disrupts their casting."
        };
        public override int SpellWeight => 300;
        public override CastingType SpellCastingType => CastingType.Arcane;
        public override int SpellStat => Ability.Intelligence;
        public override int MaximumMeleeAttacksPerRound(int level) => 4;
        public override int MaximumWeight => 40;
        public override int AttackSpeedMultiplier => 2;
        public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get<MageArtifactBias>();
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(240000 / (level + 5)));
        public override BaseRealm[] AvailablePrimaryRealms => new BaseRealm[] {
            SaveGame.SingletonRepository.Realms.Get<LifeRealm>(),
            SaveGame.SingletonRepository.Realms.Get<SorceryRealm>(),
            SaveGame.SingletonRepository.Realms.Get<NatureRealm>(),
            SaveGame.SingletonRepository.Realms.Get<ChaosRealm>(),
            SaveGame.SingletonRepository.Realms.Get<DeathRealm>(),
            SaveGame.SingletonRepository.Realms.Get<TarotRealm>(),
            SaveGame.SingletonRepository.Realms.Get<FolkRealm>(),
            SaveGame.SingletonRepository.Realms.Get<CorporealRealm>()
        };

        protected override ItemFactory[] Outfit => new ItemFactory[]
        {
            SaveGame.SingletonRepository.ItemFactories.Get<BeginnersHandbookSorceryBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<SwordDagger>(),
            SaveGame.SingletonRepository.ItemFactories.Get<SustainIntelligenceRingItemFactory>()
        };
    }
}
