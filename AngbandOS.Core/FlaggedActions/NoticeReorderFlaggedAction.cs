namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class NoticeReorderFlaggedAction : FlaggedAction
    {
        public NoticeReorderFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            bool flag = false;
            for (int i = 0; i < InventorySlot.PackCount; i++)
            {
                if (i == InventorySlot.PackCount && SaveGame.Player._invenCnt == InventorySlot.PackCount)
                {
                    break;
                }
                Item oPtr = SaveGame.Player.Inventory[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                int oValue = oPtr.Value();
                int j;
                for (j = 0; j < InventorySlot.PackCount; j++)
                {
                    Item jPtr = SaveGame.Player.Inventory[j];
                    if (jPtr.BaseItemCategory == null)
                    {
                        break;
                    }
                    if (oPtr.BaseItemCategory.SpellBookToToRealm)
                    if (oPtr.BaseItemCategory.SpellBookToToRealm == SaveGame.Player.Realm1 && jPtr.BaseItemCategory.SpellBookToToRealm != SaveGame.Player.Realm1)
                    {
                        break;
                    }
                    if (jPtr.BaseItemCategory.SpellBookToToRealm == SaveGame.Player.Realm1 && oPtr.BaseItemCategory.SpellBookToToRealm != SaveGame.Player.Realm1)
                    {
                        continue;
                    }
                    if (oPtr.BaseItemCategory.SpellBookToToRealm == SaveGame.Player.Realm2 && jPtr.BaseItemCategory.SpellBookToToRealm != SaveGame.Player.Realm2)
                    {
                        break;
                    }
                    if (jPtr.BaseItemCategory.SpellBookToToRealm == SaveGame.Player.Realm2 && oPtr.BaseItemCategory.SpellBookToToRealm != SaveGame.Player.Realm2)
                    {
                        continue;
                    }
                    if (oPtr.Category > jPtr.Category)
                    {
                        break;
                    }
                    if (oPtr.Category < jPtr.Category)
                    {
                        continue;
                    }
                    if (!oPtr.IsFlavourAware())
                    {
                        continue;
                    }
                    if (!jPtr.IsFlavourAware())
                    {
                        break;
                    }
                    if (oPtr.ItemSubCategory < jPtr.ItemSubCategory)
                    {
                        break;
                    }
                    if (oPtr.ItemSubCategory > jPtr.ItemSubCategory)
                    {
                        continue;
                    }
                    if (!oPtr.IsKnown())
                    {
                        continue;
                    }
                    if (!jPtr.IsKnown())
                    {
                        break;
                    }
                    if (oPtr.Category == ItemTypeEnum.Rod)
                    {
                        if (oPtr.TypeSpecificValue < jPtr.TypeSpecificValue)
                        {
                            break;
                        }
                        if (oPtr.TypeSpecificValue > jPtr.TypeSpecificValue)
                        {
                            continue;
                        }
                    }
                    int jValue = jPtr.Value();
                    if (oValue > jValue)
                    {
                        break;
                    }
                    if (oValue < jValue)
                    {
                    }
                }
                if (j >= i)
                {
                    continue;
                }
                flag = true;
                Item qPtr = SaveGame.Player.Inventory[i].Clone();
                for (int k = i; k > j; k--)
                {
                    SaveGame.Player.Inventory[k] = SaveGame.Player.Inventory[k - 1].Clone();
                }
                SaveGame.Player.Inventory[j] = qPtr.Clone();
            }
            if (flag)
            {
                SaveGame.MsgPrint("You reorder some items in your pack.");
            }
        }
    }
}
