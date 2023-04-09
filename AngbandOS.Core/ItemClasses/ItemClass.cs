namespace AngbandOS.Core.ItemClasses
{
    /// <summary>
    /// Represents different variations (ItemType) of item categories (ItemCategory).  E.g. different types of food that belong to the food category.  Several of the
    /// properties are modifyable.
    /// </summary>
    [Serializable]

    internal abstract class ItemClass
    {
        public virtual bool InstaArt => false;
        public SaveGame SaveGame { get; }

        public ItemClass(SaveGame saveGame)
        {
            SaveGame = saveGame;
            FlavorCharacter = Character;
            FlavorColour = Colour;
        }

        /// <summary>
        /// Returns the item type to use when creating an item of this category.
        /// </summary>
        public abstract Item CreateItem(SaveGame saveGame);

        /// <summary>
        /// Returns the inventory slot where the item is wielded.  Returns the pack, by default.
        /// </summary>
        public virtual BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<PackInventorySlot>();

        /// <summary>
        /// Returns true, if items of this type are stompable (based on the known "feeling" of (Broken, Average, Good & Excellent)).
        /// Use StompableType enum to address each index.
        /// </summary>
        public readonly bool[] Stompable = new bool[4];

        /// <summary>
        /// The special flavor of the item has been identified. (e.g. "of seeing")
        /// </summary>
        public bool FlavourAware;

        /// <summary>
        /// Returns the character to be displayed for items of this type.  This character is initially set from the BaseItemCategory, but item categories
        /// that have flavor may override this character and replace it with a different character from the flavor.
        /// </summary>
        public char FlavorCharacter;

        /// <summary>
        /// Returns the color to be used for items of this type.  This color is initially set from the BaseItemCategory, but item categories
        /// that have flavor may override this color and replace it with a different color from the flavor.
        /// </summary>
        public Colour FlavorColour;

        /// <summary>
        /// Returns true, if the object has quality.  Returns false, by default.  Armour, weapons and orbs of light return true.  All others types return false.
        /// </summary>
        public virtual bool HasQuality => false;

        /// <summary>
        /// Returns true, if the object type has flavors.  Returns false, by default.
        /// </summary>
        public virtual bool HasFlavor => false;

        /// <summary>
        /// Returns true, if the player has attempted/tried the item.
        /// </summary>
        public bool Tried;

        /// <summary>
        /// Returns the character to be used when displaying items of this category.  This character will be initially used to set the FlavorCharacter and item
        /// categories that have flavor may change the FlavorCharacter based on the flavor.
        /// </summary>
        public abstract char Character { get; }

        /// <summary>
        /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the FlavorColor and item categories
        /// that have flavor may change the FlavorColor based on the flavor.
        /// </summary>
        public virtual Colour Colour => Colour.White;

        /// <summary>
        /// A unique identifier for the entity
        /// </summary>
        public abstract string Name { get; }

        public virtual int Ac => 0;
        public virtual int[] Chance => new int[] { 0, 0, 0, 0 };

        public virtual int Cost => 0;
        public virtual int Dd => 0;

        public virtual int Ds => 0;
        public abstract string FriendlyName { get; }

        public virtual bool KindIsGood => false;
        public virtual int Level => 0;
        public virtual int[] Locale => new int[] { 0, 0, 0, 0 };
        public virtual int Pval => 0;


        /// <summary>
        /// Returns the subcategory enumeration that the item belongs to.  This property is to be deleted.  Returns null, when not in use.
        /// </summary>
        public abstract int? SubCategory { get; }

        public virtual int ToA => 0;
        public virtual int ToD => 0;
        public virtual int ToH => 0;

        public virtual int Weight => 0;


        /// <summary>
        /// Returns the ItemCategoryEnum value for backwards compatibility.  This property will be deleted.
        /// </summary>
        public virtual ItemTypeEnum CategoryEnum { get; }

        /// <summary>
        /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool CanApplySlayingBonus => false;

        /// <summary>
        /// Returns true, if the item can be stomped.  Returns the stompable status based on the item "Feeling", by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool IsStompable(Item item)
        {
            if (item.ItemFactory.HasQuality)
            {
                switch (item.GetDetailedFeeling())
                {
                    case "terrible":
                    case "worthless":
                    case "cursed":
                    case "broken":
                        return item.ItemFactory.Stompable[StompableType.Broken];

                    case "average":
                        return item.ItemFactory.Stompable[StompableType.Average];

                    case "good":
                        return item.ItemFactory.Stompable[StompableType.Good];

                    case "excellent":
                        return item.ItemFactory.Stompable[StompableType.Excellent];

                    case "special":
                        return false;

                    default:
                        throw new InvalidDataException($"Unrecognised item quality ({item.GetDetailedFeeling()})");
                }
            }
            return item.ItemFactory.Stompable[StompableType.Broken];
        }

        //    public virtual bool CanSlay => false;

        /// <summary>
        /// Returns the number of additional items to be produced, when the item is mass produced for a store.  Returns 0, by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int GetAdditionalMassProduceCount(Item item) => 0;

        protected int MassRoll(int num, int max)
        {
            int t = 0;
            for (int i = 0; i < num; i++)
            {
                t += Program.Rng.RandomLessThan(max);
            }
            return t;
        }

        /// <summary>
        /// Returns a description for the item.  Returns a macro processed description, by default.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="includeCountPrefix">Specify true, to include the number of items as the prefix; false, to excluse the count.  Pluralization will still
        /// occur when the count is not included.</param>
        /// <returns></returns>
        public virtual string GetDescription(Item item, bool includeCountPrefix)
        {
            string pluralizedName = ApplyPlurizationMacro(item.ItemFactory.FriendlyName, item.Count);
            return ApplyGetPrefixCountMacro(includeCountPrefix, pluralizedName, item.Count, item.IsKnownArtifact);
        }

        /// <summary>
        /// Returns an additional description of the item that is appended to the base description, when needed.  Returns string.empty by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual string GetDetailedDescription(Item item)
        {
            string s = "";
            if (item.IsKnown())
            {
                item.RefreshFlagBasedProperties();
                if (item.ShowMods || item.BonusToHit != 0 && item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";
                }
                else if (item.BonusToHit != 0)
                {
                    s += $" ({GetSignedValue(item.BonusToHit)})";
                }
                else if (item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusDamage)})";
                }

                if (item.BaseArmourClass != 0)
                {
                    // Add base armour class for all types of armour and when the base armour class is greater than zero.
                    s += $" [{item.BaseArmourClass},{GetSignedValue(item.BonusArmourClass)}]";
                }
                else if (item.BonusArmourClass != 0)
                {
                    // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.BonusArmourClass)}]";
                }
            }
            return s;
        }

        /// <summary>
        /// Returns an additional description of the item that is appended to the detailed description, when needed.  
        /// By default, empty is returned, if the item is known; otherwise, the HideType, Speed, Blows, Stealth, Search, Infra, Tunnel and recharging time characteristics are returned.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual string GetVerboseDescription(Item item)
        {
            string s = "";
            item.RefreshFlagBasedProperties();
            if (item.IsKnown() && item.HasAnyPvalMask)
            {
                s += $" ({GetSignedValue(item.TypeSpecificValue)}";
                if (item.HideType)
                {
                }
                else if (item.Speed)
                {
                    s += " speed";
                }
                else if (item.Blows)
                {
                    if (item.TypeSpecificValue > 1)
                    {
                        s += " attacks";
                    }
                    else
                    {
                        s += " attack";
                    }
                }
                else if (item.Stealth)
                {
                    s += " stealth";
                }
                else if (item.Search)
                {
                    s += " searching";
                }
                else if (item.Infra)
                {
                    s += " infravision";
                }
                else if (item.Tunnel)
                {
                }
                s += ")";
            }
            if (item.IsKnown() && item.RechargeTimeLeft != 0)
            {
                s += " (charging)";
            }
            return s;
        }

        /// <summary>
        /// Returns an additional description to fully identify the item that is appended to the verbode description, when needed.  
        /// By default, returns the description for inscriptions, cursed, empty, tried and on discount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual string GetFullDescription(Item item)
        {
            string tmpVal2 = "";
            if (!string.IsNullOrEmpty(item.Inscription))
            {
                tmpVal2 = item.Inscription;
            }
            else if (item.IsCursed() && (item.IsKnown() || item.IdentSense))
            {
                tmpVal2 = "cursed";
            }
            else if (!item.IsKnown() && item.IdentEmpty)
            {
                tmpVal2 = "empty";
            }
            else if (!item.IsFlavourAware() && item.ItemFactory.Tried)
            {
                tmpVal2 = "tried";
            }
            else if (item.Discount != 0)
            {
                tmpVal2 = item.Discount.ToString();
                tmpVal2 += "% off";
            }
            if (!string.IsNullOrEmpty(tmpVal2))
            {
                tmpVal2 = $" {{{tmpVal2}}}";
            }
            return tmpVal2;
        }

        /// <summary>
        /// Gets an additional bonus gold real value associated with the item.  Returns 0, by default.  Returns null, if the item is worthless.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int? GetBonusRealValue(Item item, int value) => 0;
        public virtual int? GetTypeSpecificRealValue(Item item, int value) => 0;

        /// <summary>
        /// Provides base functionality for the type specific real value.  Returns a real value for the type specific characteristics of the item.  Returns
        /// null, if the item is worthless.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected int? ComputeTypeSpecificRealValue(Item item, int value)
        {
            if (item.TypeSpecificValue < 0)
            {
                return null; // Worthless
            }

            if (item.TypeSpecificValue == 0)
            {
                return 0;
            }

            int bonusValue = 0;
            item.RefreshFlagBasedProperties();
            if (item.Characteristics.Str)
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (item.Characteristics.Int)
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (item.Characteristics.Wis)
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (item.Characteristics.Dex)
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (item.Characteristics.Con)
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (item.Characteristics.Cha)
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (item.Characteristics.Stealth)
            {
                bonusValue += item.TypeSpecificValue * 100;
            }
            if (item.Characteristics.Search)
            {
                bonusValue += item.TypeSpecificValue * 100;
            }
            if (item.Characteristics.Infra)
            {
                bonusValue += item.TypeSpecificValue * 50;
            }
            if (item.Characteristics.Tunnel)
            {
                bonusValue += item.TypeSpecificValue * 50;
            }
            if (item.Characteristics.Blows)
            {
                bonusValue += item.TypeSpecificValue * 5000;
            }
            if (item.Characteristics.Speed)
            {
                bonusValue += item.TypeSpecificValue * 3000;
            }
            return bonusValue;
        }

        /// <summary>
        /// Returns true, if the item is deemed as worthless.  Worthless items will ignore their RealValue and will always have 0 real value.  Returns false by default.
        /// </summary>
        public virtual bool IsWorthless(Item item) => false;

        /// <summary>
        /// Returns a description of the items' activation.  Returns null by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual string DescribeActivationEffect(Item item)
        {
            return null;
        }

        /// <summary>
        /// Returns an additional description when identified fully.  Returns null by default.  Only light sources provide an additional description.
        /// </summary>
        public virtual string Identify(Item item) => null;

        /// <summary>
        /// Returns the base value for a non flavor-aware item.  Returns 0, by default.
        /// </summary>
        public virtual int BaseValue => 0;

        /// <summary>
        /// Returns true, if the item is susceptible to electricity.  Returns false, by default.
        /// </summary>
        public virtual bool HatesElectricity => false;

        /// <summary>
        /// Returns true, if the item is susceptible to fire.  Returns false, by default.
        /// </summary>
        public virtual bool HatesFire => false;

        /// <summary>
        /// Returns true, if the item is susceptible to acid.  Returns false, by default.
        /// </summary>
        public virtual bool HatesAcid => false;

        /// <summary>
        /// Returns true, if the item is susceptible to cold.  Returns false, by default.
        /// </summary>
        public virtual bool HatesCold => false;

        /// <summary>
        /// Applies magic to the item.  Does nothing, by default.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public virtual void ApplyMagic(Item item, int level, int power)
        {
        }

        /// <summary>
        /// Returns true, if an item can absorb another item of the same type.  Returns false, by default, if either item is known.
        /// </summary>
        public virtual bool CanAbsorb(Item item, Item other)
        {
            if (!item.IsKnown() || !other.IsKnown())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true, if the item can provide a sheath of electricity.  Returns false, by default.  Cloaks, soft and hard armor return true.
        /// </summary>
        public virtual bool CanProvideSheathOfElectricity => false;

        /// <summary>
        /// Returns true, if the item can provide a sheath of fire.  Returns false, by default.  Cloaks, soft and hard armor return true.
        /// </summary>
        public virtual bool CanProvideSheathOfFire => false;

        /// <summary>
        /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
        /// </summary>
        public virtual bool CanReflectBoltsAndArrows => false;

        /// <summary>
        /// Returns a 1-in-chance for a random artifact to have activation applied.  Returns 3 by default.  Armour returns double the default.
        /// </summary>
        public virtual int RandartActivationChance => 3;

        /// <summary>
        /// Applies an additional bonus to random artifacts.  Does nothing by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual void ApplyRandartBonus(Item item)
        {
        }

        /// <summary>
        /// Returns true, if the item can apply a tunnel bonus.  Only weapons, return true.  Returns false, by default.
        /// </summary>
        public virtual bool CanApplyTunnelBonus => false;

        /// <summary>
        /// Returns true, if the item provides sunlight, which burns certain races.  Returns false, by default.
        /// </summary>
        public virtual bool ProvidesSunlight => false;

        protected int GetBonusValue(int max, int level)
        {
            if (level > Constants.MaxDepth - 1)
            {
                level = Constants.MaxDepth - 1;
            }
            int bonus = max * level / Constants.MaxDepth;
            int extra = max * level % Constants.MaxDepth;
            if (Program.Rng.RandomLessThan(Constants.MaxDepth) < extra)
            {
                bonus++;
            }
            int stand = max / 4;
            extra = max % 4;
            if (Program.Rng.RandomLessThan(4) < extra)
            {
                stand++;
            }
            int value = Program.Rng.RandomNormal(bonus, stand);
            if (value < 0)
            {
                return 0;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }
    }
}
