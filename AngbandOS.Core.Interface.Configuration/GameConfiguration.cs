using AngbandOS.Core.Interface.Configuration.Annotations;
using System.Reflection;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Game Configuration",
    EntityNoun = "GameConfiguration")]
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
        gameConfiguration.ActivationAttributes = LoadFromAssembly<ActivationNullableReferenceAttributeGameConfiguration>(assembly);
        gameConfiguration.ArtifactBiasAttributes = LoadFromAssembly<ArtifactBiasNullableReferenceAttributeGameConfiguration>(assembly);
        gameConfiguration.StringAttributes = LoadFromAssembly<StringNullableReferenceAttributeGameConfiguration>(assembly);
    }

    [ConfigurationMetadataAttribute(
        Title = "Game Tick Event Binding Keys",
        Summary = "Binding keys for events that occur on each game tick.",
        DataType = "string[]?")]
    public virtual string[]? GameTickEventBindingKeys { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Max Monster Count",
        Summary = "Maximum number of monsters allowed.",
        DataType = "int")]
    public virtual int MaxMonsterCount { get; set; } = 512;

    [ConfigurationMetadataAttribute(
        Title = "Compact Monster Cut In",
        Summary = "Number of monsters at which compacting begins.",
        DataType = "int")]
    public virtual int CompactMonsterCutIn { get; set; } = 32;

    [ConfigurationMetadataAttribute(
        Title = "Compact Monster Cut Out Target",
        Summary = "Target number of monsters to reduce to when compacting.",
        DataType = "int")]
    public virtual int CompactMonsterCutOutTarget { get; set; } = 64;

    [ConfigurationMetadataAttribute(
        Title = "Max Message Log Length",
        Summary = "Number of log items that the message history may store. Null indicates no limit.",
        DataType = "int?")]
    public virtual int? MaxMessageLogLength { get; set; } = 2048;

    [ConfigurationMetadataAttribute(
        Title = "Follow Distance",
        Summary = "Distance at which followers remain from the player.",
        DataType = "int")]
    public virtual int FollowDistance { get; set; } = 4;

    [ConfigurationMetadataAttribute(
        Title = "Decay Rate",
        Summary = "Rate at which certain game elements decay.",
        DataType = "int")]
    public virtual int DecayRate { get; set; } = 10;

    [ConfigurationMetadataAttribute(
        Title = "Patron Resting Favour",
        Summary = "Favour amount awarded when resting with a patron.",
        DataType = "int")]
    public virtual int PatronRestingFavour { get; set; } = 30;

    [ConfigurationMetadataAttribute(
        Title = "Dungeon View Binding Key",
        Summary = "Binding key for the dungeon view.",
        DataType = "string?")]
    public virtual string? DungeonViewBindingKey { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Startup Town Name",
        Summary = "Name of the town where the player will start, or null to choose a random startup town from available towns.",
        DataType = "string?")]
    public virtual string? StartupTownName { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Gold Factories Binding Keys",
        Summary = "Binding keys for gold factories.",
        DataType = "string[]?")]
    public virtual string[]? GoldFactoriesBindingKeys { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Gold Item Is Great Probability Expression",
        Summary = "Probability expression that determines whether a gold-containing item is considered 'great'.",
        DataType = "string")]
    public virtual string? GoldItemIsGreatProbabilityExpression { get; set; } = "0.05"; // 1 in 20 or 5%

    [ConfigurationMetadataAttribute(
        Title = "Towns",
        Summary = "Null to load towns from the assembly; otherwise a collection of towns to load into the SingletonRepository.",
        DataType = "TownGameConfiguration[]?")]
    public virtual TownGameConfiguration[]? Towns { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Shopkeepers",
        Summary = "Collection of shopkeeper configurations.",
        DataType = "ShopkeeperGameConfiguration[]?")]
    public virtual ShopkeeperGameConfiguration[]? Shopkeepers { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Game Commands",
        Summary = "Collection of game command configurations.",
        DataType = "GameCommandGameConfiguration[]?")]
    public virtual GameCommandGameConfiguration[]? GameCommands { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Store Commands",
        Summary = "Collection of store command configurations.",
        DataType = "StoreCommandGameConfiguration[]?")]
    public virtual StoreCommandGameConfiguration[]? StoreCommands { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Help Groups",
        Summary = "Collection of help group configurations.",
        DataType = "HelpGroupGameConfiguration[]?")]
    public virtual HelpGroupGameConfiguration[]? HelpGroups { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Monster Races",
        Summary = "Collection of monster race configurations.",
        DataType = "MonsterRaceGameConfiguration[]?")]
    public virtual MonsterRaceGameConfiguration[]? MonsterRaces { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Outfit Manifests",
        Summary = "Collection of outfit manifest configurations.",
        DataType = "OutfitManifestGameConfiguration[]?")]
    public virtual OutfitManifestGameConfiguration[]? OutfitManifests { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Symbols",
        Summary = "Collection of symbol configurations.",
        DataType = "SymbolGameConfiguration[]?")]
    public virtual SymbolGameConfiguration[]? Symbols { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Vaults",
        Summary = "Collection of vault configurations.",
        DataType = "VaultGameConfiguration[]?")]
    public virtual VaultGameConfiguration[]? Vaults { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Dungeon Guardians",
        Summary = "Collection of dungeon guardian configurations.",
        DataType = "DungeonGuardianGameConfiguration[]?")]
    public virtual DungeonGuardianGameConfiguration[]? DungeonGuardians { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Damage Learned Knowledges",
        Summary = "Collection of damage learned-knowledge configurations.",
        DataType = "DamageLearnedKnowledgeGameConfiguration[]?")]
    public virtual DamageLearnedKnowledgeGameConfiguration[]? DamageLearnedKnowledges { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Duration Learned Knowledges",
        Summary = "Collection of duration learned-knowledge configurations.",
        DataType = "DurationLearnedKnowledgeGameConfiguration[]?")]
    public virtual DurationLearnedKnowledgeGameConfiguration[]? DurationLearnedKnowledges { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Range Learned Knowledges",
        Summary = "Collection of range learned-knowledge configurations.",
        DataType = "RangeLearnedKnowledgeGameConfiguration[]?")]
    public virtual RangeLearnedKnowledgeGameConfiguration[]? RangeLearnedKnowledges { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Experience Learned Knowledges",
        Summary = "Collection of experience learned-knowledge configurations.",
        DataType = "ExperienceLearnedKnowledgeGameConfiguration[]?")]
    public virtual ExperienceLearnedKnowledgeGameConfiguration[]? ExperienceLearnedKnowledges { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Dungeons",
        Summary = "Collection of dungeon configurations.",
        DataType = "DungeonGameConfiguration[]?")]
    public virtual DungeonGameConfiguration[]? Dungeons { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Store Factories",
        Summary = "Factories used to create stores within towns.",
        DataType = "StoreFactoryGameConfiguration[]?")]
    public virtual StoreFactoryGameConfiguration[]? StoreFactories { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Projectile Graphics",
        Summary = "Collection of projectile graphic configurations.",
        DataType = "ProjectileGraphicGameConfiguration[]?")]
    public virtual ProjectileGraphicGameConfiguration[]? ProjectileGraphics { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Item Flavors",
        Summary = "Collection of item flavor configurations.",
        DataType = "ItemFlavorGameConfiguration[]?")]
    public virtual ItemFlavorGameConfiguration[]? ItemFlavors { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Class Spells",
        Summary = "Collection of character class spell configurations.",
        DataType = "CharacterClassSpellGameConfiguration[]?")]
    public virtual CharacterClassSpellGameConfiguration[]? ClassSpells { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Wizard Commands",
        Summary = "Collection of wizard command configurations.",
        DataType = "WizardCommandGameConfiguration[]?")]
    public virtual WizardCommandGameConfiguration[]? WizardCommands { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Tiles",
        Summary = "Collection of tile configurations.",
        DataType = "TileGameConfiguration[]?")]
    public virtual TileGameConfiguration[]? Tiles { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Animations",
        Summary = "Collection of animation configurations.",
        DataType = "AnimationGameConfiguration[]?")]
    public virtual AnimationGameConfiguration[]? Animations { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Spells",
        Summary = "Collection of spell configurations.",
        DataType = "SpellGameConfiguration[]?")]
    public virtual SpellGameConfiguration[]? Spells { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Plurals",
        Summary = "Collection of pluralization configurations.",
        DataType = "PluralGameConfiguration[]?")]
    public virtual PluralGameConfiguration[]? Plurals { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Attacks",
        Summary = "Collection of attack configurations.",
        DataType = "AttackGameConfiguration[]?")]
    public virtual AttackGameConfiguration[]? Attacks { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Attribute Filters",
        Summary = "Collection of attribute filter configurations.",
        DataType = "AttributeFilterGameConfiguration[]?")]
    public virtual AttributeFilterGameConfiguration[]? AttributeFilters { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Or Attributes",
        Summary = "Collection of bitwise-or attribute configurations.",
        DataType = "BitwiseOrAttributeGameConfiguration[]?")]
    public virtual BitwiseOrAttributeGameConfiguration[]? OrAttributes { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Sum Attributes",
        Summary = "Collection of summation attribute configurations.",
        DataType = "SummationAttributeGameConfiguration[]?")]
    public virtual SummationAttributeGameConfiguration[]? SumAttributes { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Scripts Attributes",
        Summary = "Collection of scripts attribute configurations.",
        DataType = "ScriptsAttributeGameConfiguration[]?")]
    public virtual ScriptsAttributeGameConfiguration[]? ScriptsAttributes { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Color Enum Attributes",
        Summary = "Collection of color-enum attribute configurations.",
        DataType = "ColorEnumAttributeGameConfiguration[]?")]
    public virtual ColorEnumAttributeGameConfiguration[]? ColorEnumAttributes { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Activation Attributes",
        Summary = "Collection of activation attribute configurations.",
        DataType = "ActivationNullableReferenceAttributeGameConfiguration[]?")]
    public virtual ActivationNullableReferenceAttributeGameConfiguration[]? ActivationAttributes { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Artifact Bias Attributes",
        Summary = "Collection of artifact-bias attribute configurations.",
        DataType = "ArtifactBiasNullableReferenceAttributeGameConfiguration[]?")]
    public virtual ArtifactBiasNullableReferenceAttributeGameConfiguration[]? ArtifactBiasAttributes { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "String Attributes",
        Summary = "Collection of string attribute configurations.",
        DataType = "StringNullableReferenceAttributeGameConfiguration[]?")]
    public virtual StringNullableReferenceAttributeGameConfiguration[]? StringAttributes { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Gods",
        Summary = "Collection of god configurations.",
        DataType = "GodGameConfiguration[]?")]
    public virtual GodGameConfiguration[]? Gods { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Syllable Sets",
        Summary = "Collection of syllable set configurations.",
        DataType = "SyllableSetGameConfiguration[]?")]
    public virtual SyllableSetGameConfiguration[]? SyllableSets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Projectiles",
        Summary = "Collection of projectile configurations.",
        DataType = "ProjectileGameConfiguration[]?")]
    public virtual ProjectileGameConfiguration[]? Projectiles { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Projectile Scripts",
        Summary = "Collection of projectile script configurations.",
        DataType = "ProjectileScriptGameConfiguration[]?")]
    public virtual ProjectileScriptGameConfiguration[]? ProjectileScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Projectile Monster Spells",
        Summary = "Collection of projectile monster spell configurations.",
        DataType = "ProjectileMonsterSpellGameConfiguration[]?")]
    public virtual ProjectileMonsterSpellGameConfiguration[]? ProjectileMonsterSpells { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Cause Wounds Monster Spells",
        Summary = "Collection of cause-wounds monster spell configurations.",
        DataType = "CauseWoundsMonsterSpellGameConfiguration[]?")]
    public virtual CauseWoundsMonsterSpellGameConfiguration[]? CauseWoundsMonsterSpells { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Script Monster Spells",
        Summary = "Collection of script monster spell configurations.",
        DataType = "ScriptMonsterSpellGameConfiguration[]?")]
    public virtual ScriptMonsterSpellGameConfiguration[]? ScriptMonsterSpells { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Summon Monster Spells",
        Summary = "Collection of summon monster spell configurations.",
        DataType = "SummonMonsterSpellGameConfiguration[]?")]
    public virtual SummonMonsterSpellGameConfiguration[]? SummonMonsterSpells { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Shopkeeper Accepted Comments",
        Summary = "Accepted shopkeeper comment strings.",
        DataType = "string[]?")]
    public virtual string[]? ShopkeeperAcceptedComments { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Illegible Flavor Syllables",
        Summary = "Syllables used to represent illegible flavors.",
        DataType = "string[]?")]
    public virtual string[]? IllegibleFlavorSyllables { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Find Quests",
        Summary = "Find-quest strings.",
        DataType = "string[]?")]
    public virtual string[]? FindQuests { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Elvish Texts",
        Summary = "Elvish text strings.",
        DataType = "string[]?")]
    public virtual string[]? ElvishTexts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Funny Descriptions",
        Summary = "Funny description strings.",
        DataType = "string[]?")]
    public virtual string[]? FunnyDescriptions { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Funny Comments",
        Summary = "Funny comment strings.",
        DataType = "string[]?")]
    public virtual string[]? FunnyComments { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Horrific Descriptions",
        Summary = "Horrific description strings.",
        DataType = "string[]?")]
    public virtual string[]? HorrificDescriptions { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Artifact Bias Weighted Randoms",
        Summary = "Collection of artifact-bias weighted-random configurations.",
        DataType = "ArtifactBiasWeightedRandomGameConfiguration[]?")]
    public virtual ArtifactBiasWeightedRandomGameConfiguration[]? ArtifactBiasWeightedRandoms { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Item Classes",
        Summary = "Collection of item class configurations.",
        DataType = "ItemClassGameConfiguration[]?")]
    public virtual ItemClassGameConfiguration[]? ItemClasses { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Item Enhancements",
        Summary = "Collection of item enhancement configurations.",
        DataType = "ItemEnhancementGameConfiguration[]?")]
    public virtual ItemEnhancementGameConfiguration[]? ItemEnhancements { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Item Enhancement Weighted Randoms",
        Summary = "Collection of item-enhancement weighted-random configurations.",
        DataType = "ItemEnhancementWeightedRandomGameConfiguration[]?")]
    public virtual ItemEnhancementWeightedRandomGameConfiguration[]? ItemEnhancementWeightedRandoms { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Item Identifications",
        Summary = "Collection of item identification configurations.",
        DataType = "ItemIdentificationGameConfiguration[]?")]
    public virtual ItemIdentificationGameConfiguration[]? ItemIdentifications { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Item Factories",
        Summary = "Collection of item factory configurations.",
        DataType = "ItemFactoryGameConfiguration[]?")]
    public virtual ItemFactoryGameConfiguration[]? ItemFactories { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Projectile Weighted Random Scripts",
        Summary = "Collection of projectile-weighted-random script configurations.",
        DataType = "ProjectileScriptWeightedRandomGameConfiguration[]?")]
    public virtual ProjectileScriptWeightedRandomGameConfiguration[]? ProjectileWeightedRandomScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Conditional Widgets",
        Summary = "Collection of conditional widget configurations.",
        DataType = "ConditionalWidgetGameConfiguration[]?")]
    public virtual ConditionalWidgetGameConfiguration[]? ConditionalWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Date Widgets",
        Summary = "Collection of date widget configurations.",
        DataType = "DateWidgetGameConfiguration[]?")]
    public virtual DateWidgetGameConfiguration[]? DateWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Int Widgets",
        Summary = "Collection of int widget configurations.",
        DataType = "IntWidgetGameConfiguration[]?")]
    public virtual IntWidgetGameConfiguration[]? IntWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Map Widgets",
        Summary = "Collection of map widget configurations.",
        DataType = "MapWidgetGameConfiguration[]?")]
    public virtual MapWidgetGameConfiguration[]? MapWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Max Ranged Widgets",
        Summary = "Collection of max-ranged widget configurations.",
        DataType = "MaxRangedWidgetGameConfiguration[]?")]
    public virtual MaxRangedWidgetGameConfiguration[]? MaxRangedWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Ranged Widgets",
        Summary = "Collection of ranged widget configurations.",
        DataType = "RangedWidgetGameConfiguration[]?")]
    public virtual RangedWidgetGameConfiguration[]? RangedWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Ranged Weapon Bonuses",
        Summary = "Collection of ranged weapon bonus configurations.",
        DataType = "RangedWeaponBonusGameConfiguration[]?")]
    public virtual RangedWeaponBonusGameConfiguration[]? RangedWeaponBonuses { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "String Widgets",
        Summary = "Collection of string widget configurations.",
        DataType = "StringWidgetGameConfiguration[]?")]
    public virtual StringWidgetGameConfiguration[]? StringWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Game Message Widgets",
        Summary = "Collection of game-message widget configurations.",
        DataType = "GameMessageWidgetGameConfiguration[]?")]
    public virtual GameMessageWidgetGameConfiguration[]? GameMessageWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Label Widgets",
        Summary = "Collection of label widget configurations.",
        DataType = "LabelWidgetGameConfiguration[]?")]
    public virtual LabelWidgetGameConfiguration[]? LabelWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Time Widgets",
        Summary = "Collection of time widget configurations.",
        DataType = "TimeWidgetGameConfiguration[]?")]
    public virtual TimeWidgetGameConfiguration[]? TimeWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Nullable Strings Text Area Widgets",
        Summary = "Collection of text widget configurations used for nullable string text areas.",
        DataType = "TextWidgetGameConfiguration[]?")]
    public virtual TextWidgetGameConfiguration[]? NullableStringsTextAreaWidgets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Race Genders",
        Summary = "Collection of race-gender configurations.",
        DataType = "RaceGenderGameConfiguration[]?")]
    public virtual RaceGenderGameConfiguration[]? RaceGenders { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Genders",
        Summary = "Collection of gender configurations.",
        DataType = "GenderGameConfiguration[]?")]
    public virtual GenderGameConfiguration[]? Genders { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Physical Attribute Sets",
        Summary = "Collection of physical attribute set configurations.",
        DataType = "PhysicalAttributeSetGameConfiguration[]?")]
    public virtual PhysicalAttributeSetGameConfiguration[]? PhysicalAttributeSets { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Realms",
        Summary = "Collection of realm configurations.",
        DataType = "RealmGameConfiguration[]?")]
    public virtual RealmGameConfiguration[]? Realms { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Realm Character Classes",
        Summary = "Collection of realm character class configurations.",
        DataType = "RealmCharacterClassGameConfiguration[]?")]
    public virtual RealmCharacterClassGameConfiguration[]? RealmCharacterClasses { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Views",
        Summary = "Collection of view configurations.",
        DataType = "ViewGameConfiguration[]?")]
    public virtual ViewGameConfiguration[]? Views { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Summon Scripts",
        Summary = "Collection of summon script configurations.",
        DataType = "SummonScriptGameConfiguration[]?")]
    public virtual SummonScriptGameConfiguration[]? SummonScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Mapped Spell Scripts",
        Summary = "Collection of mapped-spell script configurations.",
        DataType = "MappedSpellScriptGameConfiguration[]?")]
    public virtual MappedSpellScriptGameConfiguration[]? MappedSpellScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Summon Weighted Randoms",
        Summary = "Collection of summon-weighted-random configurations.",
        DataType = "SummonWeightedRandomGameConfiguration[]?")]
    public virtual SummonWeightedRandomGameConfiguration[]? SummonWeightedRandoms { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Item Factory Weighted Randoms",
        Summary = "Collection of item-factory weighted-random configurations.",
        DataType = "ItemFactoryWeightedRandomGameConfiguration[]?")]
    public virtual ItemFactoryWeightedRandomGameConfiguration[]? ItemFactoryWeightedRandoms { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Timer Scripts",
        Summary = "Collection of timer script configurations.",
        DataType = "TimerScriptGameConfiguration[]?")]
    public virtual TimerScriptGameConfiguration[]? TimerScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Render Message Scripts",
        Summary = "Collection of render-message script configurations.",
        DataType = "RenderMessageScriptGameConfiguration[]?")]
    public virtual RenderMessageScriptGameConfiguration[]? RenderMessageScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Martial Arts Attacks",
        Summary = "Collection of martial-arts attack configurations.",
        DataType = "MartialArtsAttackGameConfiguration[]?")]
    public virtual MartialArtsAttackGameConfiguration[]? MartialArtsAttacks { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Ability Score Scripts",
        Summary = "Collection of ability-score script configurations.",
        DataType = "AbilityScoreScriptGameConfiguration[]?")]
    public virtual AbilityScoreScriptGameConfiguration[]? AbilityScoreScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Chest Trap Combinations",
        Summary = "Collection of chest-trap combination configurations.",
        DataType = "ChestTrapCombinationGameConfiguration[]?")]
    public virtual ChestTrapCombinationGameConfiguration[]? ChestTrapCombinations { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Patrons",
        Summary = "Collection of patron configurations.",
        DataType = "PatronGameConfiguration[]?")]
    public virtual PatronGameConfiguration[]? Patrons { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Racial Power Tests",
        Summary = "Collection of racial-power test configurations.",
        DataType = "RacialPowerTestGameConfiguration[]?")]
    public virtual RacialPowerTestGameConfiguration[]? RacialPowerTests { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Race Abilities",
        Summary = "Collection of race-ability configurations.",
        DataType = "RaceAbilityGameConfiguration[]?")]
    public virtual RaceAbilityGameConfiguration[]? RaceAbilities { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Racial Powers",
        Summary = "Collection of racial-power configurations.",
        DataType = "RacePowerGameConfiguration[]?")]
    public virtual RacePowerGameConfiguration[]? RacialPowers { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Conditional Scripts",
        Summary = "Collection of conditional script configurations.",
        DataType = "ConditionalScriptGameConfiguration[]?")]
    public virtual ConditionalScriptGameConfiguration[]? ConditionalScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Character Class Abilities",
        Summary = "Collection of character-class ability configurations.",
        DataType = "CharacterClassAbilityGameConfiguration[]?")]
    public virtual CharacterClassAbilityGameConfiguration[]? CharacterClassAbilities { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Character Class And Race Innate Totals",
        Summary = "Collection of innate-total configurations for character classes and races.",
        DataType = "InnateTotalsGameConfiguration[]?")]
    public virtual InnateTotalsGameConfiguration[]? CharacterClassAndRaceInnateTotals { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Activations",
        Summary = "Collection of activation configurations.",
        DataType = "ActivationGameConfiguration[]?")]
    public virtual ActivationGameConfiguration[]? Activations { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Item Filters",
        Summary = "Collection of item filter configurations.",
        DataType = "ItemFilterGameConfiguration[]?")]
    public virtual ItemFilterGameConfiguration[]? ItemFilters { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Product Of Sums Bool Functions",
        Summary = "Collection of conditional (product-of-sums) boolean function configurations.",
        DataType = "ConditionalGameConfiguration[]?")]
    public virtual ConditionalGameConfiguration[]? ProductOfSumsBoolFunctions { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Recharge Item Scripts",
        Summary = "Collection of recharge-item script configurations.",
        DataType = "RechargeItemScriptGameConfiguration[]?")]
    public virtual RechargeItemScriptGameConfiguration[]? RechargeItemScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Talents",
        Summary = "Collection of talent configurations.",
        DataType = "TalentGameConfiguration[]?")]
    public virtual TalentGameConfiguration[]? Talents { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Teleport Self Scripts",
        Summary = "Collection of teleport-self script configurations.",
        DataType = "TeleportSelfScriptGameConfiguration[]?")]
    public virtual TeleportSelfScriptGameConfiguration[]? TeleportSelfScripts { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Mapped Item Enhancements",
        Summary = "Collection of mapped-item enhancement configurations.",
        DataType = "MappedItemEnhancementGameConfiguration[]?")]
    public virtual MappedItemEnhancementGameConfiguration[]? MappedItemEnhancements { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Chest Traps",
        Summary = "Collection of chest-trap configurations.",
        DataType = "ChestTrapGameConfiguration[]?")]
    public virtual ChestTrapGameConfiguration[]? ChestTraps { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Required Experience Per Level",
        Summary = "Array of required experience values for each level.",
        DataType = "int[]")]
    public virtual int[] RequiredExperiencePerLevel => new int[] // TODO: Need defaults removed.
    {
        10, 25, 45, 70, 100, 140, 200, 280, 380, 500, 650, 850, 1100, 1400, 1800, 2300, 2900, 3600, 4400, 5400,
        6800, 8400, 10200, 12500, 17500, 25000, 35000, 50000, 75000, 100000, 150000, 200000, 275000, 350000, 450000,
        550000, 700000, 850000, 1000000, 1250000, 1500000, 1800000, 2100000, 2400000, 2700000, 3000000, 3500000,
        4000000, 4500000, 5000000
    };

    [ConfigurationMetadataAttribute(
        Title = "Extract Energy",
        Summary = "Energy extracted per speed class.",
        DataType = "int[]")]
    public virtual int[] ExtractEnergy => new int[] // TODO: Need defaults removed.
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

    [ConfigurationMetadataAttribute(
        Title = "Blows Table",
        Summary = "Table describing number of blows by attack/speed group.",
        DataType = "int[][]")]
    public virtual int[][] BlowsTable => new int[][]
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
