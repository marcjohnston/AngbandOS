using AngbandOS.Core;
using AngbandOS.ItemCategories;
using AngbandOS.StaticData;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AngbandOS.Commands
{
    internal static class CommandManager
    {
        public static List<ICommand> GameCommands = new List<ICommand>();
        public static List<IStoreCommand> StoreCommands = new List<IStoreCommand>();
        public static List<AmuletFlavour> BaseAmuletFlavours = new List<AmuletFlavour>();
        public static List<MushroomFlavour> BaseMushroomFlavours = new List<MushroomFlavour>();
        public static List<PotionFlavour> BasePotionFlavours = new List<PotionFlavour>();
        public static List<RingFlavour> BaseRingFlavours = new List<RingFlavour>();
        public static List<RodFlavour> BaseRodFlavours = new List<RodFlavour>();
        public static List<BaseScrollFlavour> BaseScrollFlavours = new List<BaseScrollFlavour>();
        public static List<StaffFlavour> BaseStaffFlavours = new List<StaffFlavour>();
        public static List<WandFlavour> BaseWandFlavours = new List<WandFlavour>();
        public static Dictionary<string, ProjectileGraphic> BaseProjectileGraphics = new Dictionary<string, ProjectileGraphic>();
        public static Dictionary<string, Animation> BaseAnimations = new Dictionary<string, Animation>();
        public static Dictionary<string, Vault> Base2VaultTypes = new Dictionary<string, Vault>();
        public static Dictionary<string, FloorTileType> BaseFloorTileTypes = new Dictionary<string, FloorTileType>();
        public static Dictionary<string, Base2RareItemType> Base2RareItemTypes = new Dictionary<string, Base2RareItemType>();
        public static Dictionary<string, Base2FixedArtifact> Base2FixedArtifacts = new Dictionary<string, Base2FixedArtifact>();

        static CommandManager()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load StoreCommands.
                if (!type.IsAbstract && typeof(IStoreCommand).IsAssignableFrom(type))
                {
                    IStoreCommand command = (IStoreCommand)Activator.CreateInstance(type);
                    StoreCommands.Add(command);
                }

                // Load Commands.
                if (!type.IsAbstract && typeof(ICommand).IsAssignableFrom(type))
                {
                    ICommand command = (ICommand)Activator.CreateInstance(type);
                    GameCommands.Add(command);
                }

                // Load AmuletFlavours.
                if (!type.IsAbstract && typeof(AmuletFlavour).IsAssignableFrom(type))
                {
                    AmuletFlavour baseAmuletFlavour = (AmuletFlavour)Activator.CreateInstance(type);
                    BaseAmuletFlavours.Add(baseAmuletFlavour);
                }

                // Load MushroomFlavours.
                if (!type.IsAbstract && typeof(MushroomFlavour).IsAssignableFrom(type))
                {
                    MushroomFlavour baseMushroomFlavour = (MushroomFlavour)Activator.CreateInstance(type);
                    BaseMushroomFlavours.Add(baseMushroomFlavour);
                }

                // Load PotionFlavours.
                if (!type.IsAbstract && typeof(PotionFlavour).IsAssignableFrom(type))
                {
                    PotionFlavour basePotionFlavour = (PotionFlavour)Activator.CreateInstance(type);
                    BasePotionFlavours.Add(basePotionFlavour);
                }

                // Load RingFlavours.
                if (!type.IsAbstract && typeof(RingFlavour).IsAssignableFrom(type))
                {
                    RingFlavour baseRingFlavour = (RingFlavour)Activator.CreateInstance(type);
                    BaseRingFlavours.Add(baseRingFlavour);
                }

                // Load RodFlavours.
                if (!type.IsAbstract && typeof(RodFlavour).IsAssignableFrom(type))
                {
                    RodFlavour baseRodFlavour = (RodFlavour)Activator.CreateInstance(type);
                    BaseRodFlavours.Add(baseRodFlavour);
                }

                // Load ScrollFlavours.
                if (!type.IsAbstract && typeof(BaseScrollFlavour).IsAssignableFrom(type))
                {
                    BaseScrollFlavour baseScrollFlavour = (BaseScrollFlavour)Activator.CreateInstance(type);
                    BaseScrollFlavours.Add(baseScrollFlavour);
                }

                // Load StaffFlavours.
                if (!type.IsAbstract && typeof(StaffFlavour).IsAssignableFrom(type))
                {
                    StaffFlavour baseStaffFlavour = (StaffFlavour)Activator.CreateInstance(type);
                    BaseStaffFlavours.Add(baseStaffFlavour);
                }

                // Load WandFlavours.
                if (!type.IsAbstract && typeof(WandFlavour).IsAssignableFrom(type))
                {
                    WandFlavour wandFlavour = (WandFlavour)Activator.CreateInstance(type);
                    BaseWandFlavours.Add(wandFlavour);
                }

                // Load ProjectileGraphics.
                if (!type.IsAbstract && typeof(ProjectileGraphic).IsAssignableFrom(type))
                {
                    ProjectileGraphic projectileGraphic = (ProjectileGraphic)Activator.CreateInstance(type);
                    BaseProjectileGraphics.Add(projectileGraphic.Name, projectileGraphic);
                }

                // Load Animations.
                if (!type.IsAbstract && typeof(Animation).IsAssignableFrom(type))
                {
                    Animation animation = (Animation)Activator.CreateInstance(type);
                    BaseAnimations.Add(animation.Name, animation);
                }

                // Load Vault Types.
                if (!type.IsAbstract && typeof(Vault).IsAssignableFrom(type))
                {
                    Vault vaultType = (Vault)Activator.CreateInstance(type);
                    Base2VaultTypes.Add(vaultType.Name, vaultType);
                }

                // Load Floor Tile Type.
                if (!type.IsAbstract && typeof(FloorTileType).IsAssignableFrom(type))
                {
                    FloorTileType floorTileType = (FloorTileType)Activator.CreateInstance(type);
                    BaseFloorTileTypes.Add(floorTileType.Name, floorTileType);
                }

                // Load Rare Item Type.
                if (!type.IsAbstract && typeof(Base2RareItemType).IsAssignableFrom(type))
                {
                    Base2RareItemType rareItemType = (Base2RareItemType)Activator.CreateInstance(type);
                    Base2RareItemTypes.Add(rareItemType.Name, rareItemType);
                }

                // Load Fixed Artifacts.
                if (!type.IsAbstract && typeof(Base2FixedArtifact).IsAssignableFrom(type))
                {
                    Base2FixedArtifact fixedArtifact = (Base2FixedArtifact)Activator.CreateInstance(type);
                    Base2FixedArtifacts.Add(fixedArtifact.Name, fixedArtifact);
                }
            }
        }
    }
}
