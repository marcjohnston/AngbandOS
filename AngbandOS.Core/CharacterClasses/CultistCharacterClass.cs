namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class CultistCharacterClass : BaseCharacterClass
    {
        private CultistCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 12;
        public override string Title => "Cultist";
        public override int[] AbilityBonus => new[] { -5, 4, 0, 1, -2, -2 };
        public override int BaseDisarmBonus => 30;
        public override int BaseDeviceBonus => 36;
        public override int BaseSaveBonus => 32;
        public override int BaseStealthBonus => 1;
        public override int BaseSearchBonus => 16;
        public override int BaseSearchFrequency => 18;
        public override int BaseMeleeAttackBonus => 30;
        public override int BaseRangedAttackBonus => 20;
        public override int DisarmBonusPerLevel => 7;
        public override int DeviceBonusPerLevel => 13;
        public override int SaveBonusPerLevel => 10;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 15;
        public override int RangedAttackBonusPerLevel => 15;
        public override int HitDieBonus => 0;
        public override int ExperienceFactor => 30;
        public override int PrimeStat => Ability.Intelligence;
        public override string[] Info => new string[] {
            "INT based spell casters, who use Chaos and another realm",
            "of their choice. Can't wield weapons except for powerful",
            "chaos blades. Learn to resist chaos (at lvl 20). Have a",
            "cult patron who will randomly give them rewards or",
            "punishments as they increase in level."
        };
        public override int SpellWeight => 300;
        public override CastingType SpellCastingType => CastingType.Arcane;
        public override int SpellStat => Ability.Intelligence;
        public override int MaximumMeleeAttacksPerRound(int level) => 4;
        public override int MaximumWeight => 40;
        public override int AttackSpeedMultiplier => 2;
        public override IArtifactBias? ArtifactBias => new MageArtifactBias();
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(240000 / (level + 5)));
        public override BaseRealm[] AvailablePrimaryRealms => new BaseRealm[] {
            SaveGame.SingletonRepository.Realms.Get<ChaosRealm>()
        };
        public override BaseRealm[] AvailableSecondaryRealms => new BaseRealm[] {
            SaveGame.SingletonRepository.Realms.Get<LifeRealm>(),
            SaveGame.SingletonRepository.Realms.Get<SorceryRealm>(),
            SaveGame.SingletonRepository.Realms.Get<NatureRealm>(),
            SaveGame.SingletonRepository.Realms.Get<DeathRealm>(),
            SaveGame.SingletonRepository.Realms.Get<TarotRealm>(),
            SaveGame.SingletonRepository.Realms.Get<FolkRealm>(),
            SaveGame.SingletonRepository.Realms.Get<CorporealRealm>()
        };
        public override bool WorshipsADeity => true;

        protected override ItemFactory[] Outfit => new ItemFactory[]
        {
            SaveGame.SingletonRepository.ItemFactories.Get<SorceryBookBeginnersHandbook>(),
            SaveGame.SingletonRepository.ItemFactories.Get<RingSustainIntelligence>(),
            SaveGame.SingletonRepository.ItemFactories.Get<DeathBookBlackPrayers>()
        };

        public override void UpdateBonusesForMeleeWeapon(Item? oPtr)
        {
            // Cultists that are NOT wielding the a blade of chaos lose bonuses for being an unpriestly weapon.
            if (oPtr != null)
            {
                oPtr.RefreshFlagBasedProperties();
                if (!oPtr.Characteristics.Chaotic)
                {
                    SaveGame.Player.AttackBonus -= 10;
                    SaveGame.Player.DamageBonus -= 10;
                    SaveGame.Player.DisplayedAttackBonus -= 10;
                    SaveGame.Player.DisplayedDamageBonus -= 10;
                    SaveGame.Player.HasUnpriestlyWeapon = true;
                }
            }
        }
    }
}
