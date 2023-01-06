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
            int itemIndex = -999;

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

            //// Now choose a light source item.
            //Item? lightSource = chosenLightSourceInventorySlot.WeightedRandom.Choose();
            //if (lightSource == null)
            //{
            //    saveGame.MsgPrint("You are not wielding a light.");
            //}

            Item lightSource = saveGame.Player.Inventory[i.Value];
            if (lightSource.BaseItemCategory == null)
            {
                saveGame.MsgPrint("You are not wielding a light.");
                return;
            }
            else if (lightSource.ItemSubCategory == LightType.Lantern)
            {
                RefillLamp(itemIndex, saveGame);
            }
            else if (lightSource.ItemSubCategory == LightType.Torch)
            {
                RefillTorch(itemIndex, saveGame);
            }
            else
            {
                saveGame.MsgPrint("Your light cannot be refilled.");
            }
        }

        /// <summary>
        /// Refill a lamp
        /// </summary>
        /// <param name="itemIndex"> The inventory index of the fuel </param>
        private void RefillLamp(int itemIndex, SaveGame saveGame)
        {
            // Get an item if we don't already have one
            if (itemIndex == -999)
            {
                if (!saveGame.GetItem(out itemIndex, "Refill with which flask? ", true, true, true, new LanternFuelItemFilter()))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have no flasks of oil.");
                    }
                    return;
                }
            }
            Item fuelSource = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Make sure our item is suitable fuel
            if (!saveGame.Player.ItemMatchesFilter(fuelSource, new LanternFuelItemFilter()))
            {
                saveGame.MsgPrint("You can't refill a lantern from that!");
                return;
            }
            // Refilling takes half a turn
            saveGame.EnergyUse = 50;
            Item lamp = saveGame.Player.Inventory[InventorySlot.Lightsource];
            // Add the fuel
            lamp.TypeSpecificValue += fuelSource.TypeSpecificValue;
            saveGame.MsgPrint("You fuel your lamp.");
            // Check for overfilling
            if (lamp.TypeSpecificValue >= Constants.FuelLamp)
            {
                lamp.TypeSpecificValue = Constants.FuelLamp;
                saveGame.MsgPrint("Your lamp is full.");
            }
            // Update the inventory
            if (itemIndex >= 0)
            {
                saveGame.Player.InvenItemIncrease(itemIndex, -1);
                saveGame.Player.InvenItemDescribe(itemIndex);
                saveGame.Player.InvenItemOptimize(itemIndex);
            }
            else
            {
                saveGame.Level.FloorItemIncrease(0 - itemIndex, -1);
                saveGame.Level.FloorItemDescribe(0 - itemIndex);
                saveGame.Level.FloorItemOptimize(0 - itemIndex);
            }
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
        }

        /// <summary>
        /// Refill a torch from another torch
        /// </summary>
        /// <param name="itemIndex"> The inventory index of the fuel </param>
        private void RefillTorch(int itemIndex, SaveGame saveGame)
        {
            // Get an item if we don't already have one
            if (itemIndex == -999)
            {
                if (!saveGame.GetItem(out itemIndex, "Refuel with which torch? ", false, true, true, new TorchFuelItemFilter()))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have no extra torches.");
                    }
                    return;
                }
            }
            Item fuelSource = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Check that our fuel is suitable
            if (!saveGame.Player.ItemMatchesFilter(fuelSource, new TorchFuelItemFilter()))
            {
                saveGame.MsgPrint("You can't refill a torch with that!");
                return;
            }
            // Refueling takes half a turn
            saveGame.EnergyUse = 50;
            Item torch = saveGame.Player.Inventory[InventorySlot.Lightsource];
            // Add the fuel
            torch.TypeSpecificValue += fuelSource.TypeSpecificValue + 5;
            saveGame.MsgPrint("You combine the torches.");
            // Check for overfilling
            if (torch.TypeSpecificValue >= Constants.FuelTorch)
            {
                torch.TypeSpecificValue = Constants.FuelTorch;
                saveGame.MsgPrint("Your torch is fully fueled.");
            }
            else
            {
                saveGame.MsgPrint("Your torch glows more brightly.");
            }
            // Update the player's inventory
            if (itemIndex >= 0)
            {
                saveGame.Player.InvenItemIncrease(itemIndex, -1);
                saveGame.Player.InvenItemDescribe(itemIndex);
                saveGame.Player.InvenItemOptimize(itemIndex);
            }
            else
            {
                saveGame.Level.FloorItemIncrease(0 - itemIndex, -1);
                saveGame.Level.FloorItemDescribe(0 - itemIndex);
                saveGame.Level.FloorItemOptimize(0 - itemIndex);
            }
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
        }
    }
}
