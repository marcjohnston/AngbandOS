namespace AngbandOS.Commands
{
    /// <summary>
    /// Refill a light source with fuel
    /// </summary>
    [Serializable]
    internal class RefillCommand : ICommand
    {
        private RefillCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'F';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            // Make sure we actually have a light source to refuel.           
            BaseInventorySlot? chosenLightSourceInventorySlot = saveGame.SingletonRepository.InventorySlots.WeightedRandom(inventorySlot => inventorySlot.ProvidesLight).Choose();

            // Check to ensure there is an inventory slot for light sources.
            if (chosenLightSourceInventorySlot == null)
            {
                saveGame.MsgPrint("You are not wielding a light.");
                return;
            }

            // Now choose a light source item.
            int? i = chosenLightSourceInventorySlot.WeightedRandom.Choose();
            if (i == null)
            {
                saveGame.MsgPrint("You are not wielding a light.");
                return;
            }

            Item lightSource = saveGame.Player.Inventory[i.Value];
            if (lightSource.BaseItemCategory == null)
            {
                saveGame.MsgPrint("You are not wielding a light.");
                return;
            }

            LightSourceItemClass lightSourceItem = (LightSourceItemClass)lightSource.BaseItemCategory;
            lightSourceItem.Refill(saveGame, lightSource);
        }
    }
}
