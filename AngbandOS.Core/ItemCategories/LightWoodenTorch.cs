namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightWoodenTorch : LightSourceItemClass
    {
        private LightWoodenTorch(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Wooden Torch";

        /// <summary>
        /// Returns an intensity of light provided by the torch.  1, if the torch has turns remaining, plus an optional 3
        /// if the torch is an artifact.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        public override int CalcTorch(Item oPtr)
        {
            return base.CalcTorch(oPtr) + oPtr.TypeSpecificValue > 0 ? 1 : 0;
        }
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 1;
        public override bool EasyKnow => true;
        public override string FriendlyName => "& Wooden Torch~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int Pval => 4000;
        public override int? SubCategory => 0;
        public override int Weight => 30;

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (item.TypeSpecificValue != 0)
            {
                item.TypeSpecificValue = Program.Rng.DieRoll(item.TypeSpecificValue);
            }
        }
        /// <summary>
        /// Refill a torch from another torch
        /// </summary>
        /// <param name="itemIndex"> The inventory index of the fuel </param>
        public override void Refill(SaveGame saveGame, Item item)
        {
            // Get an item if we don't already have one
            if (!saveGame.GetItem(out int itemIndex, "Refuel with which torch? ", false, true, true, new TorchFuelItemFilter()))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have no extra torches.");
                }
                return;
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

            // Add the fuel
            item.TypeSpecificValue += fuelSource.TypeSpecificValue + 5;
            saveGame.MsgPrint("You combine the torches.");

            // Check for overfilling
            if (item.TypeSpecificValue >= Constants.FuelTorch)
            {
                item.TypeSpecificValue = Constants.FuelTorch;
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
