// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(Title = "Item Factory", EntityNoun = "item factory")]
public class ItemFactoryGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Item Enhancement Binding Key",
        Summary = "The binding key of the item enhancement applied to items created by this factory.",
        DataType = "string?")]
    public virtual string? ItemEnhancementBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the name of the <see cref="ItemFlavor"/> that this item should be assigned.  This assignment overrides the random flavor assignment, when the <see cref="ItemClass"/>
    /// utilizes item flavors.  Returns null, to allow the <see cref="ItemClass"/> to assign a random <see cref="ItemFlavor"/> or when this factory doesn't produce flavored items.
    /// This property is used to bind the <see cref="PreassignedItemFlavor"/> property during the binding phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Preassigned Item Flavor Binding Key",
        Summary = "The binding key of the item flavor assigned to items created by this factory, or null to allow the item class to assign a random flavor.",
        DataType = "string?")]
    public virtual string? PreassignedItemFlavorBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Negative Bonus Damage Represents Broken",
        Summary = "Determines whether a negative bonus damage value represents a broken item.",
        DataType = "bool")]
    public virtual bool NegativeBonusDamageRepresentsBroken { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Negative Bonus Armor Class Represents Broken",
        Summary = "Determines whether a negative bonus armor class value represents a broken item.",
        DataType = "bool")]
    public virtual bool NegativeBonusArmorClassRepresentsBroken { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Negative Bonus Hit Represents Broken",
        Summary = "Determines whether a negative bonus hit value represents a broken item.",
        DataType = "bool")]
    public virtual bool NegativeBonusHitRepresentsBroken { get; set; } = false;

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the <see cref="FlavorColor"/> and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Color",
        Summary = "The color used to render items of this type.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; }

    [ConfigurationMetadata(
        Title = "Slaying Random Artifact Item Enhancement Weighted Random Binding Key",
        Summary = "The binding key of the weighted random configuration used to select slaying item enhancements for random artifacts.",
        DataType = "string?")]
    public virtual string? SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey { get; set; } = nameof(ItemEnhancementWeightedRandomsEnum.SlayingItemEnhancementWeightedRandom);

    /// <summary>
    /// Returns the ceiling value for bonus armor values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Random Artifact Bonus Armor Ceiling",
        Summary = "The maximum bonus armor value allowed when creating a random artifact, or null when no bonus should be added.",
        DataType = "int?")]
    public virtual int? RandomArtifactBonusArmorCeiling { get; set; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus hit values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Random Artifact Bonus Hit Ceiling",
        Summary = "The maximum bonus hit value allowed when creating a random artifact, or null when no bonus should be added.",
        DataType = "int?")]
    public virtual int? RandomArtifactBonusHitCeiling { get; set; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus damage values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Random Artifact Bonus Damage Ceiling",
        Summary = "The maximum bonus damage value allowed when creating a random artifact, or null when no bonus should be added.",
        DataType = "int?")]
    public virtual int? RandomArtifactBonusDamageCeiling { get; set; } = null;

    /// <summary>
    /// Returns the key of the script that is used to refill the item; or null, if the item cannot be refilled.  Returns null, by default.  This property is used to bind the <see cref="RefillScript"/>
    /// property during the binding phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Refill Script Binding Key",
        Summary = "The binding key of the script used to refill the item, or null when the item cannot be refilled.",
        DataType = "string?")]
    public virtual string? RefillScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the symbol to use for rendering the item.  This symbol will be initially used to set the <see cref="FlavorSymol"/> and item catagories that have flavor may the change the
    /// <see cref="FlavorCharacter"/> based on the flavor.  This property is used to bind the <see cref="Symbol"/> property during the bind phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Symbol Binding Key",
        Summary = "The binding key of the symbol used to render the item.",
        DataType = "string")]
    public virtual string SymbolBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Can Be Weapon of Law",
        Summary = "Determines whether the item can be a weapon of law.",
        DataType = "bool")]
    public virtual bool CanBeWeaponOfLaw { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Can Be Weapon of Sharpness",
        Summary = "Determines whether the item can be a weapon of sharpness.",
        DataType = "bool")]
    public virtual bool CanBeWeaponOfSharpness { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Capable of Vorpal Slaying",
        Summary = "Determines whether the item is capable of vorpal slaying.",
        DataType = "bool")]
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
    [ConfigurationMetadata(
        Title = "Use Binding Tuple",
        Summary = "The script binding key, initial charges roll expression, per-charge value, and mana equivalent used when the item is used.",
        DataType = "(string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)?")]
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
    [ConfigurationMetadata(
        Title = "Quaff Binding Tuple",
        Summary = "The quaff script name, optional smash script name, and mana equivalent used when the item is quaffed.",
        DataType = "(string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)?")]
    [ConfigurationTupleItem("QuaffScriptName", Title = "Quaff Script Name")]
    [ConfigurationTupleItem("SmashScriptName", Title = "Smash Script Name")]
    [ConfigurationTupleItem("ManaEquivalent", Title = "Mana Equivalent")]
    public virtual (string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)? QuaffBindingTuple { get; set; } = null;

    /// <summary>
    /// Returns the name of the <see cref="ItemClass"/> that is used as ammunition for this item; or null, if the item is not a ranged weapon.  This property is used to bind
    /// the <see cref="AmmunitionItemFactories"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Ammunition Item Factory Binding Keys",
        Summary = "The binding keys of the item factories used as ammunition for this item, or null when the item is not a ranged weapon.",
        DataType = "string[]?")]
    public virtual string[]? AmmunitionItemFactoryBindingKeys { get; set; } = null;

    /// <summary>
    /// Returns true, if the item can be used to spike a door closed; false, otherwise.  Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Can Spike Door Closed",
        Summary = "Determines whether the item can be used to spike a door closed.",
        DataType = "bool")]
    public virtual bool CanSpikeDoorClosed { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a bow and can project arrows; false, otherwise.  Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Can Project Arrows",
        Summary = "Determines whether the item is a bow that can project arrows.",
        DataType = "bool")]
    public virtual bool CanProjectArrows { get; set; } = false;

    /// <summary>
    /// Returns the maximum number of items that can be enchanted at one time.  A value of 1 is returned, by default.  Ammunition items return 20.  Item counts greater than this value
    /// will have a decreased probability of enchantment.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Enchantment Maximum Count",
        Summary = "The maximum number of items that can be enchanted at one time.",
        DataType = "int")]
    public virtual int EnchantmentMaximumCount { get; set; } = 1;

    /// <summary>
    /// Returns true, if the item is magical and is noticed with the detect magical scoll.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Is Magical",
        Summary = "Determines whether the item is magical and is noticed by the detect magical scroll.",
        DataType = "bool")]
    public virtual bool IsMagical { get; set; } = false;

    /// <summary>
    /// Returns the value of each turn of light for light sources.  Returns 0, by default;
    /// </summary>
    [ConfigurationMetadata(
        Title = "Value Per Turn of Light",
        Summary = "The value of each turn of light for light sources.",
        DataType = "int")]
    public virtual int ValuePerTurnOfLight { get; set; } = 0;

    /// <summary>
    /// Returns the name of the <see cref="IAimWandScript"/> script for wands when aimed, a roll expression to determine the number of charges to assign to new wands and the value of each charge; or null, if the 
    /// item cannot be aimed.  Returns null, by default.  This property is used to bind the <see cref="AimingTuple"/>  property during the bind phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Aiming Binding Tuple",
        Summary = "The activation script name, initial charges roll expression, per-charge value, and mana value for an item that can be aimed.",
        DataType = "(string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)?")]
    [ConfigurationTupleItem("ActivationScriptName", Title = "Activation Script Name")]
    [ConfigurationTupleItem("InitialChargesCountRollExpression", Title = "Initial Charges Count Roll Expression")]
    [ConfigurationTupleItem("PerChargeValue", Title = "Per Charge Value")]
    [ConfigurationTupleItem("ManaValue", Title = "Mana Value")]
    public virtual (string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)? AimingBindingTuple { get; set; } = null;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality that should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.  
    /// Returns false, by default.  Weapons, armor, orbs of light and broken items (items that negatively affect the player) return true.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Broken Stomp",
        Summary = "Determines whether broken items of this factory initially default to being stomped.",
        DataType = "bool")]
    public virtual bool InitialBrokenStomp { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Average Stomp",
        Summary = "Determines whether average-quality items of this factory initially default to being stomped.",
        DataType = "bool")]
    public virtual bool InitialAverageStomp { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Good Stomp",
        Summary = "Determines whether good-quality items of this factory initially default to being stomped.",
        DataType = "bool")]
    public virtual bool InitialGoodStomp { get; set; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Excellent Stomp",
        Summary = "Determines whether excellent-quality items of this factory initially default to being stomped.",
        DataType = "bool")]
    public virtual bool InitialExcellentStomp { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Recharge Script Binding Key",
        Summary = "The binding key of the script used to recharge the item.",
        DataType = "string?")]
    public virtual string? RechargeScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns true, if the item is ignored by monsters.  Returns false for all items, except gold.  Gold isn't picked up by monsters.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Is Ignored by Monsters",
        Summary = "Determines whether the item is ignored by monsters.",
        DataType = "bool")]
    public virtual bool IsIgnoredByMonsters { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a container; false, otherwise.  Containers can be opened (ContainerIsOpen) and trapped (ContainerTraps).
    /// </summary>
    [ConfigurationMetadata(
        Title = "Is Container",
        Summary = "Determines whether the item is a container.",
        DataType = "bool")]
    public virtual bool IsContainer { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a ranged weapon; false, otherwise.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Is Ranged Weapon",
        Summary = "Determines whether the item is a ranged weapon.",
        DataType = "bool")]
    public virtual bool IsRangedWeapon { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Disable Stomp",
        Summary = "Determines whether stomping is disabled for the item.",
        DataType = "bool")]
    public virtual bool DisableStomp { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Enhancement Fixed Artifact Factories Binding Keys",
        Summary = "The binding keys of fixed artifact factories used to provide enhancements for this item factory.",
        DataType = "string[]?")]
    public virtual string[]? EnhancementFixedArtifactFactoriesBindingKeys { get; set; } = null;

    /// <summary>
    /// Returns a damage multiplier when the missile weapon is used.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Missile Damage Multiplier",
        Summary = "The damage multiplier applied when the missile weapon is used.",
        DataType = "int")]
    public virtual int MissileDamageMultiplier { get; set; } = 1;

    /// <summary>
    /// Returns the maximum fuel that can be used for phlogiston.  Returns null, by default, meaning that the light source cannot be used to create a phlogiston.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Maximum Phlogiston",
        Summary = "The maximum amount of fuel that can be used for phlogiston, or null when the light source cannot create phlogiston.",
        DataType = "int?")]
    public virtual int? MaxPhlogiston { get; set; } = null;

    /// <summary>
    /// Returns an array of tuples that define the mass produce for items of this factory when they are sold in a store.  These tuples define a Roll that is applied for additional items to be produced
    /// for items of a cost value or less; or null, if no additional items should be produced based on any cost.  Costs are determined after enhancements are applied.  Returns null, by default.  This property is used
    /// to bind the <see cref="MassProduceTuples"/> property during the bind phase.  The tuples must be sorted by cost and are checked during the bind phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Mass Produce Binding Tuples",
        Summary = "The count and roll expression used to determine additional items produced for items sold in a store based on their cost.",
        DataType = "(int count, string rollExpression)[]?")]
    [ConfigurationTupleItem("count", Title = "Count")]
    [ConfigurationTupleItem("rollExpression", Title = "Roll Expression")]
    public virtual (int count, string rollExpression)[]? MassProduceBindingTuples { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Breaks During Enchantment Probability Expression",
        Summary = "The probability expression that determines the chance the item breaks during enchantment.",
        DataType = "string?")]
    public virtual string? BreaksDuringEnchantmentProbabilityExpression { get; set; } = null;

    /// <summary>
    /// Returns the name of the IEnchantmentScript to run for enchanting items depending on the item power and whether the item is being sold in a store.
    /// </summary>
    /// <returns>
    /// Powers - One or more item power levels (-2, -1, 0, 1, 2) the enchantment applies to; or null, if the enchantments apply to all power levels./>
    /// StoreStock - True, when the enchantment applies only to items sold in a store; false, when the enchantment only applies to items not sold in a store; or null, if the enchantment applies regardless of whether the item is being sold in a store or not.;<para />
    /// ScriptNames - The names of one or more scripts that implement the IEnhancementScript interface to be run to enhance the item when the Powers and StoreStock criteria match.  An empty array will throw during binding.
    /// </returns>
    [ConfigurationMetadata(
        Title = "Enchantment Binding Tuples",
        Summary = "The power levels, store-stock condition, and script names used to determine which enchantment scripts apply.",
        DataType = "(int[]? Powers, bool? StoreStock, string[] ScriptNames)[]?")]
    [ConfigurationTupleItem("Powers", Title = "Powers")]
    [ConfigurationTupleItem("StoreStock", Title = "Store Stock")]
    [ConfigurationTupleItem("ScriptNames", Title = "Script Names")]
    public virtual (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples { get; set; } = null;

    /// <summary>
    /// Returns the name of the script to run, when the energy of a rechargeable item is consumed; or null, if the item does not have charges that can be consumed or those charges cannot be consumed.
    /// This property is used to bind the <see cref="EatMagicScript"/> property during the bind phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Eat Magic Script Binding Key",
        Summary = "The binding key of the script run when the energy of a rechargeable item is consumed, or null when the item has no consumable charges.",
        DataType = "string?")]
    public virtual string? EatMagicScriptBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Grid Process World Script Binding Key",
        Summary = "The binding key of the script used to process the item on the grid during world processing.",
        DataType = "string?")]
    public virtual string? GridProcessWorldScriptBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Monster Process World Script Binding Key",
        Summary = "The binding key of the script used to process the item during monster world processing.",
        DataType = "string?")]
    public virtual string? MonsterProcessWorldScriptBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Equipment Process World Script Binding Key",
        Summary = "The binding key of the script used to process the item during equipment world processing.",
        DataType = "string?")]
    public virtual string? EquipmentProcessWorldScriptBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Pack Process World Script Binding Key",
        Summary = "The binding key of the script used to process the item during pack world processing.",
        DataType = "string?")]
    public virtual string? PackProcessWorldScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns an expression that represents the chance that an item that is thrown or fired will break.  Returns 10, or 10%, by default.  This
    /// property is used to bind the <see cref="BreakageChanceProbability"/> property during the bind phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Breakage Chance Probability Expression",
        Summary = "The probability expression representing the chance that an item thrown or fired will break.",
        DataType = "string")]
    public virtual string BreakageChanceProbabilityExpression { get; set; } = "10/100";

    /// <summary>
    /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Make Object Count Expression",
        Summary = "The expression used to determine the number of items created by MakeObject.",
        DataType = "string")]
    public virtual string MakeObjectCountExpression { get; set; } = "1";

    /// <summary>
    /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Gets Damage Multiplier",
        Summary = "Determines whether the item multiplies damage against a specific monster race.",
        DataType = "bool")]
    public virtual bool GetsDamageMultiplier { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can be sensed; false, otherwise.  Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Identity Can Be Sensed",
        Summary = "Determines whether the item can be sensed.",
        DataType = "bool")]
    public virtual bool IdentityCanBeSensed { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is armor.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Is Armor",
        Summary = "Determines whether the item is armor.",
        DataType = "bool")]
    public virtual bool IsArmor { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is a weapon.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Is Weapon",
        Summary = "Determines whether the item is a weapon.",
        DataType = "bool")]
    public virtual bool IsWeapon { get; set; } = false;

    /// <summary>
    /// Returns the number of items contained in the chest; or 0, if the item is not a container.  Returns 0, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Number of Items Contained",
        Summary = "The number of items contained in the chest, or zero when the item is not a container.",
        DataType = "int")]
    public virtual int NumberOfItemsContained { get; set; } = 0;

    /// <summary>
    /// Returns the name of the item as it applies to the factory class.  In other words, the name does not include the factory class name.  E.g. The factory class of scrolls would
    /// have names like "light", "magic mapping" and "identify".  This name should be able to uniquely identify the item from other items within the same factory class.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Name",
        Summary = "The name of the item within its factory class, uniquely identifying it from other items in the same factory class.",
        DataType = "string")]
    public virtual string Name { get; set; }

    /// <summary>
    /// Returns the syntax for the description of the item.  The and symbol '&' is used to represent the article (a, an or a number) and the
    /// tilde symbol '~' used to place the 's', 'es', or 'ies' plural form of the noun.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Description Syntax",
        Summary = "The syntax used to construct the item's description, including article and pluralization markers.",
        DataType = "string?")]
    public virtual string? DescriptionSyntax { get; set; } = null; // TODO: Books use a hard-coded realm name when the realm is set at run-time.

    /// <summary>
    /// Returns an alternate coded name for some character classes for known items; null, if there is no altername name; in which the <see cref="DescriptionSyntax"/> property will
    /// be used.  Returns null, by default.  Spellbooks have a alternate names.  Druid, Fanatic, Monk, Priest and Ranger character classes use alternate names.  Character
    /// classes will use alternate naming conventions when <see cref="BaseCharacterClass.UseAlternateItemNames"/> property returns true.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Alternate Description Syntax",
        Summary = "The alternate description syntax used for items with character-class-specific names, or null to use the standard description syntax.",
        DataType = "string?")]
    public virtual string? AlternateDescriptionSyntax { get; set; } = null; // TODO: This coded divine name has hard-coded realm names when realm is set at run-time.

    [ConfigurationMetadata(
        Title = "Flavor Suppressed Description Syntax",
        Summary = "The description syntax used when the item's flavor is suppressed.",
        DataType = "string?")]
    public virtual string? FlavorSuppressedDescriptionSyntax { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Alternate Flavor Suppressed Description Syntax",
        Summary = "The alternate description syntax used when the item's flavor is suppressed.",
        DataType = "string?")]
    public virtual string? AlternateFlavorSuppressedDescriptionSyntax { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Flavor Unknown Description Syntax",
        Summary = "The description syntax used when the item's flavor is unknown.",
        DataType = "string?")]
    public virtual string? FlavorUnknownDescriptionSyntax { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Alternate Flavor Unknown Description Syntax",
        Summary = "The alternate description syntax used when the item's flavor is unknown.",
        DataType = "string?")]
    public virtual string? AlternateFlavorUnknownDescriptionSyntax { get; set; } = null;

    /// <summary>
    /// Returns the number of turns an item that can be zapped needs before it is recharged; or null, if the item cannot be zapped.  A value of zero, means the item does not need any turns to
    /// be recharged after it is used.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Zap Binding Tuple",
        Summary = "The script name, recharge time, aiming requirement, and mana equivalent for an item that can be zapped.",
        DataType = "(string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)?")]
    [ConfigurationTupleItem("ScriptName", Title = "Script Name")]
    [ConfigurationTupleItem("TurnsToRecharge", Title = "Turns to Recharge")]
    [ConfigurationTupleItem("RequiresAiming", Title = "Requires Aiming")]
    [ConfigurationTupleItem("ManaEquivalent", Title = "Mana Equivalent")]
    public virtual (string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapBindingTuple { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Item Class Binding Key",
        Summary = "The binding key of the item class for this item factory.",
        DataType = "string")]
    public virtual string ItemClassBindingKey { get; set; }

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Pack Sort",
        Summary = "The sort order index used to arrange items in a pack. Lower values appear first.",
        DataType = "int")]
    public virtual int PackSort { get; set; }

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Items will be wielded in the first slot that is available.  Rings use multiple wield slots for left and right hands.
    /// Returns the pack, by default.  This property is used to bind the <see cref="WieldSlots"/>  property during the binding phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Wield Slot Binding Keys",
        Summary = "The binding keys of the inventory slots where the item can be wielded, in preference order.",
        DataType = "string[]")]
    public virtual string[] WieldSlotBindingKeys { get; set; } = new string[] { nameof(WieldSlotsEnum.PackWieldSlot) };

    /// <summary>
    /// Returns true, if the destroy script should ask the player if known items from this factory should be destroyed by setting the applicable 
    /// broken stomp type to true; false, otherwise.  Returns true, by default.  Chests, weapons, armor and orbs of light return false.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Ask Destroy All",
        Summary = "Determines whether the destroy script asks the player whether known items from this factory should be destroyed.",
        DataType = "bool")]
    public virtual bool AskDestroyAll { get; set; } = true;

    /// <summary>
    /// Returns true, if the object has different quality ratings; false, if items of the factory all have the same quality rating.  Returns false, by default.  
    /// Armor, weapons and orbs of light return true.  Items without quality ratings will always use the Broken stomp type.  Items with various quality ratings will use various
    /// item properties to determine their quality.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Has Quality Ratings",
        Summary = "Determines whether items from this factory have different quality ratings.",
        DataType = "bool")]
    public virtual bool HasQualityRatings { get; set; } = false;

    /// <summary>
    /// Returns the base armor class rating for items created by the factory.  Returns 0, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Armor Class",
        Summary = "The base armor class rating for items created by the factory.",
        DataType = "int")]
    public virtual int ArmorClass { get; set; } = 0;

    /// <summary>
    /// Returns the depth and 1-in probably for where the item can be found; or null, if the item is not found naturally.  Returns null, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Depths Found and Chances",
        Summary = "The dungeon levels and corresponding one-in chances at which the item can be found naturally, or null when it is not found naturally.",
        DataType = "(int level, int chance)[]?")]
    [ConfigurationTupleItem("level", Title = "Level")]
    [ConfigurationTupleItem("chance", Title = "Chance")]
    public virtual (int level, int chance)[]? DepthsFoundAndChances { get; set; } = null; // TODO: Convert the chance into a Roll object

    [ConfigurationMetadata(
        Title = "Dice Sides",
        Summary = "The number of sides on the item's damage die.",
        DataType = "int")]
    public virtual int DiceSides { get; set; } = 0;

    [ConfigurationMetadata(
        Title = "Level Normally Found",
        Summary = "The dungeon level at which the item is normally found.",
        DataType = "int")]
    public virtual int LevelNormallyFound { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus attacks to be assigned to the item.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Bonus Attacks",
        Summary = "The initial number of bonus attacks assigned to the item.",
        DataType = "int")]
    public virtual int InitialBonusAttacks { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus infravision to be assigned to the item.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Bonus Infravision",
        Summary = "The initial amount of bonus infravision assigned to the item.",
        DataType = "int")]
    public virtual int InitialBonusInfravision { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus speed to be assigned to the item.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Bonus Speed",
        Summary = "The initial amount of bonus speed assigned to the item.",
        DataType = "int")]
    public virtual int InitialBonusSpeed { get; set; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus search to be assigned to the item.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Bonus Search Expression",
        Summary = "The expression used to determine the initial bonus search value assigned to the item.",
        DataType = "string")]
    public virtual string InitialBonusSearchExpression { get; set; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus stealth to be assigned to the item.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Bonus Stealth Expression",
        Summary = "The expression used to determine the initial bonus stealth value assigned to the item.",
        DataType = "string")]
    public virtual string InitialBonusStealthExpression { get; set; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus tunnel to be assigned to the item.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Bonus Tunnel",
        Summary = "The initial amount of bonus tunneling assigned to the item.",
        DataType = "int")]
    public virtual int InitialBonusTunnel { get; set; } = 0;

    /// <summary>
    /// Returns the initial number of turns of light to be assigned to the item.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Turns of Light",
        Summary = "The initial number of turns of light assigned to the item.",
        DataType = "int")]
    public virtual int InitialTurnsOfLight { get; set; } = 0;

    /// <summary>
    /// Returns the initial nutritional value that items of this factory will be given.  0 turns is returns by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Nutritional Value",
        Summary = "The initial nutritional value assigned to items created by this factory.",
        DataType = "int")]
    public virtual int InitialNutritionalValue { get; set; } = 0;

    /// <summary>
    /// Returns the roll expression to determine the initial gold pieces that are given to the player when the item is picked up.  This property must conform to the <see cref="Roll"/> syntax for parsing.  
    /// See <see cref="Game.ParseNumericExpression"/> for syntax details.  This property is used to bind the <see cref="InitialGoldPiecesRoll"/> property during the bind phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Initial Gold Pieces Roll Expression",
        Summary = "The roll expression used to determine the initial number of gold pieces given to the player when the item is picked up.",
        DataType = "string")]
    public virtual string InitialGoldPiecesRollExpression { get; set; } = "0";

    /// <summary>
    /// Returns a divisor to be used to compute the amount of experience gained when an applicable character class destroys the book.  Defaults to 4.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Experience Gain Divisor for Destroying",
        Summary = "The divisor used to calculate experience gained when an applicable character class destroys the book.",
        DataType = "int")]
    public virtual int ExperienceGainDivisorForDestroying { get; set; } = 0;

    /// <summary>
    /// Returns the names of the spells, in order, that belong to this book; or null, if the item is not a book.  This property is used to bind the Spells property during the binding phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Spell Binding Keys",
        Summary = "The binding keys of the spells belonging to this book, in order, or null when the item is not a book.",
        DataType = "string[]?")]
    public virtual string[]? SpellBindingKeys { get; set; } = null;

    /// <summary>
    /// Returns whether or not this factory generates "good" items.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Is Good",
        Summary = "Determines whether this factory generates good items.",
        DataType = "bool")]
    public virtual bool IsGood { get; set; } = false;

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Is Small",
        Summary = "Determines whether the chest is small.",
        DataType = "bool")]
    public virtual bool IsSmall { get; set; } = false; // TODO: This property is only valid when IsContainer.  The data type is horrible.

    /// <summary>
    /// Returns the base value for a non flavor-aware item.  Returns 0, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Base Value",
        Summary = "The base value of a non-flavor-aware item.",
        DataType = "int")]
    public virtual int BaseValue { get; set; } = 0;

    /// <summary>
    /// Returns true, if the item is susceptible to electricity.  Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Hates Electricity",
        Summary = "Determines whether the item is susceptible to electricity.",
        DataType = "bool")]
    public virtual bool HatesElectricity { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to fire.  Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Hates Fire",
        Summary = "Determines whether the item is susceptible to fire.",
        DataType = "bool")]
    public virtual bool HatesFire { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to acid.  Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Hates Acid",
        Summary = "Determines whether the item is susceptible to acid.",
        DataType = "bool")]
    public virtual bool HatesAcid { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to cold.  Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Hates Cold",
        Summary = "Determines whether the item is susceptible to cold.",
        DataType = "bool")]
    public virtual bool HatesCold { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of electricity.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Can Provide Sheath of Electricity",
        Summary = "Determines whether the item can provide a sheath of electricity.",
        DataType = "bool")]
    public virtual bool CanProvideSheathOfElectricity { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of fire.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Can Provide Sheath of Fire",
        Summary = "Determines whether the item can provide a sheath of fire.",
        DataType = "bool")]
    public virtual bool CanProvideSheathOfFire { get; set; } = false;

    /// <summary>
    /// Returns a 1-in-chance for a random artifact to have activation applied.  Returns 3 by default.  Armor returns double the default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Random Artifact Activation Chance",
        Summary = "The one-in chance that a random artifact receives an activation.",
        DataType = "int")]
    public virtual int RandartActivationChance { get; set; } = 3;

    /// <summary>
    /// Returns true, if the item provides sunlight, which burns certain races.  Returns false, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Provides Sunlight",
        Summary = "Determines whether the item provides sunlight that burns certain races.",
        DataType = "bool")]
    public virtual bool ProvidesSunlight { get; set; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can have random resistance bonus applied for biased artifacts.  Returns false for all items except for cloaks, soft armor and hard armor; which return true.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Can Apply Artifact Bias Resistance",
        Summary = "Determines whether items from this factory can receive random resistance bonuses from biased artifacts.",
        DataType = "bool")]
    public virtual bool CanApplyArtifactBiasResistance { get; set; } = true;

    /// <summary>
    /// Returns true, if an item of this factory can be eaten by a monster with the eat food attack effect.  Returns false for all items except food items; which return true.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Can Be Eaten by Monsters",
        Summary = "Determines whether an item from this factory can be eaten by a monster with the eat food attack effect.",
        DataType = "bool")]
    public virtual bool CanBeEatenByMonsters { get; set; } = false;

    /// <summary>
    /// Returns the name of the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  Returns null, by default.  This property
    /// is used to bind the <see cref="EatScript"/> property during the bind phase.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Eat Script Binding Key",
        Summary = "The binding key of the script run when an item from this factory is eaten, or null when items cannot be eaten.",
        DataType = "string?")]
    public virtual string? EatScriptBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Vanishes When Eaten by Skeletons",
        Summary = "Determines whether the item vanishes when eaten by skeletons.",
        DataType = "bool")]
    public virtual bool VanishesWhenEatenBySkeletons { get; set; } = false;

    /// <summary>
    /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
    /// all food items are consumed except for dwarf bread.  Dwarf bread returns false.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Is Consumed When Eaten",
        Summary = "Determines whether the food item is completely consumed and removed when eaten.",
        DataType = "bool")]
    public virtual bool IsConsumedWhenEaten { get; set; } = true;

    /// <summary>
    /// Returns the name of the activation script for scrolls when read; or null, if the item cannot be read.  Returns null, by default.  This property is used to bind the <see cref="ReadTuple"/> 
    /// property during the bind phase.
    /// <returns>
    /// ManaValue:description Returns the amount of mana channelers can substitute instead of the scroll being used up.
    /// </returns>
    [ConfigurationMetadata(
        Title = "Read Binding Tuple",
        Summary = "The script name and mana value used when the item is read.",
        DataType = "(string ScriptName, int ManaValue)?")]
    [ConfigurationTupleItem("ScriptName", Title = "Script Name")]
    [ConfigurationTupleItem("ManaValue", Title = "Mana Value")]
    public virtual (string ScriptName, int ManaValue)? ReadBindingTuple { get; set; } = null;
}