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
        public static List<BaseAmuletFlavour> BaseAmuletFlavours = new List<BaseAmuletFlavour>();
        public static List<BaseMushroomFlavour> BaseMushroomFlavours = new List<BaseMushroomFlavour>();
        public static List<BasePotionFlavour> BasePotionFlavours = new List<BasePotionFlavour>();
        public static List<BaseRingFlavour> BaseRingFlavours = new List<BaseRingFlavour>();
        public static List<BaseRodFlavour> BaseRodFlavours = new List<BaseRodFlavour>();
        public static List<BaseScrollFlavour> BaseScrollFlavours = new List<BaseScrollFlavour>();
        public static List<BaseStaffFlavour> BaseStaffFlavours = new List<BaseStaffFlavour>();
        public static List<WandFlavour> BaseWandFlavours = new List<WandFlavour>();
        public static Dictionary<string, BaseProjectileGraphic> BaseProjectileGraphics = new Dictionary<string, BaseProjectileGraphic>();
        public static Dictionary<string, BaseAnimation> BaseAnimations = new Dictionary<string, BaseAnimation>();
        public static Dictionary<string, BaseVaultType> Base2VaultTypes = new Dictionary<string, BaseVaultType>();
        public static Dictionary<string, BaseFloorTileType> BaseFloorTileTypes = new Dictionary<string, BaseFloorTileType>();
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
                if (!type.IsAbstract && typeof(BaseAmuletFlavour).IsAssignableFrom(type))
                {
                    BaseAmuletFlavour baseAmuletFlavour = (BaseAmuletFlavour)Activator.CreateInstance(type);
                    BaseAmuletFlavours.Add(baseAmuletFlavour);
                }

                // Load MushroomFlavours.
                if (!type.IsAbstract && typeof(BaseMushroomFlavour).IsAssignableFrom(type))
                {
                    BaseMushroomFlavour baseMushroomFlavour = (BaseMushroomFlavour)Activator.CreateInstance(type);
                    BaseMushroomFlavours.Add(baseMushroomFlavour);
                }

                // Load PotionFlavours.
                if (!type.IsAbstract && typeof(BasePotionFlavour).IsAssignableFrom(type))
                {
                    BasePotionFlavour basePotionFlavour = (BasePotionFlavour)Activator.CreateInstance(type);
                    BasePotionFlavours.Add(basePotionFlavour);
                }

                // Load RingFlavours.
                if (!type.IsAbstract && typeof(BaseRingFlavour).IsAssignableFrom(type))
                {
                    BaseRingFlavour baseRingFlavour = (BaseRingFlavour)Activator.CreateInstance(type);
                    BaseRingFlavours.Add(baseRingFlavour);
                }

                // Load RodFlavours.
                if (!type.IsAbstract && typeof(BaseRodFlavour).IsAssignableFrom(type))
                {
                    BaseRodFlavour baseRodFlavour = (BaseRodFlavour)Activator.CreateInstance(type);
                    BaseRodFlavours.Add(baseRodFlavour);
                }

                // Load ScrollFlavours.
                if (!type.IsAbstract && typeof(BaseScrollFlavour).IsAssignableFrom(type))
                {
                    BaseScrollFlavour baseScrollFlavour = (BaseScrollFlavour)Activator.CreateInstance(type);
                    BaseScrollFlavours.Add(baseScrollFlavour);
                }

                // Load StaffFlavours.
                if (!type.IsAbstract && typeof(BaseStaffFlavour).IsAssignableFrom(type))
                {
                    BaseStaffFlavour baseStaffFlavour = (BaseStaffFlavour)Activator.CreateInstance(type);
                    BaseStaffFlavours.Add(baseStaffFlavour);
                }

                // Load WandFlavours.
                if (!type.IsAbstract && typeof(WandFlavour).IsAssignableFrom(type))
                {
                    WandFlavour wandFlavour = (WandFlavour)Activator.CreateInstance(type);
                    BaseWandFlavours.Add(wandFlavour);
                }

                // Load ProjectileGraphics.
                if (!type.IsAbstract && typeof(BaseProjectileGraphic).IsAssignableFrom(type))
                {
                    BaseProjectileGraphic projectileGraphic = (BaseProjectileGraphic)Activator.CreateInstance(type);
                    BaseProjectileGraphics.Add(projectileGraphic.Name, projectileGraphic);
                }

                // Load Animations.
                if (!type.IsAbstract && typeof(BaseAnimation).IsAssignableFrom(type))
                {
                    BaseAnimation animation = (BaseAnimation)Activator.CreateInstance(type);
                    BaseAnimations.Add(animation.Name, animation);
                }

                // Load Vault Types.
                if (!type.IsAbstract && typeof(BaseVaultType).IsAssignableFrom(type))
                {
                    BaseVaultType vaultType = (BaseVaultType)Activator.CreateInstance(type);
                    Base2VaultTypes.Add(vaultType.Name, vaultType);
                }

                // Load Floor Tile Type.
                if (!type.IsAbstract && typeof(BaseFloorTileType).IsAssignableFrom(type))
                {
                    BaseFloorTileType floorTileType = (BaseFloorTileType)Activator.CreateInstance(type);
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
