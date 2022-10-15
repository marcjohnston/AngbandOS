using AngbandOS.Core;
using AngbandOS.ItemCategories;
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
        public static List<BaseWandFlavour> BaseWandFlavours = new List<BaseWandFlavour>();
        public static Dictionary<string, BaseProjectileGraphic> BaseProjectileGraphics = new Dictionary<string, BaseProjectileGraphic>();

        static CommandManager()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Check to see if the type implements the IStoreCommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(IStoreCommand).IsAssignableFrom(type))
                {
                    // Load the command.
                    IStoreCommand command = (IStoreCommand)Activator.CreateInstance(type);
                    StoreCommands.Add(command);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(ICommand).IsAssignableFrom(type))
                {
                    // Load the command.
                    ICommand command = (ICommand)Activator.CreateInstance(type);
                    GameCommands.Add(command);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BaseAmuletFlavour).IsAssignableFrom(type))
                {
                    // Load the command.
                    BaseAmuletFlavour baseAmuletFlavour = (BaseAmuletFlavour)Activator.CreateInstance(type);
                    BaseAmuletFlavours.Add(baseAmuletFlavour);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BaseMushroomFlavour).IsAssignableFrom(type))
                {
                    // Load the command.
                    BaseMushroomFlavour baseMushroomFlavour = (BaseMushroomFlavour)Activator.CreateInstance(type);
                    BaseMushroomFlavours.Add(baseMushroomFlavour);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BasePotionFlavour).IsAssignableFrom(type))
                {
                    // Load the command.
                    BasePotionFlavour basePotionFlavour = (BasePotionFlavour)Activator.CreateInstance(type);
                    BasePotionFlavours.Add(basePotionFlavour);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BaseRingFlavour).IsAssignableFrom(type))
                {
                    // Load the command.
                    BaseRingFlavour baseRingFlavour = (BaseRingFlavour)Activator.CreateInstance(type);
                    BaseRingFlavours.Add(baseRingFlavour);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BaseRodFlavour).IsAssignableFrom(type))
                {
                    // Load the command.
                    BaseRodFlavour baseRodFlavour = (BaseRodFlavour)Activator.CreateInstance(type);
                    BaseRodFlavours.Add(baseRodFlavour);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BaseScrollFlavour).IsAssignableFrom(type))
                {
                    // Load the command.
                    BaseScrollFlavour baseScrollFlavour = (BaseScrollFlavour)Activator.CreateInstance(type);
                    BaseScrollFlavours.Add(baseScrollFlavour);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BaseStaffFlavour).IsAssignableFrom(type))
                {
                    // Load the command.
                    BaseStaffFlavour baseStaffFlavour = (BaseStaffFlavour)Activator.CreateInstance(type);
                    BaseStaffFlavours.Add(baseStaffFlavour);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BaseWandFlavour).IsAssignableFrom(type))
                {
                    // Load the command.
                    BaseWandFlavour wandFlavour = (BaseWandFlavour)Activator.CreateInstance(type);
                    BaseWandFlavours.Add(wandFlavour);
                }

                // Check to see if the type implements the ICommand interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BaseProjectileGraphic).IsAssignableFrom(type))
                {
                    // Load the command.
                    BaseProjectileGraphic projectileGraphic = (BaseProjectileGraphic)Activator.CreateInstance(type);
                    BaseProjectileGraphics.Add(projectileGraphic.Name, projectileGraphic);
                }
            }
        }
    }
}
