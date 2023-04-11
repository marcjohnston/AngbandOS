namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WoodenTorchLightSourceItemFactory : LightSourceItemFactory
    {
        private WoodenTorchLightSourceItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Wooden Torch";

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
        /// <summary>
        /// Refill a torch from another torch
        /// </summary>
        /// <param name="itemIndex"> The inventory index of the fuel </param>
        public override void Refill(SaveGame saveGame, Item item)
        {
            // Get an item if we don't already have one
            if (!saveGame.SelectItem(out Item? fuelSource, "Refuel with which torch? ", false, true, true, new TorchFuelItemFilter()))
            {
                saveGame.MsgPrint("You have no extra torches.");
                return;
            }
            if (fuelSource == null)
            {
                return;
            }

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
            fuelSource.ItemIncrease(-1);
            fuelSource.ItemDescribe();
            fuelSource.ItemOptimize();
            saveGame.UpdateTorchRadiusFlaggedAction.Set();
        }
        public override Item CreateItem() => new WoodenTorchLightSourceItem(SaveGame);
    }
}
