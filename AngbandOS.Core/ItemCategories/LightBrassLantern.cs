namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightBrassLantern : LightSourceItemClass
    {
        private LightBrassLantern(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Brass Lantern";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 35;
        public override int Dd => 1;

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (item.TypeSpecificValue != 0)
            {
                item.TypeSpecificValue = Program.Rng.DieRoll(item.TypeSpecificValue);
            }
        }

        /// <summary>
        /// Returns an intensity of light provided by the lantern.  2, if the lantern has turns remaining, plus an additional 3
        /// if the lantern is an artifact.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        public override int CalcTorch(Item oPtr)
        {
            return base.CalcTorch(oPtr) + oPtr.TypeSpecificValue > 0 ? 2 : 0;
        }
        public override int Ds => 1;
        public override bool EasyKnow => true;
        public override string FriendlyName => "& Brass Lantern~";
        public override bool IgnoreFire => true;
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int Pval => 7500;
        public override int? SubCategory => 1;
        public override int Weight => 50;

        /// <summary>
        /// Refill a lamp
        /// </summary>
        /// <param name="itemIndex"> The inventory index of the fuel </param>
        public override void Refill(SaveGame saveGame, Item item)
        {
            // Get an item if we don't already have one
            if (!saveGame.GetItem(out int itemIndex, "Refill with which flask? ", false, true, true, new LanternFuelItemFilter()))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have no flasks of oil.");
                }
                return;
            }

            // Get the item from the inventory or from the floor.
            Item fuelSource = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];

            // Make sure our item is suitable fuel
            if (!saveGame.Player.ItemMatchesFilter(fuelSource, new LanternFuelItemFilter()))
            {
                saveGame.MsgPrint("You can't refill a lantern from that!");
                return;
            }
            // Refilling takes half a turn
            saveGame.EnergyUse = 50;

            // Add the fuel
            item.TypeSpecificValue += fuelSource.TypeSpecificValue;
            saveGame.MsgPrint("You fuel your lamp.");

            // Check for overfilling
            if (item.TypeSpecificValue >= Constants.FuelLamp)
            {
                item.TypeSpecificValue = Constants.FuelLamp;
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
    }
}
