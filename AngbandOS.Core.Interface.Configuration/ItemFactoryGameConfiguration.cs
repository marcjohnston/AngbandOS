// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ItemFactoryGameConfiguration
{
    #region ItemEnhancement
    public virtual string? Key { get; set; } = null;
    #endregion

    public virtual string? ItemEnhancementBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the name of the <see cref="ItemFlavor"/> that this item should be assigned.  This assignment overrides the random flavor assignment, when the <see cref="ItemClass"/>
    /// utilizes item flavors.  Returns null, to allow the <see cref="ItemClass"/> to assign a random <see cref="ItemFlavor"/> or when this factory doesn't produce flavored items.
    /// This property is used to bind the <see cref="PreassignedItemFlavor"/> property during the binding phase.
    /// </summary>
    public virtual string? PreassignedItemFlavorBindingKey { get; set; } = null;

    public virtual bool NegativeBonusDamageRepresentsBroken { get; set; } = false;
    public virtual bool NegativeBonusArmorClassRepresentsBroken { get; set; } = false;
    public virtual bool NegativeBonusHitRepresentsBroken { get; set; } = false;

    public virtual string? SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey { get; set; } = nameof(ItemEnhancementWeightedRandomsEnum.SlayingItemEnhancementWeightedRandom);

    /// <summary>
    /// Returns the ceiling value for bonus armor values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public virtual int? RandomArtifactBonusArmorCeiling { get; set; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus hit values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public virtual int? RandomArtifactBonusHitCeiling { get; set; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus damage values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public virtual int? RandomArtifactBonusDamageCeiling { get; set; } = null;

    /// <summary>
    /// Returns the key of the script that is used to refill the item; or null, if the item cannot be refilled.  Returns null, by default.  This property is used to bind the <see cref="RefillScript"/>
    /// property during the binding phase.
    /// </summary>
    public virtual string? RefillScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the symbol to use for rendering the item.  This symbol will be initially used to set the <see cref="FlavorSymol"/> and item catagories that have flavor may the change the
    /// <see cref="FlavorCharacter"/> based on the flavor.  This property is used to bind the <see cref="Symbol"/> property during the bind phase.
    /// </summary>
    public virtual string SymbolBindingKey { get; set; }

    public virtual bool CanBeWeaponOfLaw { get; set; } = false;

    public virtual bool CanBeWeaponOfSharpness { get; set; } = false;

    public virtual bool CapableOfVorpalSlaying { get; set; } = false;

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the <see cref="FlavorColor"/> and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    /// <summary>
    /// Returns the name of the noticeable script to run when the player uses the item ; or null if the potion does
    /// not have a smash effect; if the item can be quaffed; or null, if the item cannot be quaffed.  This property is used to bind the
    /// <see cref="UseTuple"/> property during the bind phase.  Returns null, by default.
    /// 
    /// Returns the roll expression used to determine the initial number of staff charges that will be given to the item at item creation; or null, if the item is not a staff.  null is returns, 
    /// by default.  This property is used to bind the <see cref="StaffChargeCount"/> property during the bind phase.
    ///     
    /// Returns the value of each staff charge.  Returns 0, by default.
    /// The amount of mana needed to consume to keep the potion.
    /// </summary>
    public virtual (string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)? UseBindingTuple { get; set; } = null;

    /// <summary>
    /// Returns the name of the noticeable script to run when the player quaffs the potion and the name of the smash script when the player smashes the potion; or null if the potion does
    /// not have a smash effect; if the item can be quaffed; or null, if the item cannot be quaffed.  This property is used to bind the
    /// <see cref="QuaffTuple"/> property during the bind phase.  Returns null, by default.
    /// 
    /// Perform a smash effect on the potion and returns true, if the effect causes pets to become unfriendly; false, otherwise.  Returns false, by default.
    /// 
    /// The amount of mana needed to consume to keep the potion.
    /// </summary>
    public virtual (string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)? QuaffBindingTuple { get; set; } = null;

    /// <summary>
    /// Returns the name of the <see cref="ItemClass"/> that is used as ammunition for this item; or null, if the item is not a ranged weapon.  This property is used to bind
    /// the <see cref="AmmunitionItemFactories"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public virtual string[]? AmmunitionItemFactoryBindingKeys { get; set; } = null;

    /// <summary>
    /// Returns true, if the item can be used to spike a door closed; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool CanSpikeDoorClosed { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can be used to dig; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool CanTunnel { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a bow and can project arrows; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool CanProjectArrows { get; set; } = false;

    /// <summary>
    /// Returns the maximum number of items that can be enchanted at one time.  A value of 1 is returned, by default.  Ammunition items return 20.  Item counts greater than this value
    /// will have a decreased probability of enchantment.
    /// </summary>
    public virtual int EnchantmentMaximumCount { get; set; } = 1;

    /// <summary>
    /// Returns true, if the item is magical and is noticed with the detect magical scoll.
    /// </summary>
    public virtual bool IsMagical { get; set; } = false;

    /// <summary>
    /// Returns the value of each turn of light for light sources.  Returns 0, by default;
    /// </summary>
    public virtual int ValuePerTurnOfLight { get; set; } = 0;

    /// <summary>
    /// Returns the name of the <see cref="IAimWandScript"/> script for wands when aimed, a roll expression to determine the number of charges to assign to new wands and the value of each charge; or null, if the 
    /// item cannot be aimed.  Returns null, by default.  This property is used to bind the <see cref="AimingTuple"/>  property during the bind phase.
    /// </summary>
    public virtual (string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)? AimingBindingTuple { get; set; } = null;

    /// <summary>
    /// Returns true, if the item is broken; false, otherwise.  Broken items have no value and will be stomped.
    /// </summary>
    public virtual bool IsBroken { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality that should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.  
    /// Returns false, by default.  Weapons, armor, orbs of light and broken items (items that negatively affect the player) return true.
    /// </summary>
    public virtual bool InitialBrokenStomp { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public virtual bool InitialAverageStomp { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public virtual bool InitialGoodStomp { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public virtual bool InitialExcellentStomp { get; set; } = false;

    public virtual string? RechargeScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns true, if the item is ignored by monsters.  Returns false for all items, except gold.  Gold isn't picked up by monsters.
    /// </summary>
    public virtual bool IsIgnoredByMonsters { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a container; false, otherwise.  Containers can be opened (ContainerIsOpen) and trapped (ContainerTraps).
    /// </summary>
    public virtual bool IsContainer { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a ranged weapon; false, otherwise.
    /// </summary>
    public virtual bool IsRangedWeapon { get; set; } = false;

    /// <summary>
    /// Returns a damage multiplier when the missile weapon is used.
    /// </summary>
    public virtual int MissileDamageMultiplier { get; set; } = 1;

    /// <summary>
    /// Returns the maximum fuel that can be used for phlogiston.  Returns null, by default, meaning that the light source cannot be used to create a phlogiston.
    /// </summary>
    public virtual int? MaxPhlogiston { get; set; } = null;

    /// <summary>
    /// Returns the number of turns of light that is consumed per turn.  Defaults to zero; which means there is no consumption and that the light source lasts forever.
    /// Torches and laterns have burn rates greater than zero.
    /// </summary>
    public virtual int BurnRate { get; set; } = 0;

    /// <summary>
    /// Returns an array of tuples that define the mass produce for items of this factory.  These tuples define a Roll that is applied for additional items to be produced
    /// for items of a cost value or less; or null, if no additional items should be produced based on any cost.  Returns null, by default.  This property is used
    /// to bind the <see cref="MassProduceTuples"/> property during the bind phase.  The tuples must be sorted by cost and are checked during the bind phase.
    /// </summary>
    public virtual (int count, string rollExpression)[]? MassProduceBindingTuples { get; set; } = null;

    public virtual int BonusHitRealValueMultiplier { get; set; } = 100;
    public virtual int BonusDamageRealValueMultiplier { get; set; } = 100;
    public virtual int BonusArmorClassRealValueMultiplier { get; set; } = 100;
    public virtual int BonusDiceRealValueMultiplier { get; set; } = 100;

    public virtual string? BreaksDuringEnchantmentProbabilityExpression { get; set; } = null;

    /// <summary>
    /// Returns the name of the IEnchantmentScript to run for enchanting items depending on the item power and whether the item is being sold in a store.
    /// </summary>
    /// <returns>
    /// Powers - One or more item power levels (-2, -1, 0, 1, 2) the enchantment applies to; or null, if the enchantments apply to all power levels./>
    /// StoreStock - True, when the enchantment applies only to items sold in a store; false, when the enchantment only applies to items not sold in a store; or null, if the enchantment applies regardless of whether the item is being sold in a store or not.;<para />
    /// ScriptNames - The names of one or more scripts that implement the IEnhancementScript interface to be run to enhance the item when the Powers and StoreStock criteria match.  An empty array will throw during binding.
    /// </returns>
    public virtual (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples { get; set; } = null;

    /// <summary>
    /// Returns the name of the script to run, when the energy of a rechargeable item is consumed; or null, if the item does not have charges that can be consumed or those charges cannot be consumed.
    /// This property is used to bind the <see cref="EatMagicScript"/> property during the bind phase.
    /// </summary>
    public virtual string? EatMagicScriptBindingKey { get; set; } = null;

    public virtual string? GridProcessWorldScriptBindingKey { get; set; } = null;
    public virtual string? MonsterProcessWorldScriptBindingKey { get; set; } = null;
    public virtual string? EquipmentProcessWorldScriptBindingKey { get; set; } = null;
    public virtual string? PackProcessWorldScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns an expression that represents the chance that an item that is thrown or fired will break.  Returns 10, or 10%, by default.  This
    /// property is used to bind the <see cref="BreakageChanceProbability"/> property during the bind phase.
    /// </summary>
    public virtual string BreakageChanceProbabilityExpression { get; set; } = "10/100";

    /// <summary>
    /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
    /// </summary>
    public virtual string MakeObjectCountExpression { get; set; } = "1";

    /// <summary>
    /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
    /// </summary>
    public virtual bool GetsDamageMultiplier { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can be sensed; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool IdentityCanBeSensed { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can be used as fuel for a torch.
    /// </summary>
    public virtual bool IsFuelForTorch { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can be worn.
    /// </summary>
    public virtual bool IsWearableOrWieldable { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can be eaten.
    /// </summary>
    public virtual bool CanBeEaten { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is armor.
    /// </summary>
    public virtual bool IsArmor { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a weapon.
    /// </summary>
    public virtual bool IsWeapon { get; set; } = false;

    /// <summary>
    /// Returns the number of items contained in the chest; or 0, if the item is not a container.  Returns 0, by default.
    /// </summary>
    public virtual int NumberOfItemsContained { get; set; } = 0;

    /// <summary>
    /// Returns the name of the item as it applies to the factory class.  In other words, the name does not include the factory class name.  E.g. The factory class of scrolls would
    /// have names like "light", "magic mapping" and "identify".  This name should be able to uniquely identify the item from other items within the same factory class.
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// Returns the syntax for the description of the item.  The and symbol '&' is used to represent the article (a, an or a number) and the
    /// tilde symbol '~' used to place the 's', 'es', or 'ies' plural form of the noun.
    /// </summary>
    public virtual string? DescriptionSyntax { get; set; } = null; // TODO: Books use a hard-coded realm name when the realm is set at run-time.

    /// <summary>
    /// Returns an alternate coded name for some character classes for known items; null, if there is no altername name; in which the <see cref="DescriptionSyntax"/> property will
    /// be used.  Returns null, by default.  Spellbooks have a alternate names.  Druid, Fanatic, Monk, Priest and Ranger character classes use alternate names.  Character
    /// classes will use alternate naming conventions when <see cref="BaseCharacterClass.UseAlternateItemNames"/> property returns true.
    /// </summary>
    public virtual string? AlternateDescriptionSyntax { get; set; } = null; // TODO: This coded divine name has hard-coded realm names when realm is set at run-time.

    public virtual string? FlavorSuppressedDescriptionSyntax { get; set; } = null;
    public virtual string? AlternateFlavorSuppressedDescriptionSyntax { get; set; } = null;

    public virtual string? FlavorUnknownDescriptionSyntax { get; set; } = null;

    public virtual string? AlternateFlavorUnknownDescriptionSyntax { get; set; } = null;

    /// <summary>
    /// Returns the number of turns an item that can be zapped needs before it is recharged; or null, if the item cannot be zapped.  A value of zero, means the item does not need any turns to
    /// be recharged after it is used.
    /// </summary>
    public virtual (string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapBindingTuple { get; set; } = null;

    public virtual string ItemClassBindingKey { get; set; }

    /// <summary>
    /// Returns true, if the item is fuel for a lantern.  Returns false, by default.
    /// </summary>
    public virtual bool IsLanternFuel { get; set; } = false;

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    public virtual int PackSort { get; set; }

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Items will be wielded in the first slot that is available.  Rings use multiple wield slots for left and right hands.
    /// Returns the pack, by default.  This property is used to bind the <see cref="WieldSlots"/>  property during the binding phase.
    /// </summary>
    public virtual string[] WieldSlotBindingKeys { get; set; } = new string[] { nameof(WieldSlotsEnum.PackWieldSlot) };

    /// <summary>
    /// Returns true, if the destroy script should ask the player if known items from this factory should be destroyed by setting the applicable 
    /// broken stomp type to true; false, otherwise.  Returns true, by default.  Chests, weapons, armor and orbs of light return false.
    /// </summary>
    public virtual bool AskDestroyAll { get; set; } = true;

    /// <summary>
    /// Returns true, if the object has different quality ratings; false, if items of the factory all have the same quality rating.  Returns false, by default.  
    /// Armor, weapons and orbs of light return true.  Items without quality ratings will always use the Broken stomp type.  Items with various quality ratings will use various
    /// item properties to determine their quality.
    /// </summary>
    public virtual bool HasQualityRatings { get; set; } = false;

    /// <summary>
    /// Returns the base armor class rating for items created by the factory.  Returns 0, by default.
    /// </summary>
    public virtual int ArmorClass { get; set; } = 0;

    /// <summary>
    /// Returns the depth and 1-in probably for where the item can be found; or null, if the item is not found naturally.  Returns null, by default.
    /// </summary>
    public virtual (int level, int chance)[]? DepthsFoundAndChances { get; set; } = null; // TODO: Convert the chance into a Roll object

    /// <summary>
    /// Returns the real cost of a standard item.  Returns 0 by default.  For wands, staffs and light-sources, this value should be the value of an item with no charges.  An empty item should
    /// still have some value if it can be recharged.
    /// </summary>
    public virtual int Cost { get; set; } = 0;

    public virtual int DamageDice { get; set; } = 0;

    public virtual int DamageSides { get; set; } = 0;

    public virtual int LevelNormallyFound { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus attacks to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusAttacks { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus infravision to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusInfravision { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus speed to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusSpeed { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus search to be assigned to the item.
    /// </summary>
    public virtual string InitialBonusSearchExpression { get; set; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus stealth to be assigned to the item.
    /// </summary>
    public virtual string InitialBonusStealthExpression { get; set; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus tunnel to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusTunnel { get; set; } = 0;

    /// <summary>
    /// Returns the initial number of turns of light to be assigned to the item.
    /// </summary>
    public virtual int InitialTurnsOfLight { get; set; } = 0;

    /// <summary>
    /// Returns the initial nutritional value that items of this factory will be given.  0 turns is returns by default.
    /// </summary>
    public virtual int InitialNutritionalValue { get; set; } = 0;

    /// <summary>
    /// Returns the roll expression to determine the initial gold pieces that are given to the player when the item is picked up.  This property must conform to the <see cref="Roll"/> syntax for parsing.  
    /// See <see cref="Game.ParseNumericExpression"/> for syntax details.  This property is used to bind the <see cref="InitialGoldPiecesRoll"/> property during the bind phase.
    /// </summary>
    public virtual string InitialGoldPiecesRollExpression { get; set; } = "0";

    /// <summary>
    /// Returns a divisor to be used to compute the amount of experience gained when an applicable character class destroys the book.  Defaults to 4.
    /// </summary>
    public virtual int ExperienceGainDivisorForDestroying { get; set; } = 0;

    /// <summary>
    /// Returns the names of the spells, in order, that belong to this book; or null, if the item is not a book.  This property is used to bind the Spells property during the binding phase.
    /// </summary>
    public virtual string[]? SpellBindingKeys { get; set; } = null;

    public virtual int BonusArmorClass { get; set; } = 0;
    public virtual int BonusDamage { get; set; } = 0;
    public virtual int BonusHit { get; set; } = 0;

    public virtual int Weight { get; set; } = 0;

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    public virtual bool IsSmall { get; set; } = false; // TODO: This property is only valid when IsContainer.  The data type is horrible.

    /// <summary>
    /// Returns the base value for a non flavor-aware item.  Returns 0, by default.
    /// </summary>
    public virtual int BaseValue { get; set; } = 0;

    /// <summary>
    /// Returns true, if the item is susceptible to electricity.  Returns false, by default.
    /// </summary>
    public virtual bool HatesElectricity { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to fire.  Returns false, by default.
    /// </summary>
    public virtual bool HatesFire { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to acid.  Returns false, by default.
    /// </summary>
    public virtual bool HatesAcid { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to cold.  Returns false, by default.
    /// </summary>
    public virtual bool HatesCold { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of electricity.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    public virtual bool CanProvideSheathOfElectricity { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of fire.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    public virtual bool CanProvideSheathOfFire { get; set; } = false;

    /// <summary>
    /// Returns a 1-in-chance for a random artifact to have activation applied.  Returns 3 by default.  Armor returns double the default.
    /// </summary>
    public virtual int RandartActivationChance { get; set; } = 3;

    /// <summary>
    /// Returns true, if the item provides sunlight, which burns certain races.  Returns false, by default.
    /// </summary>
    public virtual bool ProvidesSunlight { get; set; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can have random resistance bonus applied for biased artifacts.  Returns false for all items except for cloaks, soft armor and hard armor; which return true.
    /// </summary>
    public virtual bool CanApplyArtifactBiasResistance { get; set; } = true;

    /// <summary>
    /// Returns true, if an item of this factory can be eaten by a monster with the eat food attack effect.  Returns false for all items except food items; which return true.
    /// </summary>
    public virtual bool CanBeEatenByMonsters { get; set; } = false;

    /// <summary>
    /// Returns the name of the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  Returns null, by default.  This property
    /// is used to bind the <see cref="EatScript"/> property during the bind phase.
    /// </summary>
    public virtual string? EatScriptBindingKey { get; set; } = null;

    public virtual bool VanishesWhenEatenBySkeletons { get; set; } = false;

    /// <summary>
    /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
    /// all food items are consumed except for dwarf bread.  Dwarf bread returns false.
    /// </summary>
    public virtual bool IsConsumedWhenEaten { get; set; } = true;

    /// <summary>
    /// Returns the name of the activation script for scrolls when read; or null, if the item cannot be read.  Returns null, by default.  This property is used to bind the <see cref="ReadTuple"/> 
    /// property during the bind phase.
    /// </summary>
    /// <returns>
    /// ManaValue:description Returns the amount of mana channelers can substitute instead of the scroll being used up.
    /// </returns>
    public virtual (string ScriptName, int ManaValue)? ReadBindingTuple { get; set; } = null;
}
