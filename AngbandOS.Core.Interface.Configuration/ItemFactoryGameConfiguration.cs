// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ItemFactoryGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string?",
        Title = "Item Enhancement Binding Key",
        Description = "The binding key of the item enhancement applied to items created by this factory.",
        LabelIfNullable = "Apply item enhancements")]
    public virtual string? ItemEnhancementBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the name of the <see cref="ItemFlavor"/> that this item should be assigned.  This assignment overrides the random flavor assignment, when the <see cref="ItemClass"/>
    /// utilizes item flavors.  Returns null, to allow the <see cref="ItemClass"/> to assign a random <see cref="ItemFlavor"/> or when this factory doesn't produce flavored items.
    /// This property is used to bind the <see cref="PreassignedItemFlavor"/> property during the binding phase.
    /// </summary>
    [ConfigurationProperty("string?",
        Title = "Preassigned Item Flavor Binding Key",
        Description = "The binding key of the item flavor assigned to items created by this factory, or null to allow the item class to assign a random flavor.")]
    public virtual string? PreassignedItemFlavorBindingKey { get; set; } = null;

    [ConfigurationProperty("bool",
        Title = "Negative Bonus Damage Represents Broken",
        Description = "Determines whether a negative bonus damage value represents a broken item.")]
    public virtual bool NegativeBonusDamageRepresentsBroken { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Negative Bonus Armor Class Represents Broken",
        Description = "Determines whether a negative bonus armor class value represents a broken item.")]
    public virtual bool NegativeBonusArmorClassRepresentsBroken { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Negative Bonus Hit Represents Broken",
        Description = "Determines whether a negative bonus hit value represents a broken item.")]
    public virtual bool NegativeBonusHitRepresentsBroken { get; set; } = false;

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the <see cref="FlavorColor"/> and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Description = "The color used to render items of this type.")]
    public virtual ColorEnum Color { get; set; }

    [ConfigurationProperty("string?",
        Title = "Slaying Random Artifact Item Enhancement Weighted Random Binding Key",
        Description = "The binding key of the weighted random configuration used to select slaying item enhancements for random artifacts.")]
    public virtual string? SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey { get; set; } = nameof(ItemEnhancementWeightedRandomsEnum.SlayingItemEnhancementWeightedRandom);

    /// <summary>
    /// Returns the ceiling value for bonus armor values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    [ConfigurationProperty("int?",
        Title = "Random Artifact Bonus Armor Ceiling",
        Description = "The maximum bonus armor value allowed when creating a random artifact, or null when no bonus should be added.")]
    public virtual int? RandomArtifactBonusArmorCeiling { get; set; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus hit values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    [ConfigurationProperty("int?",
        Title = "Random Artifact Bonus Hit Ceiling",
        Description = "The maximum bonus hit value allowed when creating a random artifact, or null when no bonus should be added.")]
    public virtual int? RandomArtifactBonusHitCeiling { get; set; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus damage values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    [ConfigurationProperty("int?",
        Title = "Random Artifact Bonus Damage Ceiling",
        Description = "The maximum bonus damage value allowed when creating a random artifact, or null when no bonus should be added.")]
    public virtual int? RandomArtifactBonusDamageCeiling { get; set; } = null;

    /// <summary>
    /// Returns the key of the script that is used to refill the item; or null, if the item cannot be refilled.  Returns null, by default.  This property is used to bind the <see cref="RefillScript"/>
    /// property during the binding phase.
    /// </summary>
    [ConfigurationProperty("string?",
        Title = "Refill Script Binding Key",
        Description = "The binding key of the script used to refill the item, or null when the item cannot be refilled.")]
    public virtual string? RefillScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the symbol to use for rendering the item.  This symbol will be initially used to set the <see cref="FlavorSymol"/> and item catagories that have flavor may the change the
    /// <see cref="FlavorCharacter"/> based on the flavor.  This property is used to bind the <see cref="Symbol"/> property during the bind phase.
    /// </summary>
    [ConfigurationProperty("string",
        Title = "Symbol Binding Key",
        Description = "The binding key of the symbol used to render the item.")]
    public virtual string SymbolBindingKey { get; set; }

    [ConfigurationProperty("bool",
        Title = "Can Be Weapon of Law",
        Description = "Determines whether the item can be a weapon of law.")]
    public virtual bool CanBeWeaponOfLaw { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Can Be Weapon of Sharpness",
        Description = "Determines whether the item can be a weapon of sharpness.")]
    public virtual bool CanBeWeaponOfSharpness { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Capable of Vorpal Slaying",
        Description = "Determines whether the item is capable of vorpal slaying.")]
    public virtual bool CapableOfVorpalSlaying { get; set; } = false;

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
    [ConfigurationProperty("(string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)?",
        Title = "Use Binding Tuple",
        Description = "The script binding key, initial charges roll expression, per-charge value, and mana equivalent used when the item is used.",
        LabelIfNullable = "Item Can be Used?")]
    [ConfigurationTupleItem("UseScriptBindingKey", Title = "Use Script Binding Key")]
    [ConfigurationTupleItem("InitialChargesRollExpression", Title = "Initial Charges Roll Expression")]
    [ConfigurationTupleItem("PerChargeValue", Title = "Per Charge Value")]
    [ConfigurationTupleItem("ManaEquivalent", Title = "Mana Equivalent")]
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
    [ConfigurationProperty("(string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)?",
        Title = "Quaff Binding Tuple",
        Description = "The quaff script name, optional smash script name, and mana equivalent used when the item is quaffed.")]
    [ConfigurationTupleItem("QuaffScriptName", Title = "Quaff Script Name")]
    [ConfigurationTupleItem("SmashScriptName", Title = "Smash Script Name")]
    [ConfigurationTupleItem("ManaEquivalent", Title = "Mana Equivalent")]
    public virtual (string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)? QuaffBindingTuple { get; set; } = null;

    /// <summary>
    /// Returns the name of the <see cref="ItemClass"/> that is used as ammunition for this item; or null, if the item is not a ranged weapon.  This property is used to bind
    /// the <see cref="AmmunitionItemFactories"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    [ConfigurationProperty("string[]?",
        Title = "Ammunition Item Factory Binding Keys",
        Description = "The binding keys of the item factories used as ammunition for this item, or null when the item is not a ranged weapon.")]
    public virtual string[]? AmmunitionItemFactoryBindingKeys { get; set; } = null;

    /// <summary>
    /// Returns true, if the item can be used to spike a door closed; false, otherwise.  Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Can Spike Door Closed",
        Description = "Determines whether the item can be used to spike a door closed.")]
    public virtual bool CanSpikeDoorClosed { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a bow and can project arrows; false, otherwise.  Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Can Project Arrows",
        Description = "Determines whether the item is a bow that can project arrows.")]
    public virtual bool CanProjectArrows { get; set; } = false;

    /// <summary>
    /// Returns the maximum number of items that can be enchanted at one time.  A value of 1 is returned, by default.  Ammunition items return 20.  Item counts greater than this value
    /// will have a decreased probability of enchantment.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Enchantment Maximum Count",
        Description = "The maximum number of items that can be enchanted at one time.")]
    public virtual int EnchantmentMaximumCount { get; set; } = 1;

    /// <summary>
    /// Returns true, if the item is magical and is noticed with the detect magical scoll.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Is Magical",
        Description = "Determines whether the item is magical and is noticed by the detect magical scroll.")]
    public virtual bool IsMagical { get; set; } = false;

    /// <summary>
    /// Returns the value of each turn of light for light sources.  Returns 0, by default;
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Value Per Turn of Light",
        Description = "The value of each turn of light for light sources.")]
    public virtual int ValuePerTurnOfLight { get; set; } = 0;

    /// <summary>
    /// Returns the name of the <see cref="IAimWandScript"/> script for wands when aimed, a roll expression to determine the number of charges to assign to new wands and the value of each charge; or null, if the 
    /// item cannot be aimed.  Returns null, by default.  This property is used to bind the <see cref="AimingTuple"/>  property during the bind phase.
    /// </summary>
    [ConfigurationProperty("(string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)?",
        Title = "Aiming Binding Tuple",
        Description = "The activation script name, initial charges roll expression, per-charge value, and mana value for an item that can be aimed.")]
    [ConfigurationTupleItem("ActivationScriptName", Title = "Activation Script Name")]
    [ConfigurationTupleItem("InitialChargesCountRollExpression", Title = "Initial Charges Count Roll Expression")]
    [ConfigurationTupleItem("PerChargeValue", Title = "Per Charge Value")]
    [ConfigurationTupleItem("ManaValue", Title = "Mana Value")]
    public virtual (string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)? AimingBindingTuple { get; set; } = null;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality that should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.  
    /// Returns false, by default.  Weapons, armor, orbs of light and broken items (items that negatively affect the player) return true.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Initial Broken Stomp",
        Description = "Determines whether broken items of this factory initially default to being stomped.")]
    public virtual bool InitialBrokenStomp { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Initial Average Stomp",
        Description = "Determines whether average-quality items of this factory initially default to being stomped.")]
    public virtual bool InitialAverageStomp { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Initial Good Stomp",
        Description = "Determines whether good-quality items of this factory initially default to being stomped.")]
    public virtual bool InitialGoodStomp { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Initial Excellent Stomp",
        Description = "Determines whether excellent-quality items of this factory initially default to being stomped.")]
    public virtual bool InitialExcellentStomp { get; set; } = false;

    [ConfigurationProperty("string?",
        Title = "Recharge Script Binding Key",
        Description = "The binding key of the script used to recharge the item.")]
    public virtual string? RechargeScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns true, if the item is ignored by monsters.  Returns false for all items, except gold.  Gold isn't picked up by monsters.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Is Ignored by Monsters",
        Description = "Determines whether the item is ignored by monsters.")]
    public virtual bool IsIgnoredByMonsters { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a container; false, otherwise.  Containers can be opened (ContainerIsOpen) and trapped (ContainerTraps).
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Is Container",
        Description = "Determines whether the item is a container.")]
    public virtual bool IsContainer { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a ranged weapon; false, otherwise.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Is Ranged Weapon",
        Description = "Determines whether the item is a ranged weapon.")]
    public virtual bool IsRangedWeapon { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Disable Stomp",
        Description = "Determines whether stomping is disabled for the item.")]
    public virtual bool DisableStomp { get; set; } = false;

    [ConfigurationProperty("string[]?",
        Title = "Enhancement Fixed Artifact Factories Binding Keys",
        Description = "The binding keys of fixed artifact factories used to provide enhancements for this item factory.")]
    public virtual string[]? EnhancementFixedArtifactFactoriesBindingKeys { get; set; } = null;

    /// <summary>
    /// Returns a damage multiplier when the missile weapon is used.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Missile Damage Multiplier",
        Description = "The damage multiplier applied when the missile weapon is used.")]
    public virtual int MissileDamageMultiplier { get; set; } = 1;

    /// <summary>
    /// Returns the maximum fuel that can be used for phlogiston.  Returns null, by default, meaning that the light source cannot be used to create a phlogiston.
    /// </summary>
    [ConfigurationProperty("int?",
        Title = "Maximum Phlogiston",
        Description = "The maximum amount of fuel that can be used for phlogiston, or null when the light source cannot create phlogiston.")]
    public virtual int? MaxPhlogiston { get; set; } = null;

    /// <summary>
    /// Returns an array of tuples that define the mass produce for items of this factory when they are sold in a store.  These tuples define a Roll that is applied for additional items to be produced
    /// for items of a cost value or less; or null, if no additional items should be produced based on any cost.  Costs are determined after enhancements are applied.  Returns null, by default.  This property is used
    /// to bind the <see cref="MassProduceTuples"/> property during the bind phase.  The tuples must be sorted by cost and are checked during the bind phase.
    /// </summary>
    [ConfigurationProperty("(int count, string rollExpression)[]?",
        Title = "Mass Produce Binding Tuples",
        Description = "The count and roll expression used to determine additional items produced for items sold in a store based on their cost.")]
    [ConfigurationTupleItem("count", Title = "Count")]
    [ConfigurationTupleItem("rollExpression", Title = "Roll Expression")]
    public virtual (int count, string rollExpression)[]? MassProduceBindingTuples { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Breaks During Enchantment Probability Expression",
        Description = "The probability expression that determines the chance the item breaks during enchantment.")]
    public virtual string? BreaksDuringEnchantmentProbabilityExpression { get; set; } = null;

    /// <summary>
    /// Returns the name of the IEnchantmentScript to run for enchanting items depending on the item power and whether the item is being sold in a store.
    /// </summary>
    /// <returns>
    /// Powers - One or more item power levels (-2, -1, 0, 1, 2) the enchantment applies to; or null, if the enchantments apply to all power levels./>
    /// StoreStock - True, when the enchantment applies only to items sold in a store; false, when the enchantment only applies to items not sold in a store; or null, if the enchantment applies regardless of whether the item is being sold in a store or not.;<para />
    /// ScriptNames - The names of one or more scripts that implement the IEnhancementScript interface to be run to enhance the item when the Powers and StoreStock criteria match.  An empty array will throw during binding.
    /// </returns>
    [ConfigurationProperty("(int[]? Powers, bool? StoreStock, string[] ScriptNames)[]?",
        Title = "Enchantment Binding Tuples",
        Description = "The power levels, store-stock condition, and script names used to determine which enchantment scripts apply.")]
    [ConfigurationTupleItem("Powers", Title = "Powers")]
    [ConfigurationTupleItem("StoreStock", Title = "Store Stock")]
    [ConfigurationTupleItem("ScriptNames", Title = "Script Names")]
    public virtual (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples { get; set; } = null;

    /// <summary>
    /// Returns the name of the script to run, when the energy of a rechargeable item is consumed; or null, if the item does not have charges that can be consumed or those charges cannot be consumed.
    /// This property is used to bind the <see cref="EatMagicScript"/> property during the bind phase.
    /// </summary>
    [ConfigurationProperty("string?",
        Title = "Eat Magic Script Binding Key",
        Description = "The binding key of the script run when the energy of a rechargeable item is consumed, or null when the item has no consumable charges.")]
    public virtual string? EatMagicScriptBindingKey { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Grid Process World Script Binding Key",
        Description = "The binding key of the script used to process the item on the grid during world processing.")]
    public virtual string? GridProcessWorldScriptBindingKey { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Monster Process World Script Binding Key",
        Description = "The binding key of the script used to process the item during monster world processing.")]
    public virtual string? MonsterProcessWorldScriptBindingKey { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Equipment Process World Script Binding Key",
        Description = "The binding key of the script used to process the item during equipment world processing.")]
    public virtual string? EquipmentProcessWorldScriptBindingKey { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Pack Process World Script Binding Key",
        Description = "The binding key of the script used to process the item during pack world processing.")]
    public virtual string? PackProcessWorldScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns an expression that represents the chance that an item that is thrown or fired will break.  Returns 10, or 10%, by default.  This
    /// property is used to bind the <see cref="BreakageChanceProbability"/> property during the bind phase.
    /// </summary>
    [ConfigurationProperty("string",
        Title = "Breakage Chance Probability Expression",
        Description = "The probability expression representing the chance that an item thrown or fired will break.")]
    public virtual string BreakageChanceProbabilityExpression { get; set; } = "10/100";

    /// <summary>
    /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
    /// </summary>
    [ConfigurationProperty("string",
        Title = "Make Object Count Expression",
        Description = "The expression used to determine the number of items created by MakeObject.")]
    public virtual string MakeObjectCountExpression { get; set; } = "1";

    /// <summary>
    /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Gets Damage Multiplier",
        Description = "Determines whether the item multiplies damage against a specific monster race.")]
    public virtual bool GetsDamageMultiplier { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can be sensed; false, otherwise.  Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Identity Can Be Sensed",
        Description = "Determines whether the item can be sensed.")]
    public virtual bool IdentityCanBeSensed { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is armor.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Is Armor",
        Description = "Determines whether the item is armor.")]
    public virtual bool IsArmor { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a weapon.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Is Weapon",
        Description = "Determines whether the item is a weapon.")]
    public virtual bool IsWeapon { get; set; } = false;

    /// <summary>
    /// Returns the number of items contained in the chest; or 0, if the item is not a container.  Returns 0, by default.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Number of Items Contained",
        Description = "The number of items contained in the chest, or zero when the item is not a container.")]
    public virtual int NumberOfItemsContained { get; set; } = 0;

    /// <summary>
    /// Returns the name of the item as it applies to the factory class.  In other words, the name does not include the factory class name.  E.g. The factory class of scrolls would
    /// have names like "light", "magic mapping" and "identify".  This name should be able to uniquely identify the item from other items within the same factory class.
    /// </summary>
    [ConfigurationProperty("string",
        Title = "Name",
        Description = "The name of the item within its factory class, uniquely identifying it from other items in the same factory class.")]
    public virtual string Name { get; set; }

    /// <summary>
    /// Returns the syntax for the description of the item.  The and symbol '&' is used to represent the article (a, an or a number) and the
    /// tilde symbol '~' used to place the 's', 'es', or 'ies' plural form of the noun.
    /// </summary>
    [ConfigurationProperty("string?",
        Title = "Description Syntax",
        Description = "The syntax used to construct the item's description, including article and pluralization markers.")]
    public virtual string? DescriptionSyntax { get; set; } = null; // TODO: Books use a hard-coded realm name when the realm is set at run-time.

    /// <summary>
    /// Returns an alternate coded name for some character classes for known items; null, if there is no altername name; in which the <see cref="DescriptionSyntax"/> property will
    /// be used.  Returns null, by default.  Spellbooks have a alternate names.  Druid, Fanatic, Monk, Priest and Ranger character classes use alternate names.  Character
    /// classes will use alternate naming conventions when <see cref="BaseCharacterClass.UseAlternateItemNames"/> property returns true.
    /// </summary>
    [ConfigurationProperty("string?",
        Title = "Alternate Description Syntax",
        Description = "The alternate description syntax used for items with character-class-specific names, or null to use the standard description syntax.")]
    public virtual string? AlternateDescriptionSyntax { get; set; } = null; // TODO: This coded divine name has hard-coded realm names when realm is set at run-time.

    [ConfigurationProperty("string?",
        Title = "Flavor Suppressed Description Syntax",
        Description = "The description syntax used when the item's flavor is suppressed.")]
    public virtual string? FlavorSuppressedDescriptionSyntax { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Alternate Flavor Suppressed Description Syntax",
        Description = "The alternate description syntax used when the item's flavor is suppressed.")]
    public virtual string? AlternateFlavorSuppressedDescriptionSyntax { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Flavor Unknown Description Syntax",
        Description = "The description syntax used when the item's flavor is unknown.")]
    public virtual string? FlavorUnknownDescriptionSyntax { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Alternate Flavor Unknown Description Syntax",
        Description = "The alternate description syntax used when the item's flavor is unknown.")]
    public virtual string? AlternateFlavorUnknownDescriptionSyntax { get; set; } = null;

    /// <summary>
    /// Returns the number of turns an item that can be zapped needs before it is recharged; or null, if the item cannot be zapped.  A value of zero, means the item does not need any turns to
    /// be recharged after it is used.
    /// </summary>
    [ConfigurationProperty("(string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)?",
        Title = "Zap Binding Tuple",
        Description = "The script name, recharge time, aiming requirement, and mana equivalent for an item that can be zapped.")]
    [ConfigurationTupleItem("ScriptName", Title = "Script Name")]
    [ConfigurationTupleItem("TurnsToRecharge", Title = "Turns to Recharge")]
    [ConfigurationTupleItem("RequiresAiming", Title = "Requires Aiming")]
    [ConfigurationTupleItem("ManaEquivalent", Title = "Mana Equivalent")]
    public virtual (string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapBindingTuple { get; set; } = null;

    [ConfigurationProperty("string",
        Title = "Item Class Binding Key",
        Description = "The binding key of the item class for this item factory.")]
    public virtual string ItemClassBindingKey { get; set; }

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Pack Sort",
        Description = "The sort order index used to arrange items in a pack. Lower values appear first.")]
    public virtual int PackSort { get; set; }

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Items will be wielded in the first slot that is available.  Rings use multiple wield slots for left and right hands.
    /// Returns the pack, by default.  This property is used to bind the <see cref="WieldSlots"/>  property during the binding phase.
    /// </summary>
    [ConfigurationProperty("string[]",
        Title = "Wield Slot Binding Keys",
        Description = "The binding keys of the inventory slots where the item can be wielded, in preference order.")]
    public virtual string[] WieldSlotBindingKeys { get; set; } = new string[] { nameof(WieldSlotsEnum.PackWieldSlot) };

    /// <summary>
    /// Returns true, if the destroy script should ask the player if known items from this factory should be destroyed by setting the applicable 
    /// broken stomp type to true; false, otherwise.  Returns true, by default.  Chests, weapons, armor and orbs of light return false.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Ask Destroy All",
        Description = "Determines whether the destroy script asks the player whether known items from this factory should be destroyed.")]
    public virtual bool AskDestroyAll { get; set; } = true;

    /// <summary>
    /// Returns true, if the object has different quality ratings; false, if items of the factory all have the same quality rating.  Returns false, by default.  
    /// Armor, weapons and orbs of light return true.  Items without quality ratings will always use the Broken stomp type.  Items with various quality ratings will use various
    /// item properties to determine their quality.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Has Quality Ratings",
        Description = "Determines whether items from this factory have different quality ratings.")]
    public virtual bool HasQualityRatings { get; set; } = false;

    /// <summary>
    /// Returns the base armor class rating for items created by the factory.  Returns 0, by default.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Armor Class",
        Description = "The base armor class rating for items created by the factory.")]
    public virtual int ArmorClass { get; set; } = 0;

    /// <summary>
    /// Returns the depth and 1-in probably for where the item can be found; or null, if the item is not found naturally.  Returns null, by default.
    /// </summary>
    [ConfigurationProperty("(int level, int chance)[]?",
        Title = "Depths Found and Chances",
        Description = "The dungeon levels and corresponding one-in chances at which the item can be found naturally, or null when it is not found naturally.")]
    [ConfigurationTupleItem("level", Title = "Level")]
    [ConfigurationTupleItem("chance", Title = "Chance")]
    public virtual (int level, int chance)[]? DepthsFoundAndChances { get; set; } = null; // TODO: Convert the chance into a Roll object

    [ConfigurationProperty("int",
        Title = "Dice Sides",
        Description = "The number of sides on the item's damage die.")]
    public virtual int DiceSides { get; set; } = 0;

    [ConfigurationProperty("int",
        Title = "Level Normally Found",
        Description = "The dungeon level at which the item is normally found.")]
    public virtual int LevelNormallyFound { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus attacks to be assigned to the item.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Initial Bonus Attacks",
        Description = "The initial number of bonus attacks assigned to the item.")]
    public virtual int InitialBonusAttacks { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus infravision to be assigned to the item.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Initial Bonus Infravision",
        Description = "The initial amount of bonus infravision assigned to the item.")]
    public virtual int InitialBonusInfravision { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus speed to be assigned to the item.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Initial Bonus Speed",
        Description = "The initial amount of bonus speed assigned to the item.")]
    public virtual int InitialBonusSpeed { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus search to be assigned to the item.
    /// </summary>
    [ConfigurationProperty("string",
        Title = "Initial Bonus Search Expression",
        Description = "The expression used to determine the initial bonus search value assigned to the item.")]
    public virtual string InitialBonusSearchExpression { get; set; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus stealth to be assigned to the item.
    /// </summary>
    [ConfigurationProperty("string",
        Title = "Initial Bonus Stealth Expression",
        Description = "The expression used to determine the initial bonus stealth value assigned to the item.")]
    public virtual string InitialBonusStealthExpression { get; set; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus tunnel to be assigned to the item.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Initial Bonus Tunnel",
        Description = "The initial amount of bonus tunneling assigned to the item.")]
    public virtual int InitialBonusTunnel { get; set; } = 0;

    /// <summary>
    /// Returns the initial number of turns of light to be assigned to the item.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Initial Turns of Light",
        Description = "The initial number of turns of light assigned to the item.")]
    public virtual int InitialTurnsOfLight { get; set; } = 0;

    /// <summary>
    /// Returns the initial nutritional value that items of this factory will be given.  0 turns is returns by default.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Initial Nutritional Value",
        Description = "The initial nutritional value assigned to items created by this factory.")]
    public virtual int InitialNutritionalValue { get; set; } = 0;

    /// <summary>
    /// Returns the roll expression to determine the initial gold pieces that are given to the player when the item is picked up.  This property must conform to the <see cref="Roll"/> syntax for parsing.  
    /// See <see cref="Game.ParseNumericExpression"/> for syntax details.  This property is used to bind the <see cref="InitialGoldPiecesRoll"/> property during the bind phase.
    /// </summary>
    [ConfigurationProperty("string",
        Title = "Initial Gold Pieces Roll Expression",
        Description = "The roll expression used to determine the initial number of gold pieces given to the player when the item is picked up.")]
    public virtual string InitialGoldPiecesRollExpression { get; set; } = "0";

    /// <summary>
    /// Returns a divisor to be used to compute the amount of experience gained when an applicable character class destroys the book.  Defaults to 4.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Experience Gain Divisor for Destroying",
        Description = "The divisor used to calculate experience gained when an applicable character class destroys the book.")]
    public virtual int ExperienceGainDivisorForDestroying { get; set; } = 0;

    /// <summary>
    /// Returns the names of the spells, in order, that belong to this book; or null, if the item is not a book.  This property is used to bind the Spells property during the binding phase.
    /// </summary>
    [ConfigurationProperty("string[]?",
        Title = "Spell Binding Keys",
        Description = "The binding keys of the spells belonging to this book, in order, or null when the item is not a book.")]
    public virtual string[]? SpellBindingKeys { get; set; } = null;

    /// <summary>
    /// Returns whether or not this factory generates "good" items.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Is Good",
        Description = "Determines whether this factory generates good items.")]
    public virtual bool IsGood { get; set; } = false;

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Is Small",
        Description = "Determines whether the chest is small.")]
    public virtual bool IsSmall { get; set; } = false; // TODO: This property is only valid when IsContainer.  The data type is horrible.

    /// <summary>
    /// Returns the base value for a non flavor-aware item.  Returns 0, by default.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Base Value",
        Description = "The base value of a non-flavor-aware item.")]
    public virtual int BaseValue { get; set; } = 0;

    /// <summary>
    /// Returns true, if the item is susceptible to electricity.  Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Hates Electricity",
        Description = "Determines whether the item is susceptible to electricity.")]
    public virtual bool HatesElectricity { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to fire.  Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Hates Fire",
        Description = "Determines whether the item is susceptible to fire.")]
    public virtual bool HatesFire { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to acid.  Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Hates Acid",
        Description = "Determines whether the item is susceptible to acid.")]
    public virtual bool HatesAcid { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to cold.  Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Hates Cold",
        Description = "Determines whether the item is susceptible to cold.")]
    public virtual bool HatesCold { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of electricity.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Can Provide Sheath of Electricity",
        Description = "Determines whether the item can provide a sheath of electricity.")]
    public virtual bool CanProvideSheathOfElectricity { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of fire.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Can Provide Sheath of Fire",
        Description = "Determines whether the item can provide a sheath of fire.")]
    public virtual bool CanProvideSheathOfFire { get; set; } = false;

    /// <summary>
    /// Returns a 1-in-chance for a random artifact to have activation applied.  Returns 3 by default.  Armor returns double the default.
    /// </summary>
    [ConfigurationProperty("int",
        Title = "Random Artifact Activation Chance",
        Description = "The one-in chance that a random artifact receives an activation.")]
    public virtual int RandartActivationChance { get; set; } = 3;

    /// <summary>
    /// Returns true, if the item provides sunlight, which burns certain races.  Returns false, by default.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Provides Sunlight",
        Description = "Determines whether the item provides sunlight that burns certain races.")]
    public virtual bool ProvidesSunlight { get; set; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can have random resistance bonus applied for biased artifacts.  Returns false for all items except for cloaks, soft armor and hard armor; which return true.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Can Apply Artifact Bias Resistance",
        Description = "Determines whether items from this factory can receive random resistance bonuses from biased artifacts.")]
    public virtual bool CanApplyArtifactBiasResistance { get; set; } = true;

    /// <summary>
    /// Returns true, if an item of this factory can be eaten by a monster with the eat food attack effect.  Returns false for all items except food items; which return true.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Can Be Eaten by Monsters",
        Description = "Determines whether an item from this factory can be eaten by a monster with the eat food attack effect.")]
    public virtual bool CanBeEatenByMonsters { get; set; } = false;

    /// <summary>
    /// Returns the name of the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  Returns null, by default.  This property
    /// is used to bind the <see cref="EatScript"/> property during the bind phase.
    /// </summary>
    [ConfigurationProperty("string?",
        Title = "Eat Script Binding Key",
        Description = "The binding key of the script run when an item from this factory is eaten, or null when items cannot be eaten.")]
    public virtual string? EatScriptBindingKey { get; set; } = null;

    [ConfigurationProperty("bool",
        Title = "Vanishes When Eaten by Skeletons",
        Description = "Determines whether the item vanishes when eaten by skeletons.")]
    public virtual bool VanishesWhenEatenBySkeletons { get; set; } = false;

    /// <summary>
    /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
    /// all food items are consumed except for dwarf bread.  Dwarf bread returns false.
    /// </summary>
    [ConfigurationProperty("bool",
        Title = "Is Consumed When Eaten",
        Description = "Determines whether the food item is completely consumed and removed when eaten.")]
    public virtual bool IsConsumedWhenEaten { get; set; } = true;

    /// <summary>
    /// Returns the name of the activation script for scrolls when read; or null, if the item cannot be read.  Returns null, by default.  This property is used to bind the <see cref="ReadTuple"/> 
    /// property during the bind phase.
    /// <returns>
    /// ManaValue:description Returns the amount of mana channelers can substitute instead of the scroll being used up.
    /// </returns>
    [ConfigurationProperty("(string ScriptName, int ManaValue)?",
        Title = "Read Binding Tuple",
        Description = "The script name and mana value used when the item is read.")]
    [ConfigurationTupleItem("ScriptName", Title = "Script Name")]
    [ConfigurationTupleItem("ManaValue", Title = "Mana Value")]
    public virtual (string ScriptName, int ManaValue)? ReadBindingTuple { get; set; } = null;
}