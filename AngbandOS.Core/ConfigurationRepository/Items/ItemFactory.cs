// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

/// <summary>
/// Represents different variations (ItemType) of item categories (ItemCategory).  E.g. different types of food that belong to the food category.  Several of the
/// properties are modifiable.
/// </summary>
[Serializable]

internal abstract class ItemFactory : IItemCharacteristics, IGetKey<string>
{
    protected readonly SaveGame SaveGame;

    /// <summary>
    /// Returns false, if any of the stats between two items are different.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    protected bool StatsAreSame(Item a, Item b)
    {
        if (a.BonusToHit != b.BonusToHit)
        {
            return false;
        }
        if (a.BonusDamage != b.BonusDamage)
        {
            return false;
        }
        if (a.BonusArmorClass != b.BonusArmorClass)
        {
            return false;
        }
        if (a.TypeSpecificValue != b.TypeSpecificValue)
        {
            return false;
        }
        if (a.FixedArtifact != b.FixedArtifact)
        {
            return false;
        }
        if (!string.IsNullOrEmpty(a.RandartName) || !string.IsNullOrEmpty(b.RandartName))
        {
            return false;
        }
        if (a.RareItemTypeIndex != b.RareItemTypeIndex)
        {
            return false;
        }
        if (a.BonusPowerType != 0 || b.BonusPowerType != 0)
        {
            return false;
        }
        if (a.RechargeTimeLeft != 0 || b.RechargeTimeLeft != 0)
        {
            return false;
        }
        if (a.BaseArmorClass != b.BaseArmorClass)
        {
            return false;
        }
        if (a.DamageDice != b.DamageDice)
        {
            return false;
        }
        if (a.DamageDiceSides != b.DamageDiceSides)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns true, if two item can be merged.  By default, returns true, if both items are from the same factory and are both known.
    /// </summary>
    public virtual bool ItemsCanBeMerged(Item a, Item b)
    {
        // Ensure both items belong to the same factory.  This works because factories are singletons.  Items from different factories cannot
        // be merged.
        if (a.Factory != b.Factory)
        {
            return false;
        }

        // If either item is not known, they cannot be merged.
        if (!a.IsKnown() || !b.IsKnown())
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns the percentage chance that an thrown or fired item breaks.  Returns 10, or 10%, by default.  A value of 101, guarantees the item will break.
    /// </summary>
    public virtual int PercentageBreakageChance => 10;

    /// <summary>
    /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
    /// </summary>
    public virtual int MakeObjectCount => 1;

    /// <summary>
    /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
    /// </summary>
    public virtual bool GetsDamageMultiplier => false;

    /// <summary>
    /// Returns true, if the identity of the item can be sensed; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool IdentityCanBeSensed => false;

    /// <summary>
    /// Returns true, if the item can be used as fuel for a torch.
    /// </summary>
    public virtual bool IsFuelForTorch => false;

    /// <summary>
    /// Returns true, if the item can be worn.
    /// </summary>
    public virtual bool IsWearable => false;

    /// <summary>
    /// Returns true, if the item can be aimed.
    /// </summary>
    public virtual bool CanBeAimed => false;

    /// <summary>
    /// Returns true, if the item can be eaten.
    /// </summary>
    public virtual bool CanBeEaten => false;

    /// <summary>
    /// Returns true, if the item can be quaffed.
    /// </summary>
    public virtual bool CanBeQuaffed => false;

    /// <summary>
    /// Returns true, if the item can be read.
    /// </summary>
    public virtual bool CanBeRead => false;
    /// <summary>
    /// Returns true, if the item can be used.
    /// </summary>
    public virtual bool CanBeUsed => false;
    /// <summary>
    /// Returns true, if the item can be zapped.
    /// </summary>
    public virtual bool CanBeZapped => false;

    /// <summary>
    /// Returns true, if the item can be chosen for the Fire command.
    /// </summary>
    public virtual bool CanBeFired => false;

    /// <summary>
    /// Returns true, if the item is armor.
    /// </summary>
    public virtual bool IsArmor => false;

    /// <summary>
    /// Returns true, if the item is rechargable.
    /// </summary>
    public virtual bool IsRechargable => false;

    /// <summary>
    /// Returns true, if the item is a weapon.
    /// </summary>
    public virtual bool IsWeapon => false;

    protected ItemFactory(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public virtual void Bind()
    {
        FlavorSymbol = Symbol;
        FlavorColor = Color;
    }

    public abstract ItemClass ItemClass { get; }

    /// <summary>
    /// Returns a description of the activation effect for the item or null, if the item cannot be activated.  Returns null by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual string? DescribeActivationEffect => null;

    /// <summary>
    /// Returns true, if the item is fuel for a lantern.  Returns false, by default.
    /// </summary>
    public virtual bool IsFuelForLantern => false;

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    public abstract int PackSort { get; }

    /// <summary>
    /// Returns a new item.
    /// </summary>
    public abstract Item CreateItem();

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Returns the pack, by default.
    /// </summary>
    public virtual BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(PackInventorySlot));

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
    [Obsolete("This property is available via the IFlavour.Flavour property.")]
    public Symbol FlavorSymbol;

    /// <summary>
    /// Returns the color to be used for items of this type.  This color is initially set from the BaseItemCategory, but item categories
    /// that have flavor may override this color and replace it with a different color from the flavor.
    /// </summary>
    [Obsolete("This property is available via the IFlavour.Flavour property.")]
    public ColorEnum FlavorColor;

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
    /// Returns true, if the object has quality.  Returns false, by default.  Armor, weapons and orbs of light return true.  All others types return false.
    /// </summary>
    public virtual bool HasQuality => false;

    /// <summary>
    /// Returns true, if the object type has flavors.  Returns false, by default.
    /// </summary>
    public virtual bool HasFlavor => typeof(IFlavour).IsAssignableFrom(this.GetType());

    /// <summary>
    /// Applies random flavour visuals to the items.  This method is called if the HasFlavor property returns true when creating a new game.
    /// </summary>
    public virtual void ApplyFlavourVisuals() { }

    /// <summary>
    /// Returns true, if the player has attempted/tried the item.
    /// </summary>
    public bool Tried;

    /// <summary>
    /// Returns the symbol to use for rendering. This symbol will be initially used to set the FlavorCharacter and item
    /// categories that have flavor may change the FlavorCharacter based on the flavor.
    /// </summary>
    public abstract Symbol Symbol { get; }

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the FlavorColor and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.White;

    /// <summary>
    /// A unique identifier for the entity
    /// </summary>
    public abstract string Name { get; }

    public virtual int Ac => 0;

    /// <summary>
    /// Returns true, if items of this factory can be activated.  Returns true for all dragon scale mail and rings of ice, acid and flames.  Returns false, by default.  Items produced
    /// by this factory will implement the IItemActivatible interface.
    /// </summary>
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

    /// <summary>
    /// Returns the real cost of a standard item.  Returns 0 by default.
    /// </summary>
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
    /// Tests an item to determine if it belongs to an Item type and returns a the item casted into that type; or null, if the item doesn't belong to the type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T? TryCast<T>() where T : ItemFactory
    {
        if (typeof(T).IsAssignableFrom(GetType()))
        {
            return (T)this;
        }
        else
        {
            return null;
        }
    }

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
    /// Returns whether or not the item affects the tunneling capabilities of the player when being worn.
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
    /// Returns a 1-in-chance for a random artifact to have activation applied.  Returns 3 by default.  Armor returns double the default.
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

    /// <summary>
    /// Returns true, if an item of this factory can have slaying bonus applied for biased artifacts.  Returns true, for all items except bows; which return false.
    /// </summary>
    public virtual bool CanApplyArtifactBiasSlaying => true;

    /// <summary>
    /// Returns true, if an item of this factory can have random resistance bonus applied for biased artifacts.  Returns false for all items except for cloaks, soft armor and hard armor; which return true.
    /// </summary>
    public virtual bool CanApplyArtifactBiasResistance => true;


    /// <summary>
    /// Returns true, if an item of this factory can have be blessed for priestly biased artifacts.  Returns false, for all items except swords and polearms; which return false.
    /// </summary>
    public virtual bool CanApplyBlessedArtifactBias => false;

    /// <summary>
    /// Returns true, if an item of this factory can be eaten by a monster with the eat food attack effect.  Returns false for all items except food items; which return true.
    /// </summary>
    public virtual bool CanBeEatenByMonsters => false;
}
