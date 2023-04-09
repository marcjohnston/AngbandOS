// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots
{
    [Serializable]
    internal abstract class EquipmentInventorySlot : BaseInventorySlot
    {
        protected EquipmentInventorySlot(SaveGame saveGame) : base(saveGame) { }

        /// <summary>
        /// Returns true.
        /// </summary>
        public override bool IsEquipment => true;

        public override bool IsInEquipment => true;

        /// Checks the quantity of an item and removes it, when the quanity is zero.
        /// </summary>
        /// <param name="oPtr"></param>
        public override void ItemOptimize(Item oPtr)
        {
            if (oPtr.Count > 0)
            {
                return;
            }
            int foundSlot = FindInventorySlot(oPtr);
            SaveGame.SetInventoryItem(foundSlot, null);
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.UpdateTorchRadiusFlaggedAction.Set();
            SaveGame.UpdateManaFlaggedAction.Set();
        }

        /// <summary>
        /// Allows wielded equipment items to process world.  By default, initiates the hook for all items in the inventory slot to perform processing during the ProcessWorld event through
        /// the EquipmentProcessWorld method.
        /// </summary>
        public override void ProcessWorldHook(ProcessWorldEventArgs processWorldEventArgs)
        {
            base.ProcessWorldHook(processWorldEventArgs);

            // Allow the base functionality to process items.
            foreach (int index in InventorySlots)
            {
                Item? oPtr = SaveGame.GetInventoryItem(index);
                if (oPtr != null)
                {
                    oPtr.EquipmentProcessWorldHook();
                }
            }

            if (processWorldEventArgs.SaveGame.Player.Race.IsBurnedBySunlight) // TODO: This needs to use a hook.
            {
                foreach (int index in InventorySlots)
                {
                    Item? oPtr = processWorldEventArgs.SaveGame.GetInventoryItem(index);
                    if (oPtr != null && oPtr.BaseItemCategory.ProvidesSunlight && !processWorldEventArgs.SaveGame.Player.HasLightResistance)
                    {
                        string oName = oPtr.Description(false, 0);
                        processWorldEventArgs.SaveGame.MsgPrint($"The {oName} scorches your undead flesh!");
                        processWorldEventArgs.DisableRegeneration = true;
                        oName = oPtr.Description(true, 0);
                        string ouch = $"wielding {oName}";
                        if (processWorldEventArgs.SaveGame.Player.TimedInvulnerability.TurnsRemaining == 0)
                        {
                            processWorldEventArgs.SaveGame.Player.TakeHit(1, ouch);
                        }
                    }
                }
            }
        }
    }
}