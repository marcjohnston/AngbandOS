using AngbandOS.Core;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cthangband.Commands
{
    internal static class CommandManager
    {
        public static List<ICommand> GameCommands = new List<ICommand>();
        public static List<IStoreCommand> StoreCommands = new List<IStoreCommand>();
        public static List<WandFlavour> BaseWandFlavours = new List<WandFlavour>();

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
                if (!type.IsAbstract && typeof(WandFlavour).IsAssignableFrom(type))
                {
                    // Load the command.
                    WandFlavour wandFlavour = (WandFlavour)Activator.CreateInstance(type);
                    BaseWandFlavours.Add(wandFlavour);
                }
            }
        }
    }
}
