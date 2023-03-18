namespace AngbandOS.Core.FlaggedActions
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
                Item? oPtr = SaveGame.GetInventoryItem(i);
                if (oPtr != null)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Item jPtr = SaveGame.GetInventoryItem(j);
                        if (jPtr != null)
                        {
                            if (jPtr.CanAbsorb(oPtr))
                            {
                                flag = true;
                                jPtr.Absorb(oPtr);
                                SaveGame._invenCnt--;
                                int k;
                                for (k = i; k < InventorySlot.PackCount; k++)
                                {
                                    SaveGame.SetInventoryItem(k, SaveGame.GetInventoryItem(k + 1));
                                }
                                SaveGame.SetInventoryItem(k, null);
                                break;
                            }
                        }
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
