namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class PaladinCharacterClass : BaseCharacterClass
    {
        private PaladinCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 5;
        public override string Title => "Paladin";
        public override int[] AbilityBonus => new[] { 3, -3, 1, 0, 2, 2 };
        public override int BaseDisarmBonus => 20;
        public override int BaseDeviceBonus => 24;
        public override int BaseSaveBonus => 26;
        public override int BaseStealthBonus => 1;
        public override int BaseSearchBonus => 12;
        public override int BaseSearchFrequency => 2;
        public override int BaseMeleeAttackBonus => 68;
        public override int BaseRangedAttackBonus => 40;
        public override int DisarmBonusPerLevel => 7;
        public override int DeviceBonusPerLevel => 10;
        public override int SaveBonusPerLevel => 11;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 35;
        public override int RangedAttackBonusPerLevel => 30;
        public override int HitDieBonus => 6;
        public override int ExperienceFactor => 35;

        public override string ClassSubName(BaseRealm? realm)
        {
            switch (realm)
            {
                case DeathRealm:
                    return "Death Knight";
                default:
                    return "Paladin";
            }
        }
        public override int PrimeStat => Ability.Wisdom;
        public override string[] Info => new string[] {
            "Holy warriors who use WIS based spell casting to supplement",
            "their fighting skills. Paladins can specialise in either",
            "Life or Death magic, but their spell casting is weak in",
            "comparison to a full priest. Paladins learn to resist fear",
            "(at lvl 40)."
        };
        public override int SpellWeight => 400;
        public override CastingType SpellCastingType => SaveGame.SingletonRepository.CastingTypes.Get<DivineCastingType>();
        public override int SpellStat => Ability.Wisdom;
        public override int MaximumWeight => 30;
        public override int AttackSpeedMultiplier => 4;
        public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get<PriestlyArtifactBias>();
        public override int FromScrollWarriorArtifactBiasPercentageChance => 40;
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(77777 / ((level * level) + 40)));
        public override bool DetailedSenseInventory => true;
        public override BaseRealm[] AvailablePrimaryRealms => new BaseRealm[] {
            SaveGame.SingletonRepository.Realms.Get<LifeRealm>(),
            SaveGame.SingletonRepository.Realms.Get<DeathRealm>()
        };

        public override void ItemDestroyed(Item item, int amount)
        {
            // Warriors and paladins get experience for destroying magic books
            if (SaveGame.ItemFilterHighLevelBook(item))
            {
                BookItem bookItem = (BookItem)item;
                if (SaveGame.Player.Studies<LifeRealm>())
                {
                    if (item.Category == ItemTypeEnum.DeathBook)
                    {
                        GainExperienceFromSpellBookDestroy(bookItem, amount);
                    }
                }
                else
                {
                    if (item.Category == ItemTypeEnum.LifeBook)
                    {
                        GainExperienceFromSpellBookDestroy(bookItem, amount);
                    }
                }
            }
        }

        protected override ItemFactory[] Outfit => new ItemFactory[]
        {
            SaveGame.SingletonRepository.ItemFactories.Get<BeginnersHandbookSorceryBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<SwordBroadSword>(),
            SaveGame.SingletonRepository.ItemFactories.Get<ScrollProtectionFromEvil>()
        };
    }
}
