using System.Reflection;

namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents an interface that describes the configuration data that the GameServer.Play method accepts.  This configuration data is used to completely
/// configure a new game.  Use the ConfigurationMetadata object to get metadata details that can be used to generate configuration data.
/// </summary>
[Serializable]
public class GameConfiguration
{
    public GameConfiguration()
    {
        // Dynamically load the game configuration with all singletons found in the containing assembly.
        Assembly assembly = GetType().Assembly;
        MergeAllSingletonsFromAssembly(this, assembly);
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
        gameConfiguration.MushroomReadableFlavors = LoadFromAssembly<ItemFlavorGameConfiguration>(assembly);
        gameConfiguration.PotionReadableFlavors = LoadFromAssembly<ItemFlavorGameConfiguration>(assembly);
        gameConfiguration.RingReadableFlavors = LoadFromAssembly<ItemFlavorGameConfiguration>(assembly);
        gameConfiguration.RodReadableFlavors = LoadFromAssembly<ItemFlavorGameConfiguration>(assembly);
        gameConfiguration.ScrollReadableFlavors = LoadFromAssembly<ItemFlavorGameConfiguration>(assembly);
        gameConfiguration.StaffReadableFlavors = LoadFromAssembly<ItemFlavorGameConfiguration>(assembly);
        gameConfiguration.WandReadableFlavors = LoadFromAssembly<ItemFlavorGameConfiguration>(assembly);
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
        gameConfiguration.BoolWidgets = LoadFromAssembly<BoolWidgetGameConfiguration>(assembly);
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
        gameConfiguration.RacialPowers = LoadFromAssembly<RacialPowerGameConfiguration>(assembly);
        gameConfiguration.RangedWeaponBonuses = LoadFromAssembly<RangedWeaponBonusGameConfiguration>(assembly);
        gameConfiguration.ConditionalScripts = LoadFromAssembly<ConditionalScriptGameConfiguration>(assembly);
        gameConfiguration.CharacterClassAbilities = LoadFromAssembly<CharacterClassAbilityGameConfiguration>(assembly);
        gameConfiguration.Activations = LoadFromAssembly<ActivationGameConfiguration>(assembly);
        gameConfiguration.ItemFilters = LoadFromAssembly<ItemFilterGameConfiguration>(assembly);
        gameConfiguration.BoolPosFunctions = LoadFromAssembly<BoolPosFunctionGameConfiguration>(assembly);
        gameConfiguration.RechargeItemScripts = LoadFromAssembly<RechargeItemScriptGameConfiguration>(assembly);
        gameConfiguration.TeleportSelfScripts = LoadFromAssembly<TeleportSelfScriptGameConfiguration>(assembly);
        gameConfiguration.MappedItemEnhancements = LoadFromAssembly<MappedItemEnhancementGameConfiguration>(assembly);
        gameConfiguration.ChestTraps = LoadFromAssembly<ChestTrapGameConfiguration>(assembly);
        gameConfiguration.OutfitManifests = LoadFromAssembly<OutfitManifestGameConfiguration>(assembly);

        gameConfiguration.OrAttributes = LoadFromAssembly<OrAttributeGameConfiguration>(assembly);
        gameConfiguration.SumAttributes = LoadFromAssembly<SumAttributeGameConfiguration>(assembly);
        gameConfiguration.ColorEnumAttributes = LoadFromAssembly<ColorEnumAttributeGameConfiguration>(assembly);
        gameConfiguration.BoolAttributes = LoadFromAssembly<BoolAttributeGameConfiguration>(assembly);
        gameConfiguration.ActivationAttributes = LoadFromAssembly<ActivationNullableReferenceAttributeGameConfiguration>(assembly);
        gameConfiguration.ArtifactBiasAttributes = LoadFromAssembly<ArtifactBiasNullableReferenceAttributeGameConfiguration>(assembly);
        gameConfiguration.StringAttributes = LoadFromAssembly<StringNullableReferenceAttributeGameConfiguration>(assembly);
    }

    /// <summary>
    /// Returns the number of log items that the message history is allowed to store.  A null value indicates that there is no limit.  The default value is 2048.
    /// </summary>    
    public virtual int? MaxMessageLogLength { get; set; } = 2048;

    public virtual int FollowDistance { get; set; } = 4;
    public virtual int DecayRate { get; set; } = 10;
    public virtual int PatronRestingFavour { get; set; } = 30;

    public virtual string? DungeonViewBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the name of the town where the player will start, ignoring whether or not that town is a startup town; or null, for a random town to be choosen 
    /// from the available startup towns.
    /// </summary>
    /// <foreign-collection-name>Towns</foreign-collection-name>
    public virtual string? StartupTownName { get; set; } = null;

    public virtual string[]? GoldFactoriesBindingKeys { get; set; } = null;

    public virtual string? GoldItemIsGreatProbabilityExpression { get; set; } = "0.05"; // 1 in 20 or 5%

    /// <summary>
    /// Returns null, if Towns should be loaded from the assembly.  Otherwise, returns an array of Towns to be loaded into the SingletonRepository.
    /// </summary>
    public virtual TownGameConfiguration[]? Towns { get; set; } = null;

    public virtual ShopkeeperGameConfiguration[]? Shopkeepers { get; set; } = null;

    public virtual GameCommandGameConfiguration[]? GameCommands { get; set; } = null;

    public virtual StoreCommandGameConfiguration[]? StoreCommands { get; set; } = null;

    public virtual HelpGroupGameConfiguration[]? HelpGroups { get; set; } = null;

    public virtual MonsterRaceGameConfiguration[]? MonsterRaces { get; set; } = null;
    public virtual OutfitManifestGameConfiguration[]? OutfitManifests { get; set; } = null;

    public virtual SymbolGameConfiguration[]? Symbols { get; set; } = null;

    public virtual VaultGameConfiguration[]? Vaults { get; set; } = null;

    public virtual DungeonGuardianGameConfiguration[]? DungeonGuardians { get; set; } = null;

    public virtual DungeonGameConfiguration[]? Dungeons { get; set; } = null;

    /// <summary>
    /// Towns have various plots where buildings and/or stores may be placed.  Stores factories are used to create specific stores.  Store factories can produce more than one store per town.  Use this collection to define factories that are used to create stores.
    /// </summary>
    public virtual StoreFactoryGameConfiguration[]? StoreFactories { get; set; } = null;

    public virtual ProjectileGraphicGameConfiguration[]? ProjectileGraphics { get; set; } = null;

    /// <entity-noun>AmuletReadableFlavor</entity-noun>
    public virtual ItemFlavorGameConfiguration[]? ItemFlavors { get; set; } = null;

    /// <entity-noun>MushroomReadableFlavor</entity-noun>
    public virtual ItemFlavorGameConfiguration[]? MushroomReadableFlavors { get; set; } = null;

    /// <entity-noun>PotionReadableFlavor</entity-noun>
    public virtual ItemFlavorGameConfiguration[]? PotionReadableFlavors { get; set; } = null;

    /// <entity-noun>RingReadableFlavor</entity-noun>
    public virtual ItemFlavorGameConfiguration[]? RingReadableFlavors { get; set; } = null;

    /// <entity-noun>RodReadableFlavor</entity-noun>
    public virtual ItemFlavorGameConfiguration[]? RodReadableFlavors { get; set; } = null;

    /// <entity-noun>ScrollReadableFlavor</entity-noun>
    public virtual ItemFlavorGameConfiguration[]? ScrollReadableFlavors { get; set; } = null;

    /// <entity-noun>StaffReadableFlavor</entity-noun>
    public virtual ItemFlavorGameConfiguration[]? StaffReadableFlavors { get; set; } = null;

    /// <entity-noun>WandReadableFlavor</entity-noun>
    public virtual ItemFlavorGameConfiguration[]? WandReadableFlavors { get; set; } = null;

    public virtual CharacterClassSpellGameConfiguration[]? ClassSpells { get; set; } = null;

    public virtual WizardCommandGameConfiguration[]? WizardCommands { get; set; } = null;

    public virtual TileGameConfiguration[]? Tiles { get; set; } = null;

    public virtual AnimationGameConfiguration[]? Animations { get; set; } = null;

    public virtual SpellGameConfiguration[]? Spells { get; set; } = null;

    public virtual PluralGameConfiguration[]? Plurals { get; set; } = null;

    public virtual AttackGameConfiguration[]? Attacks { get; set; } = null;

    public virtual OrAttributeGameConfiguration[]? OrAttributes { get; set; } = null;
    public virtual SumAttributeGameConfiguration[]? SumAttributes { get; set; } = null;
    public virtual ColorEnumAttributeGameConfiguration[]? ColorEnumAttributes { get; set; } = null;
    public virtual BoolAttributeGameConfiguration[]? BoolAttributes { get; set; } = null;
    public virtual ActivationNullableReferenceAttributeGameConfiguration[]? ActivationAttributes { get; set; } = null;
    public virtual ArtifactBiasNullableReferenceAttributeGameConfiguration[]? ArtifactBiasAttributes { get; set; } = null;
    public virtual StringNullableReferenceAttributeGameConfiguration[]? StringAttributes { get; set; } = null;

    public virtual GodGameConfiguration[]? Gods { get; set; } = null;
    public virtual SyllableSetGameConfiguration[]? SyllableSets { get; set; } = null;
    public virtual ProjectileGameConfiguration[]? Projectiles { get; set; } = null;
    public virtual ProjectileScriptGameConfiguration[]? ProjectileScripts { get; set; } = null;

    public virtual string[]? ShopkeeperAcceptedComments { get; set; } = null;
    public virtual string[]? IllegibleFlavorSyllables { get; set; } = null;
    public virtual string[]? FindQuests { get; set; } = null;
    public virtual string[]? ElvishTexts { get; set; } = null;
    public virtual string[]? FunnyDescriptions { get; set; } = null;
    public virtual string[]? FunnyComments { get; set; } = null;
    public virtual string[]? HorrificDescriptions { get; set; } = null;
    public virtual ArtifactBiasWeightedRandomGameConfiguration[]? ArtifactBiasWeightedRandoms { get; set; } = null;
    public virtual ItemClassGameConfiguration[]? ItemClasses { get; set; } = null;
    public virtual ItemEnhancementGameConfiguration[]? ItemEnhancements { get; set; } = null;
    public virtual ItemEnhancementWeightedRandomGameConfiguration[]? ItemEnhancementWeightedRandoms { get; set; } = null;
    public virtual ItemIdentificationGameConfiguration[]? ItemIdentifications { get; set; } = null;
    
    public virtual ItemFactoryGameConfiguration[]? ItemFactories { get; set; } = null;
    public virtual ProjectileScriptWeightedRandomGameConfiguration[]? ProjectileWeightedRandomScripts { get; set; } = null;

    public virtual BoolWidgetGameConfiguration[]? BoolWidgets { get; set; } = null;
    public virtual ConditionalWidgetGameConfiguration[]? ConditionalWidgets { get; set; } = null;
    public virtual DateWidgetGameConfiguration[]? DateWidgets { get; set; } = null;
    public virtual IntWidgetGameConfiguration[]? IntWidgets { get; set; } = null;
    public virtual MapWidgetGameConfiguration[]? MapWidgets { get; set; } = null;
    public virtual MaxRangedWidgetGameConfiguration[]? MaxRangedWidgets { get; set; } = null;
    public virtual RangedWidgetGameConfiguration[]? RangedWidgets { get; set; } = null;
    public virtual RangedWeaponBonusGameConfiguration[]? RangedWeaponBonuses { get; set; } = null;
    public virtual StringWidgetGameConfiguration[]? StringWidgets { get; set; } = null;
    public virtual GameMessageWidgetGameConfiguration[]? GameMessageWidgets { get; set; } = null;
    public virtual LabelWidgetGameConfiguration[]? LabelWidgets { get; set; } = null;
    public virtual TimeWidgetGameConfiguration[]? TimeWidgets { get; set; } = null;
    public virtual TextWidgetGameConfiguration[]? NullableStringsTextAreaWidgets { get; set; } = null;
    public virtual RaceGenderGameConfiguration[]? RaceGenders { get; set; } = null;
    public virtual GenderGameConfiguration[]? Genders { get; set; } = null;
    public virtual PhysicalAttributeSetGameConfiguration[]? PhysicalAttributeSets { get; set; } = null;
    public virtual RealmGameConfiguration[]? Realms { get; set; } = null;
    public virtual RealmCharacterClassGameConfiguration[]? RealmCharacterClasses { get; set; } = null;
    public virtual ViewGameConfiguration[]? Views { get; set; } = null;
    public virtual SummonScriptGameConfiguration[]? SummonScripts { get; set; } = null;
    public virtual MappedSpellScriptGameConfiguration[]? MappedSpellScripts { get; set; } = null;
    public virtual SummonWeightedRandomGameConfiguration[]? SummonWeightedRandoms { get; set; } = null;
    public virtual ItemFactoryWeightedRandomGameConfiguration[]? ItemFactoryWeightedRandoms { get; set; } = null;
    public virtual TimerScriptGameConfiguration[]? TimerScripts { get; set; } = null;
    public virtual RenderMessageScriptGameConfiguration[]? RenderMessageScripts { get; set; } = null;
    public virtual MartialArtsAttackGameConfiguration[]? MartialArtsAttacks { get; set; } = null;
    public virtual AbilityScoreScriptGameConfiguration[]? AbilityScoreScripts { get; set; } = null;
    public virtual ChestTrapCombinationGameConfiguration[]? ChestTrapCombinations { get; set; } = null;
    public virtual PatronGameConfiguration[]? Patrons { get; set; } = null;
    public virtual RacialPowerTestGameConfiguration[]? RacialPowerTests { get; set; } = null;
    public virtual RaceAbilityGameConfiguration[]? RaceAbilities { get; set; } = null;
    public virtual RacialPowerGameConfiguration[]? RacialPowers { get; set; } = null;
    public virtual ConditionalScriptGameConfiguration[]? ConditionalScripts { get; set; } = null;
    public virtual CharacterClassAbilityGameConfiguration[]? CharacterClassAbilities { get; set; } = null;
    public virtual ActivationGameConfiguration[]? Activations { get; set; } = null;
    public virtual ItemFilterGameConfiguration[]? ItemFilters { get; set; } = null;
    public virtual BoolPosFunctionGameConfiguration[]? BoolPosFunctions { get; set; } = null;
    public virtual RechargeItemScriptGameConfiguration[]? RechargeItemScripts { get; set; } = null;
    public virtual TeleportSelfScriptGameConfiguration[]? TeleportSelfScripts { get; set; } = null;
    public virtual MappedItemEnhancementGameConfiguration[]? MappedItemEnhancements { get; set; } = null;
    public virtual ChestTrapGameConfiguration[]? ChestTraps { get; set; } = null;

    public virtual int[] RequiredExperiencePerLevel => new int[] // TODO: Need defaults removed.
    {
        10, 25, 45, 70, 100, 140, 200, 280, 380, 500, 650, 850, 1100, 1400, 1800, 2300, 2900, 3600, 4400, 5400,
        6800, 8400, 10200, 12500, 17500, 25000, 35000, 50000, 75000, 100000, 150000, 200000, 275000, 350000, 450000,
        550000, 700000, 850000, 1000000, 1250000, 1500000, 1800000, 2100000, 2400000, 2700000, 3000000, 3500000,
        4000000, 4500000, 5000000
    };

    public virtual int[] ExtractEnergy => new int[] // TODO: Need defaults removed.
    {
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* S-50 */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* S-40 */     2,  2,  2,  2,  2,  2,  2,  2,  2,  2,
	/* S-30 */     2,  2,  2,  2,  2,  2,  2,  3,  3,  3,
	/* S-20 */     3,  3,  3,  3,  3,  4,  4,  4,  4,  4,
	/* S-10 */     5,  5,  5,  5,  6,  6,  7,  7,  8,  9,
	/* Norm */    10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
	/* F+10 */    20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
	/* F+20 */    30, 31, 32, 33, 34, 35, 36, 36, 37, 37,
	/* F+30 */    38, 38, 39, 39, 40, 40, 40, 41, 41, 41,
	/* F+40 */    42, 42, 42, 43, 43, 43, 44, 44, 44, 44,
	/* F+50 */    45, 45, 45, 45, 45, 46, 46, 46, 46, 46,
	/* F+60 */    47, 47, 47, 47, 47, 48, 48, 48, 48, 48,
	/* F+70 */    49, 49, 49, 49, 49, 49, 49, 49, 49, 49,
	/* Fast */    49, 49, 49, 49, 49, 49, 49, 49, 49, 49
    };

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
