using AngbandOS.Commands;
using AngbandOS.Core.FixedArtifacts;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core
{
    [Serializable]
    /// <summary>
    /// Represents a repository for game singletons.
    /// </summary>
    internal class SingletonRepository
    {
        public SingletonFactory<ICommand> GameCommands;
        public SingletonFactory<ItemClass> ItemCategories;
        public SingletonFactory<BaseFixedArtifact> BaseFixedArtifacts;
        public SingletonDictionaryFactory<FixedArtifactId, FixedArtifact> FixedArtifacts;

        public void Initialize(SaveGame saveGame)
        {
            GameCommands = new SingletonFactory<ICommand>(saveGame);
            ItemCategories = new SingletonFactory<ItemClass>(saveGame);
            BaseFixedArtifacts = new SingletonFactory<BaseFixedArtifact>(saveGame);

            Dictionary<FixedArtifactId, FixedArtifact> dictionary = new Dictionary<FixedArtifactId, FixedArtifact>();
            foreach (BaseFixedArtifact baseFixedArtifact in BaseFixedArtifacts)
            {
                dictionary.Add(baseFixedArtifact.FixedArtifactID, new FixedArtifact(baseFixedArtifact));
            }
            FixedArtifacts = new SingletonDictionaryFactory<FixedArtifactId, FixedArtifact>(saveGame, dictionary);
        }
    }
}