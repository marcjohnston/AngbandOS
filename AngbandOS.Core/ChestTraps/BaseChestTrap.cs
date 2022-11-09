namespace AngbandOS.Core.ChestTraps
{
    /// <summary>
    /// Represents a trap on a chest.  Can be layered with multiple traps.  The base class implements the layering.  Derived classes only
    /// need concern themselves with their own implementation and not sub-traps.
    /// </summary>
    internal abstract class BaseChestTrap
    {
        /// <summary>
        /// Returns the next trap in the chain.  Returns null, when there are no more traps.
        /// </summary>
        private BaseChestTrap? NextTrap { get; }

        /// <summary>
        /// Represents the activation method the derived chest trap classes must implement.
        /// </summary>
        /// <param name="saveGame"></param>
        protected abstract void Activate(ActivateChestTrapEventArgs eventArgs);

        /// <summary>
        /// Activate the trap and all sub-traps.  Non-overridable.
        /// </summary>
        /// <param name="saveGame"></param>
        public void Activate(SaveGame saveGame, int x, int y)
        {
            ActivateChestTrapEventArgs eventArgs = new ActivateChestTrapEventArgs(saveGame, x, y);
            Activate(eventArgs);

            if (eventArgs.DestroysContents)
            {

            }
            if (eventArgs.CancelRecursion)
            {

            }
        }

        public BaseChestTrap(BaseChestTrap? nextTrap)
        {
            NextTrap = nextTrap;
        }
    }
}
