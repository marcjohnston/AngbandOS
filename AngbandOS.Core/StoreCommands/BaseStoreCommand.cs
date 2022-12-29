namespace AngbandOS.Commands
{
    internal abstract class BaseStoreCommand
    {
        public abstract char Key { get; }
        public virtual bool IsEnabled(Store store) => true;
        public abstract void Execute(StoreCommandEvent storeCommandEvent);
        public abstract string Description { get; }
    }
}
