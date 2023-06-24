// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class DestroyScript : Script
    {
        private DestroyScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            int amount = 1;
            bool force = SaveGame.CommandArgument > 0;
            // Get an item to destroy
            if (!SaveGame.SelectItem(out Item? item, "Destroy which item? ", false, true, true, null))
            {
                SaveGame.MsgPrint("You have nothing to destroy.");
                return false;
            }
            if (item == null)
            {
                return false;
            }
            // If we have more than one we might not want to destroy all of them
            if (item.Count > 1)
            {
                amount = SaveGame.GetQuantity(null, item.Count, true);
                if (amount <= 0)
                {
                    return false;
                }
            }
            int oldNumber = item.Count;
            item.Count = amount;
            string itemName = item.Description(true, 3);
            item.Count = oldNumber;
            //Only confirm if it's not a worthless item
            if (!force)
            {
                if (!item.Stompable())
                {
                    string outVal = $"Really destroy {itemName}? ";
                    if (!SaveGame.GetCheck(outVal))
                    {
                        return false;
                    }
                    // If it was something we might want to destroy again, ask
                    if (!item.Factory.HasQuality && item.Factory.CategoryEnum != ItemTypeEnum.Chest)
                    {
                        if (item.IsKnown())
                        {
                            if (SaveGame.GetCheck($"Always destroy {itemName}?"))
                            {
                                item.Factory.Stompable[0] = true;
                            }
                        }
                    }
                }
            }
            // Destroying something takes a turn
            SaveGame.EnergyUse = 100;

            // Can't destroy an artifact artifact
            if (item.FixedArtifact != null || !string.IsNullOrEmpty(item.RandartName))
            {
                string feel = "special";
                SaveGame.EnergyUse = 0;
                SaveGame.MsgPrint($"You cannot destroy {itemName}.");
                if (item.IsCursed() || item.IsBroken())
                {
                    feel = "terrible";
                }
                item.Inscription = feel;
                item.IdentSense = true;
                SaveGame.NoticeCombineFlaggedAction.Set();
                SaveGame.RedrawEquippyFlaggedAction.Set();
                return false;
            }
            SaveGame.MsgPrint($"You destroy {itemName}.");

            SaveGame.Player.BaseCharacterClass.ItemDestroyed(item, amount);

            // Tidy up the player's inventory
            item.ItemIncrease(-amount);
            item.ItemDescribe();
            item.ItemOptimize();
            return false;
        }
    }
}
