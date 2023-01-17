using System.Reflection;

namespace AngbandOS.Commands
{
    internal static class ObjectRepository
    {
        public static List<AmuletFlavour> AmuletFlavours = new List<AmuletFlavour>();
        public static List<MushroomFlavour> MushroomFlavours = new List<MushroomFlavour>();
        public static List<PotionFlavour> PotionFlavours = new List<PotionFlavour>();
        public static List<RingFlavour> RingFlavours = new List<RingFlavour>();
        public static List<RodFlavour> RodFlavours = new List<RodFlavour>();
        public static List<BaseScrollFlavour> ScrollFlavours = new List<BaseScrollFlavour>();
        public static List<StaffFlavour> StaffFlavours = new List<StaffFlavour>();
        public static List<WandFlavour> WandFlavours = new List<WandFlavour>();
        public static List<ChestTrapConfiguration> ChestTrapConfigurations = new List<ChestTrapConfiguration>();
        public static Dictionary<string, ProjectileGraphic> ProjectileGraphics = new Dictionary<string, ProjectileGraphic>();
        public static Dictionary<string, Animation> Animations = new Dictionary<string, Animation>();
        public static Dictionary<string, Vault> Vaults = new Dictionary<string, Vault>();
        public static Dictionary<string, FloorTileType> FloorTileTypes = new Dictionary<string, FloorTileType>();
        public static Dictionary<string, Base2RareItemType> RareItemTypes = new Dictionary<string, Base2RareItemType>();

        static ObjectRepository()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load AmuletFlavours.
                if (!type.IsAbstract && typeof(AmuletFlavour).IsAssignableFrom(type))
                {
                    AmuletFlavour baseAmuletFlavour = (AmuletFlavour)Activator.CreateInstance(type);
                    AmuletFlavours.Add(baseAmuletFlavour);
                }

                // Load MushroomFlavours.
                if (!type.IsAbstract && typeof(MushroomFlavour).IsAssignableFrom(type))
                {
                    MushroomFlavour baseMushroomFlavour = (MushroomFlavour)Activator.CreateInstance(type);
                    MushroomFlavours.Add(baseMushroomFlavour);
                }

                // Load PotionFlavours.
                if (!type.IsAbstract && typeof(PotionFlavour).IsAssignableFrom(type))
                {
                    PotionFlavour basePotionFlavour = (PotionFlavour)Activator.CreateInstance(type);
                    PotionFlavours.Add(basePotionFlavour);
                }

                // Load RingFlavours.
                if (!type.IsAbstract && typeof(RingFlavour).IsAssignableFrom(type))
                {
                    RingFlavour baseRingFlavour = (RingFlavour)Activator.CreateInstance(type);
                    RingFlavours.Add(baseRingFlavour);
                }

                // Load RodFlavours.
                if (!type.IsAbstract && typeof(RodFlavour).IsAssignableFrom(type))
                {
                    RodFlavour baseRodFlavour = (RodFlavour)Activator.CreateInstance(type);
                    RodFlavours.Add(baseRodFlavour);
                }

                // Load ScrollFlavours.
                if (!type.IsAbstract && typeof(BaseScrollFlavour).IsAssignableFrom(type))
                {
                    BaseScrollFlavour baseScrollFlavour = (BaseScrollFlavour)Activator.CreateInstance(type);
                    ScrollFlavours.Add(baseScrollFlavour);
                }

                // Load StaffFlavours.
                if (!type.IsAbstract && typeof(StaffFlavour).IsAssignableFrom(type))
                {
                    StaffFlavour baseStaffFlavour = (StaffFlavour)Activator.CreateInstance(type);
                    StaffFlavours.Add(baseStaffFlavour);
                }

                // Load WandFlavours.
                if (!type.IsAbstract && typeof(WandFlavour).IsAssignableFrom(type))
                {
                    WandFlavour wandFlavour = (WandFlavour)Activator.CreateInstance(type);
                    WandFlavours.Add(wandFlavour);
                }

                // Load ChestTrapConfigurations.
                if (!type.IsAbstract && typeof(ChestTrapConfiguration).IsAssignableFrom(type))
                {
                    ChestTrapConfiguration chestTrapConfiguration = (ChestTrapConfiguration)Activator.CreateInstance(type);
                    ChestTrapConfigurations.Add(chestTrapConfiguration);
                }

                // Load ProjectileGraphics.
                if (!type.IsAbstract && typeof(ProjectileGraphic).IsAssignableFrom(type))
                {
                    ProjectileGraphic projectileGraphic = (ProjectileGraphic)Activator.CreateInstance(type);
                    ProjectileGraphics.Add(projectileGraphic.Name, projectileGraphic);
                }

                // Load Animations.
                if (!type.IsAbstract && typeof(Animation).IsAssignableFrom(type))
                {
                    Animation animation = (Animation)Activator.CreateInstance(type);
                    Animations.Add(animation.Name, animation);
                }

                // Load Vault Types.
                if (!type.IsAbstract && typeof(Vault).IsAssignableFrom(type))
                {
                    Vault vaultType = (Vault)Activator.CreateInstance(type);
                    Vaults.Add(vaultType.Name, vaultType);
                }

                // Load Floor Tile Type.
                if (!type.IsAbstract && typeof(FloorTileType).IsAssignableFrom(type))
                {
                    FloorTileType floorTileType = (FloorTileType)Activator.CreateInstance(type);
                    FloorTileTypes.Add(floorTileType.Name, floorTileType);
                }

                // Load Rare Item Type.
                if (!type.IsAbstract && typeof(Base2RareItemType).IsAssignableFrom(type))
                {
                    Base2RareItemType rareItemType = (Base2RareItemType)Activator.CreateInstance(type);
                    RareItemTypes.Add(rareItemType.Name, rareItemType);
                }
            }
        }
    }
}
