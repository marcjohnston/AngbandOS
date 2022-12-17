using AngbandOS.Commands;

namespace AngbandOS.Core
{
    /// <summary>
    /// Represents a repository for game singletons.
    /// </summary>
    internal class SingletonRepository
    {
        public SingletonFactory<ICommand> GameCommands = new SingletonFactory<ICommand>();
    }
}