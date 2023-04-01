using System.Reflection;

namespace AngbandOS.Core
{
    [Serializable]
    /// <summary>
    /// Represents a repository for all game singletons.
    /// </summary>
    internal class SingletonRepository
    {
        public SingletonDictionary<string, Animation> Animations;
        public SingletonDictionary<FixedArtifactId, FixedArtifact> FixedArtifacts;
        public SingletonDictionary<string, FloorTileType> FloorTileTypes;
        public SingletonList<InGameCommand> InGameCommands;
        public SingletonList<BaseInventorySlot> InventorySlots;
        public SingletonList<ItemClass> ItemCategories;
        public SingletonList<MonsterRace> MonsterRaces;
        public SingletonDictionary<string, ProjectileGraphic> ProjectileGraphics;
        public SingletonList<Race> Races;
        public SingletonDictionary<RareItemTypeEnum, RareItem> RareItemTypes;
        public SingletonList<BaseStoreCommand> StoreCommands;
        public SingletonList<Vault> Vaults;
        public SingletonList<WizardCommand> WizardCommands;
        public SingletonList<TimedAction> TimedActions;
        public SingletonList<BaseCharacterClass> CharacterClasses;
        public SingletonList<BaseRealm> Realms;
        public SingletonList<Town> Towns;
        public SingletonList<AmuletFlavour> AmuletFlavours;
        public SingletonList<MushroomFlavour> MushroomFlavours;
        public SingletonList<PotionFlavour> PotionFlavours;
        public SingletonList<RingFlavour> RingFlavours;
        public SingletonList<RodFlavour> RodFlavours;
        public SingletonList<BaseScrollFlavour> ScrollFlavours;
        public SingletonList<StaffFlavour> StaffFlavours;
        public SingletonList<WandFlavour> WandFlavours;
        public SingletonList<ChestTrapConfiguration> ChestTrapConfigurations;
        public SingletonList<HelpGroup> HelpGroups;
        public SingletonList<StoreOwner> StoreOwners;

        public SingletonBaseList<string> ShopKeeperGoodComments;
        public SingletonBaseList<string> ShopKeeperBargainComments;
        public SingletonBaseList<string> ElvishText;
        public SingletonBaseList<string> FunnyComments;
        public SingletonBaseList<string> FunnyDescriptions;
        public SingletonBaseList<string> HorrificDescriptions;
        public SingletonBaseList<string> InsultPlayerAttacks;
        public SingletonBaseList<string> MoanPlayerAttacks;
                        
        public SingletonBaseList<string> ShopKeeperLessThanGuessComments;
        public SingletonBaseList<string> ShopKeeperWorthlessComments;
        public SingletonBaseList<string> SingingPlayerAttacks;
        public SingletonBaseList<string> StoreOwnerAcceptedComments;
        public SingletonBaseList<string> WorshipPlayerAttacks;

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
            InGameCommands = new SingletonList<InGameCommand>(saveGame, LoadTypesFromAssembly<InGameCommand>(saveGame));
            WizardCommands = new SingletonList<WizardCommand>(saveGame, LoadTypesFromAssembly<WizardCommand>(saveGame));
            ItemCategories = new SingletonList<ItemClass>(saveGame, LoadTypesFromAssembly<ItemClass>(saveGame));
            InventorySlots = new SingletonList<BaseInventorySlot>(saveGame, LoadTypesFromAssembly<BaseInventorySlot>(saveGame));
            StoreCommands = new SingletonList<BaseStoreCommand>(saveGame, LoadTypesFromAssembly<BaseStoreCommand>(saveGame));
            CharacterClasses = new SingletonList<BaseCharacterClass>(saveGame, LoadTypesFromAssembly<BaseCharacterClass>(saveGame));
            Realms = new SingletonList<BaseRealm>(saveGame, LoadTypesFromAssembly<BaseRealm>(saveGame));
            Towns = new SingletonList<Town>(saveGame, LoadTypesFromAssembly<Town>(saveGame));
            AmuletFlavours = new SingletonList<AmuletFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<AmuletFlavour>(saveGame)));
            MushroomFlavours = new SingletonList<MushroomFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<MushroomFlavour>(saveGame)));
            PotionFlavours = new SingletonList<PotionFlavour>(saveGame, WeightedShuffle(LoadTypesFromAssembly<PotionFlavour>(saveGame)));
            RingFlavours = new SingletonList<RingFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<RingFlavour>(saveGame)));
            RodFlavours = new SingletonList<RodFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<RodFlavour>(saveGame)));
            ScrollFlavours = new SingletonList<BaseScrollFlavour>(saveGame, LoadTypesFromAssembly<BaseScrollFlavour>(saveGame));
            StaffFlavours = new SingletonList<StaffFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<StaffFlavour>(saveGame)));
            WandFlavours = new SingletonList<WandFlavour>(saveGame, Shuffle(LoadTypesFromAssembly<WandFlavour>(saveGame)));
            ChestTrapConfigurations = new SingletonList<ChestTrapConfiguration>(saveGame, LoadTypesFromAssembly<ChestTrapConfiguration>(saveGame));
            ProjectileGraphics = new SingletonDictionary<string, ProjectileGraphic>(saveGame, LoadTypesFromAssembly<ProjectileGraphic>(saveGame));
            Animations = new SingletonDictionary<string, Animation>(saveGame, LoadTypesFromAssembly<Animation>(saveGame));
            Vaults = new SingletonList<Vault>(saveGame, LoadTypesFromAssembly<Vault>(saveGame));
            FloorTileTypes = new SingletonDictionary<string, FloorTileType>(saveGame, LoadTypesFromAssembly<FloorTileType>(saveGame));
            RareItemTypes = new SingletonDictionary<RareItemTypeEnum, RareItem>(saveGame, LoadTypesFromAssembly<RareItem>(saveGame));
            FixedArtifacts = new SingletonDictionary<FixedArtifactId, FixedArtifact>(saveGame, LoadTypesFromAssembly<FixedArtifact>(saveGame));
            MonsterRaces = new SingletonList<MonsterRace>(saveGame, LoadTypesFromAssembly<MonsterRace>(saveGame).OrderBy(_monsterRace => _monsterRace.LevelFound));
            Races = new SingletonList<Race>(saveGame, LoadTypesFromAssembly<Race>(saveGame));
            HelpGroups = new SingletonList<HelpGroup>(saveGame, LoadTypesFromAssembly<HelpGroup>(saveGame));
            StoreOwners = new SingletonList<StoreOwner>(saveGame, LoadTypesFromAssembly<StoreOwner>(saveGame));
            ShopKeeperGoodComments = new SingletonBaseList<string>(saveGame, "Cool!", "You've made my day!", "The shopkeeper giggles.", "The shopkeeper laughs loudly.");
            ShopKeeperBargainComments = new SingletonBaseList<string>(saveGame, "Yipee!", "I think I'll retire!", "The shopkeeper jumps for joy.", "The shopkeeper smiles gleefully.");
            ElvishText = new SingletonBaseList<string>(saveGame,
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
            FunnyComments = new SingletonBaseList<string>(saveGame, "Wow, cosmic, man!", "Rad!", "Groovy!", "Cool!", "Far out!");
            FunnyDescriptions = new SingletonBaseList<string>(saveGame, 
                "silly", "hilarious", "absurd", "insipid", "ridiculous", "laughable", "ludicrous", "far-out", "groovy",
                "postmodern", "fantastic", "dadaistic", "cubistic", "cosmic", "awesome", "incomprehensible", "fabulous",
                "amazing", "incredible", "chaotic", "wild", "preposterous");
            HorrificDescriptions = new SingletonBaseList<string>(saveGame, 
                "abominable", "abysmal", "appalling", "baleful", "blasphemous", "disgusting", "dreadful", "filthy",
                "grisly", "hideous", "hellish", "horrible", "infernal", "loathsome", "nightmarish", "repulsive",
                "sacrilegious", "terrible", "unclean", "unspeakable");
            InsultPlayerAttacks = new SingletonBaseList<string>(saveGame, 
                "insults you!", "insults your mother!", "gives you the finger!", "humiliates you!", "defiles you!",
                "dances around you!", "makes obscene gestures!", "moons you!");
            MoanPlayerAttacks = new SingletonBaseList<string>(saveGame, "seems sad about something.", "asks if you have seen his dogs.", "tells you to get off his land.", "mumbles something about mushrooms.");
            ShopKeeperLessThanGuessComments = new SingletonBaseList<string>(saveGame, "Damn!", "You bastard!", "The shopkeeper curses at you.", "The shopkeeper glares at you.");
            ShopKeeperWorthlessComments = new SingletonBaseList<string>(saveGame, "Arrgghh!", "You bastard!", "You hear someone sobbing...", "The shopkeeper howls in agony!");
            SingingPlayerAttacks = new SingletonBaseList<string>(saveGame, "sings 'We are a happy family.'", "sings 'I love you, you love me.'");
            StoreOwnerAcceptedComments = new SingletonBaseList<string>(saveGame, "Okay.", "Fine.", "Accepted!", "Agreed!", "Done!", "Taken!");
            WorshipPlayerAttacks = new SingletonBaseList<string>(saveGame, 
                "looks up at you!", "asks how many dragons you've killed!", "asks for your autograph!", "tries to shake your hand!", "pretends to be you!",
                "dances around you!", "tugs at your clothing!", "asks if you will adopt him!");
        }
}
}