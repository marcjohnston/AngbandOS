﻿namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class NoticeCombineFlaggedAction : FlaggedAction
    {
        public NoticeCombineFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            bool flag = false;
            for (int i = InventorySlot.PackCount; i > 0; i--)
            {
                Item oPtr = SaveGame.Player.Inventory[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                for (int j = 0; j < i; j++)
                {
                    Item jPtr = SaveGame.Player.Inventory[j];
                    if (jPtr.BaseItemCategory == null)
                    {
                        continue;
                    }
                    if (jPtr.CanAbsorb(oPtr))
                    {
                        flag = true;
                        jPtr.Absorb(oPtr);
                        SaveGame.Player._invenCnt--;
                        int k;
                        for (k = i; k < InventorySlot.PackCount; k++)
                        {
                            SaveGame.Player.Inventory[k] = SaveGame.Player.Inventory[k + 1];
                        }
                        SaveGame.Player.Inventory[k] = new Item(SaveGame); // No ItemType here
                        break;
                    }
                }
            }
            if (flag)
            {
                SaveGame.MsgPrint("You combine some items in your pack.");
            }
        }
    }
}