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

        /// <summary>
        /// Returns true, if players of the character class are outfitted with scrolls of light at the start of the game.  Returns false, by default.
        /// </summary>
        public virtual bool OutfitsWithScrollsOfLight => false;

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

        public virtual CastingType SpellCastingType => SaveGame.SingletonRepository.CastingTypes.Get<CastingType>();

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

        public BaseRealm[] RemainingAvailableSecondaryRealms()
        {
            return AvailableSecondaryRealms.Where(_realm => _realm != SaveGame.Player.PrimaryRealm).ToArray();
        }

        public virtual bool WorshipsADeity => false; // TODO: Only priests have a godname ... this seems off.

        /// <summary>
        /// Returns the default deity that the character class worships.  This is used when randomly choosing a CharacterClass.  Defaults to None.
        /// </summary>
        public virtual GodName DefaultDeity(BaseRealm? realm) => GodName.None;

        /// <summary>
        /// Gains the experience when the character class destroys a spell book.  Derived classes must determine if the character class gains experience when they destroy a
        /// spell book and can call this common method to perform the gain experience.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="amount">The amount.</param>
        protected void GainExperienceFromSpellBookDestroy(BookItem item, int amount)
        {
            if (SaveGame.Player.ExperiencePoints < Constants.PyMaxExp)
            {
                int testerExp = SaveGame.Player.MaxExperienceGained / 20;
                if (testerExp > 10000)
                {
                    testerExp = 10000;
                }
                testerExp /= item.ExperienceGainDivisorForDestroying;
                if (testerExp < 1)
                {
                    testerExp = 1;
                }
                SaveGame.MsgPrint("You feel more experienced.");
                SaveGame.Player.GainExperience(testerExp * amount);
            }
        }

        /// <summary>
        /// Allows the character class to perform any additional handling when an item is destroyed.  Warriors and Paladins gain experience when specific spell books are
        /// destroyed.  Does nothing, by default.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void ItemDestroyed(Item item, int amount)
        {
        }

        /// <summary>
        /// Outfits a new player with a starting inventory.
        /// </summary>
        public virtual void OutfitPlayer()
        {
            // An an item for each item that the character classes designates the player to be outfitted with.
            foreach (ItemFactory itemClass in Outfit)
            {
                // Allow the race to modify the item as the race sees fit.
                ItemFactory outfitItem = SaveGame.Player.Race.OutfitItemClass(itemClass);
                Item item = outfitItem.CreateItem();
                if (outfitItem.CategoryEnum == ItemTypeEnum.Wand)
                {
                    item.TypeSpecificValue = 1;
                }
                item.IdentStoreb = true;
                item.BecomeFlavourAware();
                item.BecomeKnown();
                int slot = item.WieldSlot;
                if (slot == -1)
                {
                    SaveGame.Player.InvenCarry(item);
                }
                else
                {
                    SaveGame.SetInventoryItem(slot, item);
                    SaveGame.Player.WeightCarried += item.Weight;
                }

                // Allow the character class a chance to modify the item.
                OutfitItem(item);
            }
        }

        /// <summary>
        /// Represents the class of items a new player should be outfitted with.
        /// </summary>
        protected abstract ItemFactory[] Outfit { get; }

        /// <summary>
        /// During the outfit process, derived character classes can modify outfitted items.  Does nothing by default.
        /// </summary>
        /// <param name="item"></param>
        protected virtual void OutfitItem(Item item)
        {
        }

        /// <summary>
        /// Update the player bonuses for a melee weapon.
        /// </summary>
        /// <param name="oPtr"></param>
        public virtual void UpdateBonusesForMeleeWeapon(Item oPtr)
        {
        }
    }
}
