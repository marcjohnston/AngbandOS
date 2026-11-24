using AngbandOS.Core.Interface.Configuration.Annotations;
using System.Reflection;

namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents an interface that describes the configuration data that the GameServer.Play method accepts.  This configuration data is used to completely
/// configure a new game.  Use the ConfigurationMetadata object to get metadata details that can be used to generate configuration data.
/// </summary>
public class GameConfiguration
{
    public GameConfiguration()
    {
        // Dynamically load the game configuration with all singletons found in the containing assembly.
        Assembly assembly = GetType().Assembly;
        MergeAllSingletonsFromAssembly(this, assembly);
    }

    /// <summary>
    /// Returns a string representation for composite key.  The returned key is compliant for filenames and ensures keys do not collide in namespace.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public static string GetCompositeKey(params string?[] keys)
    {
        const char wildCardCharacter = '~';
        const char keyDelimiter = '-';
        string compositeKey = "";
        foreach (string? key in keys)
        {
            if (String.IsNullOrEmpty(key))
            {
                compositeKey = $"{StringLibrary.DelimitIf(compositeKey, keyDelimiter, wildCardCharacter)}";
            }
            else
            {
                if (key.Contains("-") || key.Contains(wildCardCharacter))
                {
                    throw new Exception($"The singleton key {key} presented for composite generation cannot contain the reserved character '{keyDelimiter}' or '{wildCardCharacter}'.");
                }
                compositeKey = $"{StringLibrary.DelimitIf(compositeKey, keyDelimiter, key)}";
            }
        }
        return compositeKey;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keys"></param>
    /// <returns>
    /// This version is used by the <see cref="OutfitManifest"/> because the bindings have equalities with them.
    /// </returns>
    public static string GetCompositeKey(params (string[]? value, bool isEqual)?[] keys)
    {
        const string nullToken = "";
        const string wildCardToken = "~";
        const string keyDelimiter = "_";
        string compositeKey = "";
        string currentDelimiter = "";
        foreach ((string[]? MatchValues, bool IsEqual)? key in keys)
        {
            compositeKey = $"{compositeKey}{currentDelimiter}";
            currentDelimiter = keyDelimiter;

            // Check to see if the key represents a wildcard--match both null and all non-null values.
            if (key is null)
            {
                compositeKey = $"{compositeKey}{wildCardToken}";
            }
            else
            {
                // Test to ensure compliance for the unique key.
                //if (key.Value == "")
                //{
                //    throw new Exception($"Blank singleton key value are not supported for composite generation.");
                //}
                //if (keyDelimiter != "" && value.Contains(keyDelimiter) || wildCardToken != "" && value.Contains(wildCardToken) || nullToken != "" && value.Contains(nullToken))
                //{
                //    throw new Exception($"The singleton key value {value} presented for composite generation is invalid.");
                //}
                if (key.Value.MatchValues is null)
                {
                    compositeKey = $"{compositeKey}{nullToken}";
                }
                else
                {
                    compositeKey = $"{compositeKey}{(key.Value.IsEqual ? "+" : "-")}";
                    foreach (string matchValue in key.Value.MatchValues)
                    {
                        compositeKey = $"{compositeKey}{matchValue}";
                    }
                }
            }

        }
        return compositeKey;
    }

    private static T[] LoadFromAssembly<T>(Assembly assembly) where T : class, new()
    {
        List<T> singletonsList = new List<T>();

        foreach (var type in assembly.GetTypes())
        {
            if (typeof(T).IsAssignableFrom(type))
            {
                T? singleton = (T?)Activator.CreateInstance(type);
                if (singleton is null)
                {
                    throw new Exception("Error in LoadFromAssembly generating singleton.");
                }
                singletonsList.Add(singleton);
            }
        }
        return singletonsList.ToArray();
    }

    public static void MergeAllSingletonsFromAssembly(GameConfiguration gameConfiguration, Assembly assembly)
    {
        gameConfiguration.DurationLearnedKnowledges = LoadFromAssembly<DurationLearnedKnowledgeGameConfiguration>(assembly);
        gameConfiguration.DamageLearnedKnowledges = LoadFromAssembly<DamageLearnedKnowledgeGameConfiguration>(assembly);
        gameConfiguration.RangeLearnedKnowledges = LoadFromAssembly<RangeLearnedKnowledgeGameConfiguration>(assembly);
        gameConfiguration.ExperienceLearnedKnowledges = LoadFromAssembly<ExperienceLearnedKnowledgeGameConfiguration>(assembly);

        gameConfiguration.CharacterClassAndRaceInnateTotals = LoadFromAssembly<InnateTotalsGameConfiguration>(assembly);
        gameConfiguration.Towns = LoadFromAssembly<TownGameConfiguration>(assembly);
        gameConfiguration.Shopkeepers = LoadFromAssembly<ShopkeeperGameConfiguration>(assembly);
        gameConfiguration.GameCommands = LoadFromAssembly<GameCommandGameConfiguration>(assembly);
        gameConfiguration.StoreCommands = LoadFromAssembly<StoreCommandGameConfiguration>(assembly);
        gameConfiguration.HelpGroups = LoadFromAssembly<HelpGroupGameConfiguration>(assembly);
        gameConfiguration.MonsterRaces = LoadFromAssembly<MonsterRaceGameConfiguration>(assembly);
        gameConfiguration.Symbols = LoadFromAssembly<SymbolGameConfiguration>(assembly);
        gameConfiguration.Vaults = LoadFromAssembly<VaultGameConfiguration>(assembly);
        gameConfiguration.DungeonGuardians = LoadFromAssembly<DungeonGuardianGameConfiguration>(assembly);
        gameConfiguration.Dungeons = LoadFromAssembly<DungeonGameConfiguration>(assembly);
        gameConfiguration.StoreFactories = LoadFromAssembly<StoreFactoryGameConfiguration>(assembly);
        gameConfiguration.ProjectileGraphics = LoadFromAssembly<ProjectileGraphicGameConfiguration>(assembly);
        gameConfiguration.ItemFlavors = LoadFromAssembly<ItemFlavorGameConfiguration>(assembly);
        gameConfiguration.ClassSpells = LoadFromAssembly<CharacterClassSpellGameConfiguration>(assembly);
        gameConfiguration.WizardCommands = LoadFromAssembly<WizardCommandGameConfiguration>(assembly);
        gameConfiguration.Tiles = LoadFromAssembly<TileGameConfiguration>(assembly);
        gameConfiguration.Animations = LoadFromAssembly<AnimationGameConfiguration>(assembly);
        gameConfiguration.Spells = LoadFromAssembly<SpellGameConfiguration>(assembly);
        gameConfiguration.Plurals = LoadFromAssembly<PluralGameConfiguration>(assembly);
        gameConfiguration.Attacks = LoadFromAssembly<AttackGameConfiguration>(assembly);
        gameConfiguration.Gods = LoadFromAssembly<GodGameConfiguration>(assembly);
        gameConfiguration.SyllableSets = LoadFromAssembly<SyllableSetGameConfiguration>(assembly);
        gameConfiguration.Projectiles = LoadFromAssembly<ProjectileGameConfiguration>(assembly);
        gameConfiguration.ProjectileScripts = LoadFromAssembly<ProjectileScriptGameConfiguration>(assembly);
        gameConfiguration.ArtifactBiasWeightedRandoms = LoadFromAssembly<ArtifactBiasWeightedRandomGameConfiguration>(assembly);
        gameConfiguration.ItemClasses = LoadFromAssembly<ItemClassGameConfiguration>(assembly);
        gameConfiguration.ItemEnhancements = LoadFromAssembly<ItemEnhancementGameConfiguration>(assembly);
        gameConfiguration.ItemEnhancementWeightedRandoms = LoadFromAssembly<ItemEnhancementWeightedRandomGameConfiguration>(assembly);
        gameConfiguration.ItemFactories = LoadFromAssembly<ItemFactoryGameConfiguration>(assembly);
        gameConfiguration.ItemIdentifications = LoadFromAssembly<ItemIdentificationGameConfiguration>(assembly);
        gameConfiguration.ProjectileWeightedRandomScripts = LoadFromAssembly<ProjectileScriptWeightedRandomGameConfiguration>(assembly);
        gameConfiguration.ConditionalWidgets = LoadFromAssembly<ConditionalWidgetGameConfiguration>(assembly);
        gameConfiguration.DateWidgets = LoadFromAssembly<DateWidgetGameConfiguration>(assembly);
        gameConfiguration.IntWidgets = LoadFromAssembly<IntWidgetGameConfiguration>(assembly);
        gameConfiguration.MapWidgets = LoadFromAssembly<MapWidgetGameConfiguration>(assembly);
        gameConfiguration.MaxRangedWidgets = LoadFromAssembly<MaxRangedWidgetGameConfiguration>(assembly);
        gameConfiguration.RangedWidgets = LoadFromAssembly<RangedWidgetGameConfiguration>(assembly);
        gameConfiguration.StringWidgets = LoadFromAssembly<StringWidgetGameConfiguration>(assembly);
        gameConfiguration.GameMessageWidgets = LoadFromAssembly<GameMessageWidgetGameConfiguration>(assembly);
        gameConfiguration.LabelWidgets = LoadFromAssembly<LabelWidgetGameConfiguration>(assembly);
        gameConfiguration.TimeWidgets = LoadFromAssembly<TimeWidgetGameConfiguration>(assembly);
        gameConfiguration.NullableStringsTextAreaWidgets = LoadFromAssembly<TextWidgetGameConfiguration>(assembly);
        gameConfiguration.RaceGenders = LoadFromAssembly<RaceGenderGameConfiguration>(assembly);
        gameConfiguration.Genders = LoadFromAssembly<GenderGameConfiguration>(assembly);
        gameConfiguration.PhysicalAttributeSets = LoadFromAssembly<PhysicalAttributeSetGameConfiguration>(assembly);
        gameConfiguration.Realms = LoadFromAssembly<RealmGameConfiguration>(assembly);
        gameConfiguration.RealmCharacterClasses = LoadFromAssembly<RealmCharacterClassGameConfiguration>(assembly);
        gameConfiguration.Views = LoadFromAssembly<ViewGameConfiguration>(assembly);
        gameConfiguration.SummonScripts = LoadFromAssembly<SummonScriptGameConfiguration>(assembly);
        gameConfiguration.MappedSpellScripts = LoadFromAssembly<MappedSpellScriptGameConfiguration>(assembly);
        gameConfiguration.SummonWeightedRandoms = LoadFromAssembly<SummonWeightedRandomGameConfiguration>(assembly);
        gameConfiguration.ItemFactoryWeightedRandoms = LoadFromAssembly<ItemFactoryWeightedRandomGameConfiguration>(assembly);
        gameConfiguration.TimerScripts = LoadFromAssembly<TimerScriptGameConfiguration>(assembly);
        gameConfiguration.RenderMessageScripts = LoadFromAssembly<RenderMessageScriptGameConfiguration>(assembly);
        gameConfiguration.MartialArtsAttacks = LoadFromAssembly<MartialArtsAttackGameConfiguration>(assembly);
        gameConfiguration.AbilityScoreScripts = LoadFromAssembly<AbilityScoreScriptGameConfiguration>(assembly);
        gameConfiguration.ChestTrapCombinations = LoadFromAssembly<ChestTrapCombinationGameConfiguration>(assembly);
        gameConfiguration.Patrons = LoadFromAssembly<PatronGameConfiguration>(assembly);
        gameConfiguration.RacialPowerTests = LoadFromAssembly<RacialPowerTestGameConfiguration>(assembly);
        gameConfiguration.RaceAbilities = LoadFromAssembly<RaceAbilityGameConfiguration>(assembly);
        gameConfiguration.RacialPowers = LoadFromAssembly<RacePowerGameConfiguration>(assembly);
        gameConfiguration.RangedWeaponBonuses = LoadFromAssembly<RangedWeaponBonusGameConfiguration>(assembly);
        gameConfiguration.ConditionalScripts = LoadFromAssembly<ConditionalScriptGameConfiguration>(assembly);
        gameConfiguration.CharacterClassAbilities = LoadFromAssembly<CharacterClassAbilityGameConfiguration>(assembly);
        gameConfiguration.Activations = LoadFromAssembly<ActivationGameConfiguration>(assembly);
        gameConfiguration.ItemFilters = LoadFromAssembly<ItemFilterGameConfiguration>(assembly);
        gameConfiguration.ProductOfSumsBoolFunctions = LoadFromAssembly<ConditionalGameConfiguration>(assembly);
        gameConfiguration.RechargeItemScripts = LoadFromAssembly<RechargeItemScriptGameConfiguration>(assembly);
        gameConfiguration.Talents = LoadFromAssembly<TalentGameConfiguration>(assembly);
        gameConfiguration.TeleportSelfScripts = LoadFromAssembly<TeleportSelfScriptGameConfiguration>(assembly);
        gameConfiguration.MappedItemEnhancements = LoadFromAssembly<MappedItemEnhancementGameConfiguration>(assembly);
        gameConfiguration.ChestTraps = LoadFromAssembly<ChestTrapGameConfiguration>(assembly);
        gameConfiguration.OutfitManifests = LoadFromAssembly<OutfitManifestGameConfiguration>(assembly);
        gameConfiguration.AttributeFilters = LoadFromAssembly<AttributeFilterGameConfiguration>(assembly);

        gameConfiguration.ProjectileMonsterSpells = LoadFromAssembly<ProjectileMonsterSpellGameConfiguration>(assembly);
        gameConfiguration.CauseWoundsMonsterSpells = LoadFromAssembly<CauseWoundsMonsterSpellGameConfiguration>(assembly);
        gameConfiguration.ScriptMonsterSpells = LoadFromAssembly<ScriptMonsterSpellGameConfiguration>(assembly);
        gameConfiguration.SummonMonsterSpells = LoadFromAssembly<SummonMonsterSpellGameConfiguration>(assembly);

        gameConfiguration.OrAttributes = LoadFromAssembly<BitwiseOrAttributeGameConfiguration>(assembly);
        gameConfiguration.SumAttributes = LoadFromAssembly<SummationAttributeGameConfiguration>(assembly);
        gameConfiguration.ScriptsAttributes = LoadFromAssembly<ScriptsAttributeGameConfiguration>(assembly);
        gameConfiguration.ColorEnumAttributes = LoadFromAssembly<ColorEnumAttributeGameConfiguration>(assembly);
        gameConfiguration.ArtifactBiasAttributes = LoadFromAssembly<ArtifactBiasNullableReferenceAttributeGameConfiguration>(assembly);
        gameConfiguration.StringAttributes = LoadFromAssembly<StringNullableReferenceAttributeGameConfiguration>(assembly);
    }

    [ConfigurationCollection(
        "Towns",
        Title = "Towns",
        Summary = "Null to load towns from the assembly; otherwise a collection of towns to load into the SingletonRepository.",
        EntityNounTitle = "Town")]
    public virtual TownGameConfiguration[]? Towns { get; set; } = null;

    [ConfigurationCollection(
        "Shopkeepers",
        Title = "Shopkeepers",
        Summary = "Collection of shopkeeper configurations.",
        EntityNounTitle = "Shopkeeper")]
    public virtual ShopkeeperGameConfiguration[]? Shopkeepers { get; set; } = null;

    [ConfigurationCollection(
        "GameCommands",
        Title = "Game Commands",
        Summary = "Collection of game command configurations.",
        EntityNounTitle = "Game Command")]
    public virtual GameCommandGameConfiguration[]? GameCommands { get; set; } = null;

    [ConfigurationCollection(
        "StoreCommands",
        Title = "Store Commands",
        Summary = "Collection of store command configurations.",
        EntityNounTitle = "Store Command")]
    public virtual StoreCommandGameConfiguration[]? StoreCommands { get; set; } = null;

    [ConfigurationCollection(
        "HelpGroups",
        Title = "Help Groups",
        Summary = "Collection of help group configurations.",
        EntityNounTitle = "Help Group")]
    public virtual HelpGroupGameConfiguration[]? HelpGroups { get; set; } = null;

    [ConfigurationCollection(
        "MonsterRaces",
        Title = "Monster Races",
        Summary = "Collection of monster race configurations.",
        EntityNounTitle = "Monster Race")]
    public virtual MonsterRaceGameConfiguration[]? MonsterRaces { get; set; } = null;

    [ConfigurationCollection(
        "OutfitManifests",
        Title = "Outfit Manifests",
        Summary = "Collection of outfit manifest configurations.",
        EntityNounTitle = "Outfit Manifest")]
    public virtual OutfitManifestGameConfiguration[]? OutfitManifests { get; set; } = null;

    [ConfigurationCollection(
        "Symbols",
        Title = "Symbols",
        Summary = "Collection of symbol configurations.",
        EntityNounTitle = "Symbol")]
    public virtual SymbolGameConfiguration[]? Symbols { get; set; } = null;

    [ConfigurationCollection(
        "Vaults",
        Title = "Vaults",
        Summary = "Collection of vault configurations.",
        EntityNounTitle = "Vault")]
    public virtual VaultGameConfiguration[]? Vaults { get; set; } = null;

    [ConfigurationCollection(
        "DungeonGuardians",
        Title = "Dungeon Guardians",
        Summary = "Collection of dungeon guardian configurations.",
        EntityNounTitle = "Dungeon Guardian")]
    public virtual DungeonGuardianGameConfiguration[]? DungeonGuardians { get; set; } = null;

    [ConfigurationCollection(
        "DamageLearnedKnowledges",
        Title = "Damage Learned Knowledges",
        Summary = "Collection of damage learned-knowledge configurations.",
        EntityNounTitle = "Damage Learned Knowledge")]
    public virtual DamageLearnedKnowledgeGameConfiguration[]? DamageLearnedKnowledges { get; set; } = null;

    [ConfigurationCollection(
        "DurationLearnedKnowledges",
        Title = "Duration Learned Knowledges",
        Summary = "Collection of duration learned-knowledge configurations.",
        EntityNounTitle = "Duration Learned Knowledge")]
    public virtual DurationLearnedKnowledgeGameConfiguration[]? DurationLearnedKnowledges { get; set; } = null;

    [ConfigurationCollection(
        "RangeLearnedKnowledges",
        Title = "Range Learned Knowledges",
        Summary = "Collection of range learned-knowledge configurations.",
        EntityNounTitle = "Range Learned Knowledge")]
    public virtual RangeLearnedKnowledgeGameConfiguration[]? RangeLearnedKnowledges { get; set; } = null;

    [ConfigurationCollection(
        "ExperienceLearnedKnowledges",
        Title = "Experience Learned Knowledges",
        Summary = "Collection of experience learned-knowledge configurations.",
        EntityNounTitle = "Experience Learned Knowledge")]
    public virtual ExperienceLearnedKnowledgeGameConfiguration[]? ExperienceLearnedKnowledges { get; set; } = null;

    [ConfigurationCollection(
        "Dungeons",
        Title = "Dungeons",
        Summary = "Collection of dungeon configurations.",
        EntityNounTitle = "Dungeon")]
    public virtual DungeonGameConfiguration[]? Dungeons { get; set; } = null;

    [ConfigurationCollection(
        "StoreFactories",
        Title = "Store Factories",
        Summary = "Factories used to create stores within towns.",
        EntityNounTitle = "Store Factory")]
    public virtual StoreFactoryGameConfiguration[]? StoreFactories { get; set; } = null;

    [ConfigurationCollection(
        "ProjectileGraphics",
        Title = "Projectile Graphics",
        Summary = "Collection of projectile graphic configurations.",
        EntityNounTitle = "Projectile Graphic")]
    public virtual ProjectileGraphicGameConfiguration[]? ProjectileGraphics { get; set; } = null;

    [ConfigurationCollection(
        "ItemFlavors",
        Title = "Item Flavors",
        Summary = "Collection of item flavor configurations.",
        EntityNounTitle = "Item Flavor")]
    public virtual ItemFlavorGameConfiguration[]? ItemFlavors { get; set; } = null;

    [ConfigurationCollection(
        "ClassSpells",
        Title = "Class Spells",
        Summary = "Collection of character class spell configurations.",
        EntityNounTitle = "Character Class Spell")]
    public virtual CharacterClassSpellGameConfiguration[]? ClassSpells { get; set; } = null;

    [ConfigurationCollection(
        "WizardCommands",
        Title = "Wizard Commands",
        Summary = "Collection of wizard command configurations.",
        EntityNounTitle = "Wizard Command")]
    public virtual WizardCommandGameConfiguration[]? WizardCommands { get; set; } = null;

    [ConfigurationCollection(
        "Tiles",
        Title = "Tiles",
        Summary = "Collection of tile configurations.",
        EntityNounTitle = "Tile")]
    public virtual TileGameConfiguration[]? Tiles { get; set; } = null;

    [ConfigurationCollection(
        "Animations",
        Title = "Animations",
        Summary = "Collection of animation configurations.",
        EntityNounTitle = "Animation")]
    public virtual AnimationGameConfiguration[]? Animations { get; set; } = null;

    [ConfigurationCollection(
        "Spells",
        Title = "Spells",
        Summary = "Collection of spell configurations.",
        EntityNounTitle = "Spell")]
    public virtual SpellGameConfiguration[]? Spells { get; set; } = null;

    [ConfigurationCollection(
        "Plurals",
        Title = "Plurals",
        Summary = "Collection of pluralization configurations.",
        EntityNounTitle = "Plural")]
    public virtual PluralGameConfiguration[]? Plurals { get; set; } = null;

    [ConfigurationCollection(
        "Attacks",
        Title = "Attacks",
        Summary = "Collection of attack configurations.",
        EntityNounTitle = "Attack")]
    public virtual AttackGameConfiguration[]? Attacks { get; set; } = null;

    [ConfigurationCollection(
        "AttributeFilters",
        Title = "Attribute Filters",
        Summary = "Collection of attribute filter configurations.",
        EntityNounTitle = "Attribute Filter")]
    public virtual AttributeFilterGameConfiguration[]? AttributeFilters { get; set; } = null;

    [ConfigurationCollection(
        "OrAttributes",
        Title = "Or Attributes",
        Summary = "Collection of bitwise-or attribute configurations.",
        EntityNounTitle = "Bitwise-Or Attribute")]
    public virtual BitwiseOrAttributeGameConfiguration[]? OrAttributes { get; set; } = null;

    [ConfigurationCollection(
        "SumAttributes",
        Title = "Sum Attributes",
        Summary = "Collection of summation attribute configurations.",
        EntityNounTitle = "Summation Attribute")]
    public virtual SummationAttributeGameConfiguration[]? SumAttributes { get; set; } = null;

    [ConfigurationCollection(
        "ScriptsAttributes",
        Title = "Scripts Attributes",
        Summary = "Collection of scripts attribute configurations.",
        EntityNounTitle = "Scripts Attribute")]
    public virtual ScriptsAttributeGameConfiguration[]? ScriptsAttributes { get; set; } = null;

    [ConfigurationCollection(
        "ColorEnumAttributes",
        Title = "Color Enum Attributes",
        Summary = "Collection of color-enum attribute configurations.",
        EntityNounTitle = "Color Enum Attribute")]
    public virtual ColorEnumAttributeGameConfiguration[]? ColorEnumAttributes { get; set; } = null;

    [ConfigurationCollection(
        "ArtifactBiasAttributes",
        Title = "Artifact Bias Attributes",
        Summary = "Collection of artifact-bias attribute configurations.",
        EntityNounTitle = "Artifact Bias Attribute")]
    public virtual ArtifactBiasNullableReferenceAttributeGameConfiguration[]? ArtifactBiasAttributes { get; set; } = null;

    [ConfigurationCollection(
        "StringAttributes",
        Title = "String Attributes",
        Summary = "Collection of string attribute configurations.",
        EntityNounTitle = "String Attribute")]
    public virtual StringNullableReferenceAttributeGameConfiguration[]? StringAttributes { get; set; } = null;

    [ConfigurationCollection(
        "Gods",
        Title = "Gods",
        Summary = "Collection of god configurations.",
        EntityNounTitle = "God")]
    public virtual GodGameConfiguration[]? Gods { get; set; } = null;

    [ConfigurationCollection(
        "SyllableSets",
        Title = "Syllable Sets",
        Summary = "Collection of syllable set configurations.",
        EntityNounTitle = "Syllable Set")]
    public virtual SyllableSetGameConfiguration[]? SyllableSets { get; set; } = null;

    [ConfigurationCollection(
        "Projectiles",
        Title = "Projectiles",
        Summary = "Collection of projectile configurations.",
        EntityNounTitle = "Projectile")]
    public virtual ProjectileGameConfiguration[]? Projectiles { get; set; } = null;

    [ConfigurationCollection(
        "ProjectileScripts",
        Title = "Projectile Scripts",
        Summary = "Collection of projectile script configurations.",
        EntityNounTitle = "Projectile Script")]
    public virtual ProjectileScriptGameConfiguration[]? ProjectileScripts { get; set; } = null;

    [ConfigurationCollection(
        "MonsterSpells",
        Title = "Projectile Monster Spells",
        Summary = "Collection of projectile monster spell configurations.",
        EntityNounTitle = "Projectile Monster Spell")]
    public virtual ProjectileMonsterSpellGameConfiguration[]? ProjectileMonsterSpells { get; set; } = null;

    [ConfigurationCollection(
        "MonsterSpells",
        Title = "Cause Wounds Monster Spells",
        Summary = "Collection of cause-wounds monster spell configurations.",
        EntityNounTitle = "Cause Wounds Monster Spell")]
    public virtual CauseWoundsMonsterSpellGameConfiguration[]? CauseWoundsMonsterSpells { get; set; } = null;

    [ConfigurationCollection(
        "MonsterSpells",
        Title = "Script Monster Spells",
        Summary = "Collection of script monster spell configurations.",
        EntityNounTitle = "Script Monster Spell")]
    public virtual ScriptMonsterSpellGameConfiguration[]? ScriptMonsterSpells { get; set; } = null;

    [ConfigurationCollection(
        "MonsterSpells",
        Title = "Summon Monster Spells",
        Summary = "Collection of summon monster spell configurations.",
        EntityNounTitle = "Summon Monster Spell")]
    public virtual SummonMonsterSpellGameConfiguration[]? SummonMonsterSpells { get; set; } = null;

    [ConfigurationCollection(
        "ArtifactBiasWeightedRandoms",
        Title = "Artifact Bias Weighted Randoms",
        Summary = "Collection of artifact-bias weighted-random configurations.",
        EntityNounTitle = "Artifact Bias Weighted Random")]
    public virtual ArtifactBiasWeightedRandomGameConfiguration[]? ArtifactBiasWeightedRandoms { get; set; } = null;

    [ConfigurationCollection(
        "ItemClasses",
        Title = "Item Classes",
        Summary = "Collection of item class configurations.",
        EntityNounTitle = "Item Class")]
    public virtual ItemClassGameConfiguration[]? ItemClasses { get; set; } = null;

    [ConfigurationCollection(
        "ItemEnhancements",
        Title = "Item Enhancements",
        Summary = "Collection of item enhancement configurations.",
        EntityNounTitle = "Item Enhancement")]
    public virtual ItemEnhancementGameConfiguration[]? ItemEnhancements { get; set; } = null;

    [ConfigurationCollection(
        "ItemEnhancementWeightedRandoms",
        Title = "Item Enhancement Weighted Randoms",
        Summary = "Collection of item-enhancement weighted-random configurations.",
        EntityNounTitle = "Item Enhancement Weighted Random")]
    public virtual ItemEnhancementWeightedRandomGameConfiguration[]? ItemEnhancementWeightedRandoms { get; set; } = null;

    [ConfigurationCollection(
        "ItemIdentifications",
        Title = "Item Identifications",
        Summary = "Collection of item identification configurations.",
        EntityNounTitle = "Item Identification")]
    public virtual ItemIdentificationGameConfiguration[]? ItemIdentifications { get; set; } = null;

    [ConfigurationCollection(
        "ItemFactories",
        Title = "Item Factories",
        Summary = "Collection of item factory configurations.",
        EntityNounTitle = "Item Factory")]
    public virtual ItemFactoryGameConfiguration[]? ItemFactories { get; set; } = null;

    [ConfigurationCollection(
        "ProjectileWeightedRandomScripts",
        Title = "Projectile Weighted Random Scripts",
        Summary = "Collection of projectile-weighted-random script configurations.",
        EntityNounTitle = "Projectile Script Weighted Random")]
    public virtual ProjectileScriptWeightedRandomGameConfiguration[]? ProjectileWeightedRandomScripts { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Conditional Widgets",
        Summary = "Collection of conditional widget configurations.",
        EntityNounTitle = "Conditional Widget")]
    public virtual ConditionalWidgetGameConfiguration[]? ConditionalWidgets { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Date Widgets",
        Summary = "Collection of date widget configurations.",
        EntityNounTitle = "Date Widget")]
    public virtual DateWidgetGameConfiguration[]? DateWidgets { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Int Widgets",
        Summary = "Collection of int widget configurations.",
        EntityNounTitle = "Int Widget")]
    public virtual IntWidgetGameConfiguration[]? IntWidgets { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Map Widgets",
        Summary = "Collection of map widget configurations.",
        EntityNounTitle = "Map Widget")]
    public virtual MapWidgetGameConfiguration[]? MapWidgets { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Max Ranged Widgets",
        Summary = "Collection of max-ranged widget configurations.",
        EntityNounTitle = "Max Ranged Widget")]
    public virtual MaxRangedWidgetGameConfiguration[]? MaxRangedWidgets { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Ranged Widgets",
        Summary = "Collection of ranged widget configurations.",
        EntityNounTitle = "Ranged Widget")]
    public virtual RangedWidgetGameConfiguration[]? RangedWidgets { get; set; } = null;

    [ConfigurationCollection(
        "RangedWeaponBonuses",
        Title = "Ranged Weapon Bonuses",
        Summary = "Collection of ranged weapon bonus configurations.",
        EntityNounTitle = "Ranged Weapon Bonus")]
    public virtual RangedWeaponBonusGameConfiguration[]? RangedWeaponBonuses { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "String Widgets",
        Summary = "Collection of string widget configurations.",
        EntityNounTitle = "String Widget")]
    public virtual StringWidgetGameConfiguration[]? StringWidgets { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Game Message Widgets",
        Summary = "Collection of game-message widget configurations.",
        EntityNounTitle = "Game Message Widget")]
    public virtual GameMessageWidgetGameConfiguration[]? GameMessageWidgets { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Label Widgets",
        Summary = "Collection of label widget configurations.",
        EntityNounTitle = "Label Widget")]
    public virtual LabelWidgetGameConfiguration[]? LabelWidgets { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Time Widgets",
        Summary = "Collection of time widget configurations.",
        EntityNounTitle = "Time Widget")]
    public virtual TimeWidgetGameConfiguration[]? TimeWidgets { get; set; } = null;

    [ConfigurationCollection(
        "Widgets",
        Title = "Nullable Strings Text Area Widgets",
        Summary = "Collection of text widget configurations used for nullable string text areas.",
        EntityNounTitle = "Text Widget")]
    public virtual TextWidgetGameConfiguration[]? NullableStringsTextAreaWidgets { get; set; } = null;

    [ConfigurationCollection(
        "RaceGenders",
        Title = "Race Genders",
        Summary = "Collection of race-gender configurations.",
        EntityNounTitle = "Race Gender")]
    public virtual RaceGenderGameConfiguration[]? RaceGenders { get; set; } = null;

    [ConfigurationCollection(
        "Genders",
        Title = "Genders",
        Summary = "Collection of gender configurations.",
        EntityNounTitle = "Gender")]
    public virtual GenderGameConfiguration[]? Genders { get; set; } = null;

    [ConfigurationCollection(
        "PhysicalAttributeSets",
        Title = "Physical Attribute Sets",
        Summary = "Collection of physical attribute set configurations.",
        EntityNounTitle = "Physical Attribute Set")]
    public virtual PhysicalAttributeSetGameConfiguration[]? PhysicalAttributeSets { get; set; } = null;

    [ConfigurationCollection(
        "Realms",
        Title = "Realms",
        Summary = "Collection of realm configurations.",
        EntityNounTitle = "Realm")]
    public virtual RealmGameConfiguration[]? Realms { get; set; } = null;

    [ConfigurationCollection(
        "RealmCharacterClasses",
        Title = "Realm Character Classes",
        Summary = "Collection of realm character class configurations.",
        EntityNounTitle = "Realm Character Class")]
    public virtual RealmCharacterClassGameConfiguration[]? RealmCharacterClasses { get; set; } = null;

    [ConfigurationCollection(
        "Views",
        Title = "Views",
        Summary = "Collection of view configurations.",
        EntityNounTitle = "View")]
    public virtual ViewGameConfiguration[]? Views { get; set; } = null;

    [ConfigurationCollection(
        "SummonScripts",
        Title = "Summon Scripts",
        Summary = "Collection of summon script configurations.",
        EntityNounTitle = "Summon Script")]
    public virtual SummonScriptGameConfiguration[]? SummonScripts { get; set; } = null;

    [ConfigurationCollection(
        "MappedSpellScripts",
        Title = "Mapped Spell Scripts",
        Summary = "Collection of mapped-spell script configurations.",
        EntityNounTitle = "Mapped Spell Script")]
    public virtual MappedSpellScriptGameConfiguration[]? MappedSpellScripts { get; set; } = null;

    [ConfigurationCollection(
        "SummonWeightedRandoms",
        Title = "Summon Weighted Randoms",
        Summary = "Collection of summon-weighted-random configurations.",
        EntityNounTitle = "Summon Weighted Random")]
    public virtual SummonWeightedRandomGameConfiguration[]? SummonWeightedRandoms { get; set; } = null;

    [ConfigurationCollection(
        "ItemFactoryWeightedRandoms",
        Title = "Item Factory Weighted Randoms",
        Summary = "Collection of item-factory weighted-random configurations.",
        EntityNounTitle = "Item Factory Weighted Random")]
    public virtual ItemFactoryWeightedRandomGameConfiguration[]? ItemFactoryWeightedRandoms { get; set; } = null;

    [ConfigurationCollection(
        "TimerScripts",
        Title = "Timer Scripts",
        Summary = "Collection of timer script configurations.",
        EntityNounTitle = "Timer Script")]
    public virtual TimerScriptGameConfiguration[]? TimerScripts { get; set; } = null;

    [ConfigurationCollection(
        "RenderMessageScripts",
        Title = "Render Message Scripts",
        Summary = "Collection of render-message script configurations.",
        EntityNounTitle = "Render Message Script")]
    public virtual RenderMessageScriptGameConfiguration[]? RenderMessageScripts { get; set; } = null;

    [ConfigurationCollection(
       "MartialArtsAttacks",
        Title = "Martial Arts Attacks",
        Summary = "Collection of martial-arts attack configurations.",
        EntityNounTitle = "Martial Arts Attack")]
    public virtual MartialArtsAttackGameConfiguration[]? MartialArtsAttacks { get; set; } = null;

    [ConfigurationCollection(
        "AbilityScoreScripts",
        Title = "Ability Score Scripts",
        Summary = "Collection of ability-score script configurations.",
        EntityNounTitle = "Ability Score Script")]
    public virtual AbilityScoreScriptGameConfiguration[]? AbilityScoreScripts { get; set; } = null;

    [ConfigurationCollection(
        "ChestTrapCombinations",
        Title = "Chest Trap Combinations",
        Summary = "Collection of chest-trap combination configurations.",
        EntityNounTitle = "Chest Trap Combination")]
    public virtual ChestTrapCombinationGameConfiguration[]? ChestTrapCombinations { get; set; } = null;

    [ConfigurationCollection(
        "Patrons",
        Title = "Patrons",
        Summary = "Collection of patron configurations.",
        EntityNounTitle = "Patron",
        EntityNamePropertyName = "LongName")]
    public virtual PatronGameConfiguration[]? Patrons { get; set; } = null;

    [ConfigurationCollection(
        "RacialPowerTests",
        Title = "Racial Power Tests",
        Summary = "Collection of racial-power test configurations.",
        EntityNounTitle = "Racial Power Test")]
    public virtual RacialPowerTestGameConfiguration[]? RacialPowerTests { get; set; } = null;

    [ConfigurationCollection(
        "RaceAbilities",
        Title = "Race Abilities",
        Summary = "Collection of race-ability configurations.",
        EntityNounTitle = "Race Ability")]
    public virtual RaceAbilityGameConfiguration[]? RaceAbilities { get; set; } = null;

    [ConfigurationCollection(
        "RacialPowers",
        Title = "Racial Powers",
        Summary = "Collection of racial-power configurations.",
        EntityNounTitle = "Racial Power")]
    public virtual RacePowerGameConfiguration[]? RacialPowers { get; set; } = null;

    [ConfigurationCollection(
        "ConditionalScripts",
        Title = "Conditional Scripts",
        Summary = "Collection of conditional script configurations.",
        EntityNounTitle = "Conditional Script")]
    public virtual ConditionalScriptGameConfiguration[]? ConditionalScripts { get; set; } = null;

    [ConfigurationCollection(
        "CharacterClassAbilities",
        Title = "Character Class Abilities",
        Summary = "Collection of character-class ability configurations.",
        EntityNounTitle = "Character Class Ability")]
    public virtual CharacterClassAbilityGameConfiguration[]? CharacterClassAbilities { get; set; } = null;

    [ConfigurationCollection(
        "CharacterClassAndRaceInnateTotals",
        Title = "Character Class And Race Innate Totals",
        Summary = "Collection of innate-total configurations for character classes and races.",
        EntityNounTitle = "Character Class And Race Innate Total")]
    public virtual InnateTotalsGameConfiguration[]? CharacterClassAndRaceInnateTotals { get; set; } = null;

    [ConfigurationCollection(
        "Activations",
        Title = "Activations",
        Summary = "Collection of activation configurations.",
        EntityNounTitle = "Activation")]
    public virtual ActivationGameConfiguration[]? Activations { get; set; } = null;

    [ConfigurationCollection(
        "ItemFilters",
        Title = "Item Filters",
        Summary = "Collection of item filter configurations.",
        EntityNounTitle = "Item Filter")]
    public virtual ItemFilterGameConfiguration[]? ItemFilters { get; set; } = null;

    [ConfigurationCollection(
        "ProductOfSumsBoolFunctions",
        Title = "Product Of Sums Bool Functions",
        Summary = "Collection of conditional (product-of-sums) boolean function configurations.",
        EntityNounTitle = "Conditional")]
    public virtual ConditionalGameConfiguration[]? ProductOfSumsBoolFunctions { get; set; } = null;

    [ConfigurationCollection(
        "RechargeItemScripts",
        Title = "Recharge Item Scripts",
        Summary = "Collection of recharge-item script configurations.",
        EntityNounTitle = "Recharge Item Script")]
    public virtual RechargeItemScriptGameConfiguration[]? RechargeItemScripts { get; set; } = null;

    [ConfigurationCollection(
        "Talents",
        Title = "Talents",
        Summary = "Collection of talent configurations.",
        EntityNounTitle = "Talent")]
    public virtual TalentGameConfiguration[]? Talents { get; set; } = null;

    [ConfigurationCollection(
        "TeleportSelfScripts",
        Title = "Teleport Self Scripts",
        Summary = "Collection of teleport-self script configurations.",
        EntityNounTitle = "Teleport Self Script")]
    public virtual TeleportSelfScriptGameConfiguration[]? TeleportSelfScripts { get; set; } = null;

    [ConfigurationCollection(
        "MappedItemEnhancements",
        Title = "Mapped Item Enhancements",
        Summary = "Collection of mapped-item enhancement configurations.",
        EntityNounTitle = "Mapped Item Enhancement")]
    public virtual MappedItemEnhancementGameConfiguration[]? MappedItemEnhancements { get; set; } = null;

    [ConfigurationCollection(
        "ChestTraps",
        Title = "Chest Traps",
        Summary = "Collection of chest-trap configurations.",
        EntityNounTitle = "Chest Trap")]
    public virtual ChestTrapGameConfiguration[]? ChestTraps { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Game Tick Event Binding Keys",
        Description = "Binding keys for events that occur on each game tick.")]
    public virtual string[]? GameTickEventBindingKeys { get; set; } = null;

    [ConfigurationProperty("int",
        Title = "Max Monster Count",
        Description = "Maximum number of monsters allowed.")]
    public virtual int MaxMonsterCount { get; set; } = 512;

    [ConfigurationProperty("int",
        Title = "Compact Monster Cut In",
        Description = "Number of monsters at which compacting begins.")]
    public virtual int CompactMonsterCutIn { get; set; } = 32;

    [ConfigurationProperty("int",
        Title = "Compact Monster Cut Out Target",
        Description = "Target number of monsters to reduce to when compacting.")]
    public virtual int CompactMonsterCutOutTarget { get; set; } = 64;

    [ConfigurationProperty("int?",
        Title = "Max Message Log Length",
        Description = "Number of log items that the message history may store. Null indicates no limit.")]
    public virtual int? MaxMessageLogLength { get; set; } = 2048;

    [ConfigurationProperty("int",
        Title = "Follow Distance",
        Description = "Distance at which followers remain from the player.")]
    public virtual int FollowDistance { get; set; } = 4;

    [ConfigurationProperty("int",
        Title = "Decay Rate",
        Description = "Rate at which certain game elements decay.")]
    public virtual int DecayRate { get; set; } = 10;

    [ConfigurationProperty("int",
        Title = "Patron Resting Favour",
        Description = "Favour amount awarded when resting with a patron.")]
    public virtual int PatronRestingFavour { get; set; } = 30;

    [ConfigurationProperty("string?",
        Title = "Dungeon View Binding Key",
        Description = "Binding key for the dungeon view.")]
    public virtual string? DungeonViewBindingKey { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Startup Town Name",
        Description = "Name of the town where the player will start, or null to choose a random startup town from available towns.")]
    public virtual string? StartupTownName { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Gold Factories Binding Keys",
        Description = "Binding keys for gold factories.")]
    public virtual string[]? GoldFactoriesBindingKeys { get; set; } = null;

    [ConfigurationProperty("string",
        Title = "Gold Item Is Great Probability Expression",
        Description = "Probability expression that determines whether a gold-containing item is considered 'great'.")]
    public virtual string? GoldItemIsGreatProbabilityExpression { get; set; } = "0.05"; // 1 in 20 or 5%

    [ConfigurationProperty("string[]?",
        Title = "Shopkeeper Accepted Comments",
        Description = "Accepted shopkeeper comment strings.")]
    public virtual string[]? ShopkeeperAcceptedComments { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Illegible Flavor Syllables",
        Description = "Syllables used to represent illegible flavors.")]
    public virtual string[]? IllegibleFlavorSyllables { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Find Quests",
        Description = "Find-quest strings.")]
    public virtual string[]? FindQuests { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Elvish Texts",
        Description = "Elvish text strings.")]
    public virtual string[]? ElvishTexts { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Funny Descriptions",
        Description = "Funny description strings.")]
    public virtual string[]? FunnyDescriptions { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Funny Comments",
        Description = "Funny comment strings.")]
    public virtual string[]? FunnyComments { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Horrific Descriptions",
        Description = "Horrific description strings.")]
    public virtual string[]? HorrificDescriptions { get; set; } = null;

    [ConfigurationProperty("int[]",
        Title = "Required Experience Per Level",
        Description = "Array of required experience values for each level.")]
    public virtual int[] RequiredExperiencePerLevel { get; set; } = new int[] // TODO: Need defaults removed.
    {
        10, 25, 45, 70, 100, 140, 200, 280, 380, 500, 650, 850, 1100, 1400, 1800, 2300, 2900, 3600, 4400, 5400,
        6800, 8400, 10200, 12500, 17500, 25000, 35000, 50000, 75000, 100000, 150000, 200000, 275000, 350000, 450000,
        550000, 700000, 850000, 1000000, 1250000, 1500000, 1800000, 2100000, 2400000, 2700000, 3000000, 3500000,
        4000000, 4500000, 5000000
    };

    [ConfigurationProperty("int[]",
        Title = "Extract Energy",
        Description = "Energy extracted per speed class.")]
    public virtual int[] ExtractEnergy { get; set; } = new int[] // TODO: Need defaults removed.
    {
	/* Slow 0-9 */       1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow 10-19 */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow 20-29 */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow 30-49 */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow 40-59 */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow 50-69 */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* S-50 60-79 */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* S-40 70-89 */     2,  2,  2,  2,  2,  2,  2,  2,  2,  2,
	/* S-30 80-89 */     2,  2,  2,  2,  2,  2,  2,  3,  3,  3,
	/* S-20 90-99 */     3,  3,  3,  3,  3,  4,  4,  4,  4,  4,
	/* S-10 100-109 */   5,  5,  5,  5,  6,  6,  7,  7,  8,  9,
	/* Norm 110-129 */  10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
	/* F+10 120-139 */  20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
	/* F+20 130-139 */  30, 31, 32, 33, 34, 35, 36, 36, 37, 37,
	/* F+30 140-149 */  38, 38, 39, 39, 40, 40, 40, 41, 41, 41,
	/* F+40 150-159 */  42, 42, 42, 43, 43, 43, 44, 44, 44, 44,
	/* F+50 160-169 */  45, 45, 45, 45, 45, 46, 46, 46, 46, 46,
	/* F+60 170-179 */  47, 47, 47, 47, 47, 48, 48, 48, 48, 48,
	/* F+70 180-189 */  49, 49, 49, 49, 49, 49, 49, 49, 49, 49,
	/* Fast 190-199 */  49, 49, 49, 49, 49, 49, 49, 49, 49, 49
    };

    [ConfigurationProperty("int[][]",
        Title = "Blows Table",
        Description = "Table describing number of blows by attack/speed group.")]
    public virtual int[][] BlowsTable { get; set; } = new int[][]
    {
        new[] {1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3},
        new[] {1, 1, 1, 1, 2, 2, 3, 3, 3, 4, 4, 4},
        new[] {1, 1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5},
        new[] {1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 5},
        new[] {1, 2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5},
        new[] {2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5, 6},
        new[] {2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5, 6},
        new[] {2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 5, 6},
        new[] {3, 3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6},
        new[] {3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6},
        new[] {3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6},
        new[] {3, 3, 4, 4, 4, 4, 5, 5, 6, 6, 6, 6}
    };
}
