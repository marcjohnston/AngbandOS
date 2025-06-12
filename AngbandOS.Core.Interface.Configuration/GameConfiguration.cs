using System.Diagnostics;
using System.Reflection;

namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents an interface that describes the configuration data that the GameServer.Play method accepts.  This configuration data is used to completely
/// configure a new game.  Use the ConfigurationMetadata object to get metadata details that can be used to generate configuration data.
/// </summary>
[Serializable]
public class GameConfiguration
{
    private static T[] LoadFromAssembly<T>(Assembly assembly) where T : new()
    {
        List<T> singletonsList = new List<T>();

        int i = 0;
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

    public static GameConfiguration LoadFromAssembly(Assembly assembly)
    {
        GameConfiguration gameConfiguration = new GameConfiguration();
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
        gameConfiguration.ProjectileWeightedRandomScripts = LoadFromAssembly<ProjectileWeightedRandomGameConfiguration>(assembly);
        gameConfiguration.BoolWidgets = LoadFromAssembly<BoolWidgetGameConfiguration>(assembly);
        gameConfiguration.ConditionalWidgets = LoadFromAssembly<ConditionalWidgetGameConfiguration>(assembly);
        gameConfiguration.DateWidgets = LoadFromAssembly<DateWidgetGameConfiguration>(assembly);
        gameConfiguration.IntWidgets = LoadFromAssembly<IntWidgetGameConfiguration>(assembly);
        gameConfiguration.MapWidgets = LoadFromAssembly<MapWidgetGameConfiguration>(assembly);
        gameConfiguration.MaxRangedWidgets = LoadFromAssembly<MaxRangedWidgetGameConfiguration>(assembly);
        gameConfiguration.RangedWidgets = LoadFromAssembly<RangedWidgetGameConfiguration>(assembly);
        gameConfiguration.StringWidgets = LoadFromAssembly<StringWidgetGameConfiguration>(assembly);
        gameConfiguration.TextWidgets = LoadFromAssembly<TextWidgetGameConfiguration>(assembly);
        gameConfiguration.TimeWidgets = LoadFromAssembly<TimeWidgetGameConfiguration>(assembly);
        gameConfiguration.NullableStringsTextAreaWidgets = LoadFromAssembly<NullableStringsTextAreaWidgetGameConfiguration>(assembly);
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
        return gameConfiguration;
    }

    /// <summary>
    /// Returns the number of log items that the message history is allowed to store.  A null value indicates that there is no limit.  The default value is 2048.
    /// </summary>    
    public virtual int? MaxMessageLogLength { get; set; } = 2048;

    public virtual string? ConsoleViewBindingKey { get; set; } = null;

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
    public virtual ItemFactoryGameConfiguration[]? ItemFactories { get; set; } = null;
    public virtual ProjectileWeightedRandomGameConfiguration[]? ProjectileWeightedRandomScripts { get; set; } = null;

    public virtual BoolWidgetGameConfiguration[]? BoolWidgets { get; set; } = null;
    public virtual ConditionalWidgetGameConfiguration[]? ConditionalWidgets { get; set; } = null;
    public virtual DateWidgetGameConfiguration[]? DateWidgets { get; set; } = null;
    public virtual IntWidgetGameConfiguration[]? IntWidgets { get; set; } = null;
    public virtual MapWidgetGameConfiguration[]? MapWidgets { get; set; } = null;
    public virtual MaxRangedWidgetGameConfiguration[]? MaxRangedWidgets { get; set; } = null;
    public virtual RangedWidgetGameConfiguration[]? RangedWidgets { get; set; } = null;
    public virtual StringWidgetGameConfiguration[]? StringWidgets { get; set; } = null;
    public virtual TextWidgetGameConfiguration[]? TextWidgets { get; set; } = null;
    public virtual TimeWidgetGameConfiguration[]? TimeWidgets { get; set; } = null;
    public virtual NullableStringsTextAreaWidgetGameConfiguration[]? NullableStringsTextAreaWidgets { get; set; } = null;

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
}
