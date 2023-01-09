namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateTorchRadiusFlaggedAction : FlaggedAction
    {
        private int OldLightLevel;
        public UpdateTorchRadiusFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        /// <summary>
        /// Compute the level of light.  The player may be wielding multiple sources of light.
        /// </summary>
        protected override void Execute()
        {
            SaveGame.Player.LightLevel = 0;
            foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots.Where(_inventorySlot => _inventorySlot.IsEquipment))
            {
                foreach (int i in inventorySlot.InventorySlots)
                {
                    Item oPtr = SaveGame.Player.Inventory[i];
                    if (oPtr.BaseItemCategory != null)
                    {
                        SaveGame.Player.LightLevel += oPtr.BaseItemCategory.CalcTorch(oPtr);
                    }
                }
            }
            if (SaveGame.Player.LightLevel > 5)
            {
                SaveGame.Player.LightLevel = 5;
            }
            if (SaveGame.Player.LightLevel == 0 && SaveGame.Player.HasGlow)
            {
                SaveGame.Player.LightLevel = 1;
            }
            if (OldLightLevel != SaveGame.Player.LightLevel)
            {
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateLight);
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
                OldLightLevel = SaveGame.Player.LightLevel;
            }
        }
    }
}