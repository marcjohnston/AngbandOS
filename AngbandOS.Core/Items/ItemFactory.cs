﻿namespace AngbandOS.Core.ItemClasses
{
    /// <summary>
    /// Represents different variations (ItemType) of item categories (ItemCategory).  E.g. different types of food that belong to the food category.  Several of the
    /// properties are modifyable.
    /// </summary>
    [Serializable]

    internal abstract class ItemFactory : IItemCharacteristics
    {
        public SaveGame SaveGame { get; }

        public ItemFactory(SaveGame saveGame)
        {
            SaveGame = saveGame;
            FlavorCharacter = Character;
            FlavorColour = Colour;
        }

        /// <summary>
        /// Returns true, if the item is fuel for a lantern.  Returns false, by default.
        /// </summary>
        public virtual bool IsFuelForLantern => false;

        /// <summary>
        /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
        /// </summary>
        public abstract int PackSort { get; }

        /// <summary>
        /// Returns the item type to use when creating an item of this category.
        /// </summary>
        public abstract Item CreateItem();

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
        /// Returns true, if the item category has any of the following properties: Str, Int, Wis, Dex, Con, Cha, Stealth, Search, Infra, Tunnel, Speed or Blows.
        /// </summary>
        /// <returns></returns>
        public bool HasAnyPvalMask
        {
            get
            {
                return Str || Int || Wis || Dex || Con || Cha || Stealth || Search || Infra || Tunnel || Speed || Blows;
            }
        }

        /// <summary>
        /// Returns true, if the object has quality.  Returns false, by default.  Armour, weapons and orbs of light return true.  All others types return false.
        /// </summary>
        public virtual bool HasQuality => false;

        /// <summary>
        /// Returns true, if the object type has flavors.  Returns false, by default.
        /// </summary>
        public virtual bool HasFlavor => false;

        /// <summary>
        /// Applies random flavour visuals to the items.  This method is called if the HasFlavor property returns true when creating a new game.
        /// </summary>
        public virtual void ApplyFlavourVisuals() { }

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
        public virtual bool Activate { get; set; } = false;
        public virtual bool Aggravate { get; set; } = false;
        public virtual bool AntiTheft { get; set; } = false;
        public virtual bool Blessed { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item affects the blows delivered by the player when being worn.
        /// </summary>
        public virtual bool Blows { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item does extra damage from acid when being wielded.
        /// </summary>
        public virtual bool BrandAcid { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item does extra damage from frost when being wielded.
        /// </summary>
        public virtual bool BrandCold { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item does extra damage from electricity when being wielded.
        /// </summary>
        public virtual bool BrandElec { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item does extra damage from fire when being wielded.
        /// </summary>
        public virtual bool BrandFire { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item poisons foes when being wielded.
        /// </summary>
        public virtual bool BrandPois { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item affects the charisma of the player when being worn.
        /// </summary>
        public virtual bool Cha { get; set; } = false;

        public virtual int[] Chance => new int[] { 0, 0, 0, 0 };

        /// <summary>
        /// Returns whether or not the item produced chaotic effects when being wielded.
        /// </summary>
        public virtual bool Chaotic { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item affects the constitution of the player when being worn.
        /// </summary>
        public virtual bool Con { get; set; } = false;
        public virtual int Cost => 0;
        public virtual bool Cursed { get; set; } = false;
        public virtual int Dd => 0;

        /// <summary>
        /// Returns whether or not the item affects the dexterity of the player when being worn.
        /// </summary>
        public virtual bool Dex { get; set; } = false;
        public virtual bool DrainExp { get; set; } = false;
        public virtual bool DreadCurse { get; set; } = false;
        public virtual int Ds => 0;
        public virtual bool EasyKnow { get; set; } = false;
        public virtual bool Feather { get; set; } = false;
        public virtual bool FreeAct { get; set; } = false;
        public abstract string FriendlyName { get; }
        public virtual bool HeavyCurse { get; set; } = false;
        public virtual bool HideType { get; set; } = false;
        public virtual bool HoldLife { get; set; } = false;
        public virtual bool IgnoreAcid { get; set; } = false;
        public virtual bool IgnoreCold { get; set; } = false;
        public virtual bool IgnoreElec { get; set; } = false;
        public virtual bool IgnoreFire { get; set; } = false;
        public virtual bool ImAcid { get; set; } = false;
        public virtual bool ImCold { get; set; } = false;
        public virtual bool ImElec { get; set; } = false;
        public virtual bool ImFire { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item causes earthquakes of the player when being worn.
        /// </summary>
        public virtual bool Impact { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item affects the infravision of the player when being worn.
        /// </summary>
        public virtual bool Infra { get; set; } = false;
        public virtual bool InstaArt { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item affects the intelligence of the player when being worn.
        /// </summary>
        public virtual bool Int { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item is a great bane of dragons.
        /// </summary>
        public virtual bool KillDragon { get; set; } = false;

        public virtual bool KindIsGood => false;
        public virtual int Level => 0;
        public virtual bool Lightsource { get; set; } = false;
        public virtual int[] Locale => new int[] { 0, 0, 0, 0 };
        public virtual bool NoMagic { get; set; } = false;
        public virtual bool NoTele { get; set; } = false;
        public virtual bool PermaCurse { get; set; } = false;
        public virtual int Pval => 0;
        public virtual bool Reflect { get; set; } = false;
        public virtual bool Regen { get; set; } = false;
        public virtual bool ResAcid { get; set; } = false;
        public virtual bool ResBlind { get; set; } = false;
        public virtual bool ResChaos { get; set; } = false;
        public virtual bool ResCold { get; set; } = false;
        public virtual bool ResConf { get; set; } = false;
        public virtual bool ResDark { get; set; } = false;
        public virtual bool ResDisen { get; set; } = false;
        public virtual bool ResElec { get; set; } = false;
        public virtual bool ResFear { get; set; } = false;
        public virtual bool ResFire { get; set; } = false;
        public virtual bool ResLight { get; set; } = false;
        public virtual bool ResNether { get; set; } = false;
        public virtual bool ResNexus { get; set; } = false;
        public virtual bool ResPois { get; set; } = false;
        public virtual bool ResShards { get; set; } = false;
        public virtual bool ResSound { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item affects the search capabilities of the player when being worn.
        /// </summary>
        public virtual bool Search { get; set; } = false;

        public virtual bool SeeInvis { get; set; } = false;
        public virtual bool ShElec { get; set; } = false;
        public virtual bool ShFire { get; set; } = false;
        public virtual bool ShowMods { get; set; } = false;
        public virtual bool SlayAnimal { get; set; } = false;
        public virtual bool SlayDemon { get; set; } = false;
        public virtual bool SlayDragon { get; set; } = false;
        public virtual bool SlayEvil { get; set; } = false;
        public virtual bool SlayGiant { get; set; } = false;
        public virtual bool SlayOrc { get; set; } = false;
        public virtual bool SlayTroll { get; set; } = false;
        public virtual bool SlayUndead { get; set; } = false;
        public virtual bool SlowDigest { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item affects the attack speed of the player when being worn.
        /// </summary>
        public virtual bool Speed { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item affects the stealth of the player when being worn.
        /// </summary>
        public virtual bool Stealth { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item affects the strength of the player when being worn.
        /// </summary>
        public virtual bool Str { get; set; } = false;

        /// <summary>
        /// Returns the subcategory enumeration that the item belongs to.  This property is to be deleted.  Returns null, when not in use.
        /// </summary>
        [Obsolete("To be deleted")]
        public abstract int? SubCategory { get; }

        public virtual bool SustCha { get; set; } = false;
        public virtual bool SustCon { get; set; } = false;
        public virtual bool SustDex { get; set; } = false;
        public virtual bool SustInt { get; set; } = false;
        public virtual bool SustStr { get; set; } = false;
        public virtual bool SustWis { get; set; } = false;
        public virtual bool Telepathy { get; set; } = false;
        public virtual bool Teleport { get; set; } = false;
        public virtual int ToA => 0;
        public virtual int ToD => 0;
        public virtual int ToH => 0;

        /// <summary>
        /// Returns whether or not the item affects the tunnelling capabilities of the player when being worn.
        /// </summary>
        public virtual bool Tunnel { get; set; } = false;

        public virtual bool Vampiric { get; set; } = false;

        /// <summary>
        /// Returns whether or not the item is very sharp and cuts foes of the player when being used.
        /// </summary>
        public virtual bool Vorpal { get; set; } = false;

        public virtual int Weight => 0;

        /// <summary>
        /// Returns whether or not the item affects the wisdom of the player when being worn.
        /// </summary>
        public virtual bool Wis { get; set; } = false;
        public virtual bool Wraith { get; set; } = false;
        public virtual bool XtraMight { get; set; } = false;
        public virtual bool XtraShots { get; set; } = false;

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
        /// Returns true, if the item can apply a tunnel bonus.  Only weapons, return true.  Returns false, by default.
        /// </summary>
        public virtual bool CanApplyTunnelBonus => false;

        /// <summary>
        /// Returns true, if the item provides sunlight, which burns certain races.  Returns false, by default.
        /// </summary>
        public virtual bool ProvidesSunlight => false;
    }
}