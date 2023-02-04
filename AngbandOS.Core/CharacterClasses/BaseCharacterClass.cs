namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal abstract class BaseCharacterClass
    {
        protected SaveGame SaveGame { get; }
        protected BaseCharacterClass(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        /// <summary>
        /// Returns the deprecated CharacterClass constant for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public abstract int ID { get; }

        public abstract int[] AbilityBonus { get; }

        public abstract int BaseDeviceBonus { get; }

        public abstract int BaseDisarmBonus { get; }

        public abstract int BaseMeleeAttackBonus { get; }

        public abstract int BaseRangedAttackBonus { get; }

        public abstract int BaseSaveBonus { get; }

        public abstract int BaseSearchBonus { get; }

        public abstract int BaseSearchFrequency { get; }

        public abstract int BaseStealthBonus { get; }

        public abstract int DeviceBonusPerLevel { get; }

        public abstract int DisarmBonusPerLevel { get; }

        public abstract int ExperienceFactor { get; }

        public abstract int HitDieBonus { get; }

        public abstract int MeleeAttackBonusPerLevel { get; }

        public abstract int RangedAttackBonusPerLevel { get; }

        public abstract int SaveBonusPerLevel { get; }

        public abstract int SearchBonusPerLevel { get; }

        public abstract int SearchFrequencyPerLevel { get; }

        public abstract int StealthBonusPerLevel { get; }

        public abstract string Title { get; }

        public virtual string ClassSubName(BaseRealm? realm) => Title;
        public abstract int PrimeStat { get; }

        public abstract string[] Info { get; }

        /// <summary>
        /// Returns the maximum amount of armour weight that the player carry before it affects spellcasting.  Returns 0, by default.
        /// </summary>
        /// <value>The spell weight.</value>
        public virtual int SpellWeight => 0;

        public virtual CastingType SpellCastingType => CastingType.None;

        public virtual int SpellStat => Ability.Strength;

        public virtual int MaximumMeleeAttacksPerRound(int level) => 5;
        public virtual int MaximumWeight => 35;
        public virtual int AttackSpeedMultiplier => 3;
        public virtual IArtifactBias? ArtifactBias => null;
        public virtual int FromScrollWarriorArtifactBiasPercentageChance => 0;
        public virtual bool SenseInventoryTest(int level) => false;
        public virtual bool DetailedSenseInventory => false;

        /// <summary>
        /// Represents realms that are available to the character class.  Returns an empty array, if the character class cannot cast spells.
        /// </summary>
        /// <value>The available realms.</value>
        public virtual BaseRealm[] AvailablePrimaryRealms => new BaseRealm[] { };

        /// <summary>
        /// Represents realms that are available to the character class.  Returns an empty array, if the character class cannot cast spells.
        /// </summary>
        /// <value>The available realms.</value>
        public virtual BaseRealm[] AvailableSecondaryRealms => new BaseRealm[] { };

        public virtual bool WorshipsADeity => false; // TODO: Only priests have a godname ... this seems off.
    }
}
