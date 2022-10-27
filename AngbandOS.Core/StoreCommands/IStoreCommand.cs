namespace AngbandOS.Commands
{
    internal interface IStoreCommand
    {
        char Key { get; }
        bool IsEnabled(Store store);
        bool RequiresRerendering { get; }
        void Execute(SaveGame saveGame, Store store);
        string Description { get; }
    }
}
