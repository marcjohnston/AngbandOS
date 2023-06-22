// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Reflection;

namespace AngbandOS.Core;

[Serializable]
/// <summary>
/// Represents a repository for all game singletons.
/// </summary>
internal class SingletonRepository
{
    public SingletonDictionary<Script> Scripts;
    public SingletonDictionary<Dungeon> Dungeons;
    public SingletonDictionary<Gender> Genders;
    public SingletonDictionary<BaseBirthStage> BirthStages;
    public SingletonDictionary<Projectile> Projectiles;
    public SingletonDictionary<Patron> Patrons;
    public SingletonDictionary<Animation> Animations;
    public SingletonDictionary<FixedArtifact> FixedArtifacts;
    [Obsolete("Needs to be non-keyed")]
    public SingletonKeyedDictionary<string, FloorTileType> FloorTileTypes;
    public SingletonDictionary<GameCommand> GameCommands;
    public SingletonDictionary<ArtifactBias> ArtifactBiases;
    public SingletonDictionary<BaseInventorySlot> InventorySlots;
    public SingletonDictionary<ItemFactory> ItemFactories;
    public SingletonDictionary<MonsterRace> MonsterRaces;
    public SingletonDictionary<ProjectileGraphic> ProjectileGraphics;
    public SingletonDictionary<Activation> Activations;
    public SingletonDictionary<Race> Races;
    [Obsolete("Needs to be non-keyed")]
    public SingletonKeyedDictionary<RareItemTypeEnum, RareItem> RareItems;
    public SingletonDictionary<BaseStoreCommand> StoreCommands;
    public SingletonDictionary<Vault> Vaults;
    public SingletonDictionary<WizardCommand> WizardCommands;
    public SingletonDictionary<TimedAction> TimedActions;
    public SingletonDictionary<BaseCharacterClass> CharacterClasses;
    public SingletonDictionary<BaseRealm> Realms;
    public SingletonDictionary<Town> Towns;
    public SingletonDictionary<AmuletFlavour> AmuletFlavours;
    public SingletonDictionary<MushroomFlavour> MushroomFlavours;
    public SingletonDictionary<PotionFlavour> PotionFlavours;
    public SingletonDictionary<RingFlavour> RingFlavours;
    public SingletonDictionary<RodFlavour> RodFlavours;
    public SingletonDictionary<BaseScrollFlavour> ScrollFlavours;
    public SingletonDictionary<StaffFlavour> StaffFlavours;
    public SingletonDictionary<WandFlavour> WandFlavours;
    public SingletonDictionary<ChestTrapConfiguration> ChestTrapConfigurations;
    public SingletonDictionary<HelpGroup> HelpGroups;
    public SingletonDictionary<StoreOwner> StoreOwners;
    public SingletonList<ClassSpell> ClassSpells; // TODO: This needs to use a DualDictionary
    public SingletonDictionary<Spell> Spells;
    public SingletonDictionary<CastingType> CastingTypes;
    public SingletonDictionary<Reward> Rewards;

    public SingletonList<string> ShopKeeperGoodComments;
    public SingletonList<string> ShopKeeperBargainComments;
    public SingletonList<string> ElvishText;
    public SingletonList<string> FunnyComments;
    public SingletonList<string> FunnyDescriptions;
    public SingletonList<string> HorrificDescriptions;
    public SingletonList<string> InsultPlayerAttacks;
    public SingletonList<string> MoanPlayerAttacks;
                    
    public SingletonList<string> ShopKeeperLessThanGuessComments;
    public SingletonList<string> ShopKeeperWorthlessComments;
    public SingletonList<string> SingingPlayerAttacks;
    public SingletonList<string> StoreOwnerAcceptedComments;
    public SingletonList<string> WorshipPlayerAttacks;
    public SingletonList<string> FindQuests;

    private T[] LoadTypesFromAssembly<T>(SaveGame saveGame)
    {
        List<T> typeList = new List<T>();
        Assembly assembly = Assembly.GetExecutingAssembly();
        foreach (Type type in assembly.GetTypes())
        {
            // Load Commands.
            if (!type.IsAbstract && typeof(T).IsAssignableFrom(type))
            {
                ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                if (constructors.Length == 1)
                {
                    T command = (T)constructors[0].Invoke(new object[] { saveGame });
                    typeList.Add(command);
                }
            }
        }
        return typeList.ToArray();
    }

    private T[] Shuffle<T>(IEnumerable<T> items) => items.OrderBy(_item => Program.Rng.RandomLessThan(int.MaxValue)).ToArray();
    private T[] WeightedShuffle<T>(T[] items) where T : IWeightedShuffle
    {
        Dictionary<int, List<T>> itemsByWeight = new Dictionary<int, List<T>>();
        foreach (T item in items)
        {
            List<T>? list = null;
            if (!itemsByWeight.TryGetValue(item.ShuffleWeight, out list))
            {
                list = new List<T>();
                itemsByWeight.Add(item.ShuffleWeight, list);
            }
            list.Add(item);
        }

        // Sort the dictionary.
        List<T> shuffledList = new List<T>();
        foreach (KeyValuePair<int, List<T>> weightAndItem in itemsByWeight.OrderByDescending(_weightAndItem => _weightAndItem.Key))
        {
            shuffledList.AddRange(Shuffle(weightAndItem.Value));
        }           
        return shuffledList.ToArray();
    }

    public void Initialize(SaveGame saveGame)
    {
        Scripts = new SingletonDictionary<Script>(saveGame, LoadTypesFromAssembly<Script>(saveGame));
        Dungeons = new SingletonDictionary<Dungeon>(saveGame, LoadTypesFromAssembly<Dungeon>(saveGame));
        Genders = new SingletonDictionary<Gender>(saveGame, LoadTypesFromAssembly<Gender>(saveGame));
        BirthStages = new SingletonDictionary<BaseBirthStage>(saveGame, LoadTypesFromAssembly<BaseBirthStage>(saveGame));
        ClassSpells = new SingletonList<ClassSpell>(saveGame, LoadTypesFromAssembly<ClassSpell>(saveGame));
        Rewards = new SingletonDictionary<Reward>(saveGame, LoadTypesFromAssembly<Reward>(saveGame));
        Projectiles = new SingletonDictionary<Projectile>(saveGame, LoadTypesFromAssembly<Projectile>(saveGame));
        Patrons = new SingletonDictionary<Patron>(saveGame, LoadTypesFromAssembly<Patron>(saveGame));
        Spells = new SingletonDictionary<Spell>(saveGame, LoadTypesFromAssembly<Spell>(saveGame));
        CastingTypes = new SingletonDictionary<CastingType>(saveGame, LoadTypesFromAssembly<CastingType>(saveGame));
        GameCommands = new SingletonDictionary<GameCommand>(saveGame, LoadTypesFromAssembly<GameCommand>(saveGame));
        WizardCommands = new SingletonDictionary<WizardCommand>(saveGame, LoadTypesFromAssembly<WizardCommand>(saveGame));
        ItemFactories = new SingletonDictionary<ItemFactory>(saveGame, LoadTypesFromAssembly<ItemFactory>(saveGame));
        InventorySlots = new SingletonDictionary<BaseInventorySlot>(saveGame, LoadTypesFromAssembly<BaseInventorySlot>(saveGame));
        StoreCommands = new SingletonDictionary<BaseStoreCommand>(saveGame, LoadTypesFromAssembly<BaseStoreCommand>(saveGame));
        ArtifactBiases = new SingletonDictionary<ArtifactBias>(saveGame, LoadTypesFromAssembly<ArtifactBias>(saveGame));
        Activations = new SingletonDictionary<Activation>(saveGame, LoadTypesFromAssembly<Activation>(saveGame));
        CharacterClasses = new SingletonDictionary<BaseCharacterClass>(saveGame, LoadTypesFromAssembly<BaseCharacterClass>(saveGame));
        Realms = new SingletonDictionary<BaseRealm>(saveGame, LoadTypesFromAssembly<BaseRealm>(saveGame));
        Towns = new SingletonDictionary<Town>(saveGame, LoadTypesFromAssembly<Town>(saveGame));
        AmuletFlavours = new SingletonDictionary<AmuletFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<AmuletFlavour>(saveGame)));
        MushroomFlavours = new SingletonDictionary<MushroomFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<MushroomFlavour>(saveGame)));
        PotionFlavours = new SingletonDictionary<PotionFlavour>(saveGame, WeightedShuffle(LoadTypesFromAssembly<PotionFlavour>(saveGame)));
        RingFlavours = new SingletonDictionary<RingFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<RingFlavour>(saveGame)));
        RodFlavours = new SingletonDictionary<RodFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<RodFlavour>(saveGame)));
        ScrollFlavours = new SingletonDictionary<BaseScrollFlavour>(saveGame, LoadTypesFromAssembly<BaseScrollFlavour>(saveGame));
        StaffFlavours = new SingletonDictionary<StaffFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<StaffFlavour>(saveGame)));
        WandFlavours = new SingletonDictionary<WandFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<WandFlavour>(saveGame)));
        ChestTrapConfigurations = new SingletonDictionary<ChestTrapConfiguration>(saveGame, LoadTypesFromAssembly<ChestTrapConfiguration>(saveGame));
        ProjectileGraphics = new SingletonDictionary<ProjectileGraphic>(saveGame, LoadTypesFromAssembly<ProjectileGraphic>(saveGame));
        Animations = new SingletonDictionary<Animation>(saveGame, LoadTypesFromAssembly<Animation>(saveGame));
        Vaults = new SingletonDictionary<Vault>(saveGame, LoadTypesFromAssembly<Vault>(saveGame));
        FloorTileTypes = new SingletonKeyedDictionary<string, FloorTileType>(saveGame, LoadTypesFromAssembly<FloorTileType>(saveGame));
        RareItems = new SingletonKeyedDictionary<RareItemTypeEnum, RareItem>(saveGame, LoadTypesFromAssembly<RareItem>(saveGame));
        FixedArtifacts = new SingletonDictionary<FixedArtifact>(saveGame, LoadTypesFromAssembly<FixedArtifact>(saveGame));
        MonsterRaces = new SingletonDictionary<MonsterRace>(saveGame, LoadTypesFromAssembly<MonsterRace>(saveGame).OrderBy(_monsterRace => _monsterRace.LevelFound));
        Races = new SingletonDictionary<Race>(saveGame, LoadTypesFromAssembly<Race>(saveGame));
        HelpGroups = new SingletonDictionary<HelpGroup>(saveGame, LoadTypesFromAssembly<HelpGroup>(saveGame));
        StoreOwners = new SingletonDictionary<StoreOwner>(saveGame, LoadTypesFromAssembly<StoreOwner>(saveGame));
        ShopKeeperGoodComments = new SingletonList<string>(saveGame, "Cool!", "You've made my day!", "The shopkeeper giggles.", "The shopkeeper laughs loudly.");
        ShopKeeperBargainComments = new SingletonList<string>(saveGame, "Yipee!", "I think I'll retire!", "The shopkeeper jumps for joy.", "The shopkeeper smiles gleefully.");
        ElvishText = new SingletonList<string>(saveGame,
            "adan", "ael", "in", "agl", "ar", "aina", "alda", "al", "qua", "am", "arth", "amon", "anca", "an", "dune",
            "anga", "anna", "ann", "on", "ar", "ien", "atar", "band", "bar", "ad", "bel", "eg", "brag", "ol", "breth",
            "il", "brith", "cal", "en", "gal", "en", "cam", "car", "ak", "cel", "eb", "cor", "on", "cu", "cui", "vie",
            "cul", "curu", "dae", "dag", "or", "del", "din", "dol", "dor", "draug", "du", "duin", "dur", "ear", "ech",
            "or", "edh", "el", "eith", "elen", "er", "ereg", "es", "gal", "fal", "as", "far", "oth", "faug", "fea",
            "fin", "for", "men", "fuin", "gaer", "gaur", "gil", "gir", "ith", "glin", "gol", "odh", "gond", "gor",
            "groth", "grod", "gul", "gurth", "gwaith", "gwath", "wath", "had", "hod", "haudh", "heru", "him", "hini",
            "hith", "hoth", "hyar", "men", "ia", "iant", "iath", "iaur", "ilm", "iluve", "kal", "gal", "kano", "kel",
            "kemen", "khel", "ek", "khil", "kir", "lad", "laure", "lhach", "lin", "lith", "lok", "lom", "lome", "londe",
            "los", "loth", "luin", "maeg", "mal", "man", "mel", "men", "menel", "mer", "eth", "min", "as", "mir",
            "mith", "mor", "moth", "nan", "nar", "naug", "dil", "dur", "nel", "dor", "nen", "nim", "orn", "orod", "os",
            "pal", "an", "pel", "quen", "quet", "ram", "ran", "rant", "ras", "rauko", "ril", "rim", "ring", "ris",
            "roch", "rom", "rond", "ros", "ruin", "ruth", "sarn", "ser", "eg", "sil", "sir", "sul", "tal", "dal", "tal",
            "ath", "tar", "tath", "ar", "taur", "tel", "thal", "thang", "thar", "thaur", "thin", "thol", "thon", "thor",
            "on", "til", "tin", "tir", "tol", "tum", "tur", "uial", "ur", "val", "wen", "wing", "yave");
        FunnyComments = new SingletonList<string>(saveGame, "Wow, cosmic, man!", "Rad!", "Groovy!", "Cool!", "Far out!");
        FunnyDescriptions = new SingletonList<string>(saveGame, 
            "silly", "hilarious", "absurd", "insipid", "ridiculous", "laughable", "ludicrous", "far-out", "groovy",
            "postmodern", "fantastic", "dadaistic", "cubistic", "cosmic", "awesome", "incomprehensible", "fabulous",
            "amazing", "incredible", "chaotic", "wild", "preposterous");
        HorrificDescriptions = new SingletonList<string>(saveGame, 
            "abominable", "abysmal", "appalling", "baleful", "blasphemous", "disgusting", "dreadful", "filthy",
            "grisly", "hideous", "hellish", "horrible", "infernal", "loathsome", "nightmarish", "repulsive",
            "sacrilegious", "terrible", "unclean", "unspeakable");
        InsultPlayerAttacks = new SingletonList<string>(saveGame, 
            "insults you!", "insults your mother!", "gives you the finger!", "humiliates you!", "defiles you!",
            "dances around you!", "makes obscene gestures!", "moons you!");
        MoanPlayerAttacks = new SingletonList<string>(saveGame, "seems sad about something.", "asks if you have seen his dogs.", "tells you to get off his land.", "mumbles something about mushrooms.");
        ShopKeeperLessThanGuessComments = new SingletonList<string>(saveGame, "Damn!", "You bastard!", "The shopkeeper curses at you.", "The shopkeeper glares at you.");
        ShopKeeperWorthlessComments = new SingletonList<string>(saveGame, "Arrgghh!", "You bastard!", "You hear someone sobbing...", "The shopkeeper howls in agony!");
        SingingPlayerAttacks = new SingletonList<string>(saveGame, "sings 'We are a happy family.'", "sings 'I love you, you love me.'");
        StoreOwnerAcceptedComments = new SingletonList<string>(saveGame, "Okay.", "Fine.", "Accepted!", "Agreed!", "Done!", "Taken!");
        WorshipPlayerAttacks = new SingletonList<string>(saveGame, 
            "looks up at you!", "asks how many dragons you've killed!", "asks for your autograph!", "tries to shake your hand!", "pretends to be you!",
            "dances around you!", "tugs at your clothing!", "asks if you will adopt him!");
        FindQuests = new SingletonList<string>(saveGame,
            "You find the following inscription in the floor",
            "You see a message inscribed in the wall",
            "There is a sign saying",
            "Something is written on the staircase",
            "You find a scroll with the following message");

        // We need to initialize the monster race indexes.
        for (int i = 0; i < MonsterRaces.Count; i++)
        {
            MonsterRace monsterRace = MonsterRaces[i];
            monsterRace.Index = i;
        }
    }
}