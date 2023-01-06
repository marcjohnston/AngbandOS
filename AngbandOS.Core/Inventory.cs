using AngbandOS.Core.EventArgs;
using System;

namespace AngbandOS
{
    [Serializable]
    internal class Inventory // TODO: This is a container
    {
        private readonly Item[] _items;
        private int _invenCnt;
        private readonly SaveGame SaveGame;

        public Inventory(SaveGame saveGame)
        {
            SaveGame = saveGame;
            _items = new Item[InventorySlot.Total];
            for (int i = 0; i < InventorySlot.Total; i++)
            {
                _items[i] = new Item(SaveGame); // No ItemType here
            }
            _invenCnt = 0;
        }

        public Item this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public void CombinePack()
        {
            bool flag = false;
            for (int i = InventorySlot.PackCount; i > 0; i--)
            {
                Item oPtr = _items[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                for (int j = 0; j < i; j++)
                {
                    Item jPtr = _items[j];
                    if (jPtr.BaseItemCategory == null)
                    {
                        continue;
                    }
                    if (jPtr.CanAbsorb(oPtr))
                    {
                        flag = true;
                        jPtr.Absorb(oPtr);
                        _invenCnt--;
                        int k;
                        for (k = i; k < InventorySlot.PackCount; k++)
                        {
                            _items[k] = _items[k + 1];
                        }
                        _items[k] = new Item(SaveGame); // No ItemType here
                        break;
                    }
                }
            }
            if (flag)
            {
                SaveGame.MsgPrint("You combine some items in your pack.");
            }
        }

        public bool GetItemOkay(int i, IItemFilter? itemFilter)
        {
            if (i < 0 || i >= InventorySlot.Total)
            {
                return false;
            }
            return ItemMatchesFilter(_items[i], itemFilter);
        }

        public int InvenCarry(Item oPtr, bool final)
        {
            int j;
            int n = -1;
            Item jPtr;
            if (!final)
            {
                for (j = 0; j < InventorySlot.PackCount; j++)
                {
                    jPtr = _items[j];
                    if (jPtr.BaseItemCategory == null)
                    {
                        continue;
                    }
                    n = j;
                    if (oPtr.CanAbsorb(jPtr))
                    {
                        jPtr.Absorb(oPtr);
                        SaveGame.Player.WeightCarried += oPtr.Count * oPtr.Weight;
                        SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                        return j;
                    }
                }
            }
            if (_invenCnt > InventorySlot.PackCount)
            {
                return -1;
            }
            for (j = 0; j <= InventorySlot.PackCount; j++)
            {
                jPtr = _items[j];
                if (jPtr.BaseItemCategory == null)
                {
                    break;
                }
            }
            int i = j;
            if (!final && i < InventorySlot.PackCount)
            {
                int oValue = oPtr.Value();
                for (j = 0; j < InventorySlot.PackCount; j++)
                {
                    jPtr = _items[j];
                    if (jPtr.BaseItemCategory == null)
                    {
                        break;
                    }
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
                i = j;
                for (int k = n; k >= i; k--)
                {
                    _items[k + 1] = _items[k].Clone();
                }
                _items[i] = new Item(SaveGame); // No ItemType here
            }
            _items[i] = oPtr.Clone();
            oPtr = _items[i];
            oPtr.Y = 0;
            oPtr.X = 0;
            oPtr.NextInStack = 0;
            oPtr.HoldingMonsterIndex = 0;
            SaveGame.Player.WeightCarried += oPtr.Count * oPtr.Weight;
            _invenCnt++;
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            SaveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            return i;
        }

        public bool InvenCarryOkay(Item oPtr)
        {
            if (_invenCnt < InventorySlot.PackCount)
            {
                return true;
            }
            for (int j = 0; j < InventorySlot.PackCount; j++)
            {
                Item jPtr = _items[j];
                if (jPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (jPtr.CanAbsorb(oPtr))
                {
                    return true;
                }
            }
            return false;
        }

        public int InvenDamage(Func<Item, bool> testerFunc, int perc)
        {
            int k = 0;
            for (int i = 0; i < InventorySlot.PackCount; i++)
            {
                Item oPtr = _items[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.IsFixedArtifact() || !string.IsNullOrEmpty(oPtr.RandartName))
                {
                    continue;
                }
                if (testerFunc(oPtr))
                {
                    int j;
                    int amt;
                    for (amt = j = 0; j < oPtr.Count; ++j)
                    {
                        if (Program.Rng.RandomLessThan(100) < perc)
                        {
                            amt++;
                        }
                    }
                    if (amt != 0)
                    {
                        string oName = oPtr.Description(false, 3);
                        string y = oPtr.Count > 1
                            ? (amt == oPtr.Count ? "All of y" : (amt > 1 ? "Some of y" : "One of y"))
                            : "Y";
                        string w = amt > 1 ? "were" : "was";
                        SaveGame.MsgPrint($"{y}our {oName} ({i.IndexToLabel()}) {w} destroyed!");
                        if (oPtr.BaseItemCategory.CategoryEnum == ItemTypeEnum.Potion)
                        {
                            PotionItemClass potion = (PotionItemClass)oPtr.BaseItemCategory;
                            potion.Smash(SaveGame, 0, SaveGame.Player.MapY, SaveGame.Player.MapX);
                        }
                        InvenItemIncrease(i, -amt);
                        InvenItemOptimize(i);
                        k += amt;
                    }
                }
            }
            return k;
        }

        public void InvenDrop(int item, int amt)
        {
            Item oPtr = _items[item];
            if (amt <= 0)
            {
                return;
            }
            if (amt > oPtr.Count)
            {
                amt = oPtr.Count;
            }
            if (item >= InventorySlot.MeleeWeapon)
            {
                item = InvenTakeoff(item, amt);
                oPtr = _items[item];
            }
            Item qPtr = oPtr.Clone(amt);
            string oName = qPtr.Description(true, 3);
            SaveGame.MsgPrint($"You drop {oName} ({item.IndexToLabel()}).");
            SaveGame.Level.DropNear(qPtr, 0, SaveGame.Player.MapY, SaveGame.Player.MapX);
            InvenItemIncrease(item, -amt);
            InvenItemDescribe(item);
            InvenItemOptimize(item);
        }

        public void InvenItemDescribe(int item)
        {
            Item oPtr = _items[item];
            string oName = oPtr.Description(true, 3);
            SaveGame.MsgPrint($"You have {oName}.");
        }

        public void InvenItemIncrease(int item, int num)
        {
            Item oPtr = _items[item];
            num += oPtr.Count;
            if (num > 255)
            {
                num = 255;
            }
            else if (num < 0)
            {
                num = 0;
            }
            num -= oPtr.Count;
            if (num != 0)
            {
                oPtr.Count += num;
                SaveGame.Player.WeightCarried += num * oPtr.Weight;
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana);
                SaveGame.Player.NoticeFlags |= Constants.PnCombine;
            }
        }

        public void InvenItemOptimize(int item)
        {
            Item oPtr = _items[item];
            if (oPtr.BaseItemCategory == null)
            {
                return;
            }
            if (oPtr.Count > 0)
            {
                return;
            }
            if (item < InventorySlot.MeleeWeapon)
            {
                int i;
                _invenCnt--;
                for (i = item; i < InventorySlot.PackCount; i++)
                {
                    _items[i] = _items[i + 1];
                }
                _items[i] = new Item(SaveGame); // No ItemType here
            }
            else
            {
                _items[item] = new Item(SaveGame); // No ItemType here
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana);
            }
        }

        public int InvenTakeoff(int item, int amt)
        {
            string act;
            Item oPtr = _items[item];
            if (amt <= 0)
            {
                return -1;
            }
            if (amt > oPtr.Count)
            {
                amt = oPtr.Count;
            }
            Item qPtr = oPtr.Clone(amt);
            string oName = qPtr.Description(true, 3);
            if (item == InventorySlot.MeleeWeapon)
            {
                act = "You were wielding";
            }
            else if (item == InventorySlot.RangedWeapon)
            {
                act = "You were holding";
            }
            else if (item == InventorySlot.Lightsource)
            {
                act = "You were holding";
            }
            else
            {
                act = "You were wearing";
            }
            InvenItemIncrease(item, -amt);
            InvenItemOptimize(item);
            int slot = InvenCarry(qPtr, false);
            SaveGame.MsgPrint($"{act} {oName} ({slot.IndexToLabel()}).");
            return slot;
        }

        public bool ItemMatchesFilter(Item item, IItemFilter? itemFilter)
        {
            if (item.BaseItemCategory == null)
            {
                return false;
            }
            if (item.Category == ItemTypeEnum.Gold)
            {
                return false;
            }
            if (itemFilter != null)
            {
                if (!itemFilter.ItemMatches(item))
                {
                    return false;
                }
            }
            return true;
        }

        public int LabelToEquip(char c)
        {
            int i = (char.IsLower(c) ? c.LetterToNumber() : -1) + InventorySlot.MeleeWeapon;
            if (i < InventorySlot.MeleeWeapon || i >= InventorySlot.Total)
            {
                return -1;
            }
            if (_items[i].BaseItemCategory == null)
            {
                return -1;
            }
            return i;
        }

        public int LabelToInven(char c)
        {
            int i = char.IsLower(c) ? c.LetterToNumber() : -1;
            if (i < 0 || i > InventorySlot.PackCount)
            {
                return -1;
            }
            if (_items[i].BaseItemCategory == null)
            {
                return -1;
            }
            return i;
        }

        public void ReorderPack()
        {
            bool flag = false;
            for (int i = 0; i < InventorySlot.PackCount; i++)
            {
                if (i == InventorySlot.PackCount && _invenCnt == InventorySlot.PackCount)
                {
                    break;
                }
                Item oPtr = _items[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                int oValue = oPtr.Value();
                int j;
                for (j = 0; j < InventorySlot.PackCount; j++)
                {
                    Item jPtr = _items[j];
                    if (jPtr.BaseItemCategory == null)
                    {
                        break;
                    }
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
                Item qPtr = _items[i].Clone();
                for (int k = i; k > j; k--)
                {
                    _items[k] = _items[k - 1].Clone();
                }
                _items[j] = qPtr.Clone();
            }
            if (flag)
            {
                SaveGame.MsgPrint("You reorder some items in your pack.");
            }
        }

        public void ReportChargeUsageFromInventory(int item)
        {
            Item oPtr = _items[item];
            if (oPtr.Category != ItemTypeEnum.Staff && oPtr.Category != ItemTypeEnum.Wand)
            {
                return;
            }
            if (!oPtr.IsKnown())
            {
                return;
            }
            SaveGame.MsgPrint(oPtr.TypeSpecificValue != 1
                ? $"You have {oPtr.TypeSpecificValue} charges remaining."
                : $"You have {oPtr.TypeSpecificValue} charge remaining.");
        }

        public void ShowEquip(IItemFilter? itemFilter)
        {
            ShowInventoryOptions options = new ShowInventoryOptions()
            {
                ShowEmptySlotsAsNothing = true,
                ShowFlavourColumn = true,
                ShowUsageColumn = true
            };
            ShowInven(_inventorySlot => _inventorySlot.IsEquipment, itemFilter, options);
        }

        public void ShowInven(Func<BaseInventorySlot, bool> inventorySlotPredicate, IItemFilter? itemFilter, ShowInventoryOptions? options = null)
        {
            if (options == null)
            {
                options = new ShowInventoryOptions();
            }

            BaseInventorySlot[] inventorySlots = SaveGame.SingletonRepository.InventorySlots
                .Where(_inventorySlot => inventorySlotPredicate(_inventorySlot))
                .OrderBy(_inventorySlot => _inventorySlot.SortOrder)
                .ToArray();

            const string labels = "abcdefghijklmnopqrstuvwxyz";
            ConsoleTable consoleTable = new ConsoleTable("label", "flavour", "usage", "description", "weight");
            consoleTable.Column("flavour").IsVisible = options.ShowFlavourColumn;
            consoleTable.Column("usage").IsVisible = options.ShowFlavourColumn;
            consoleTable.Column("weight").Alignment = new ConsoleTopRightAlignment();
            foreach (BaseInventorySlot inventorySlot in inventorySlots)
            {
                bool slotIsEmpty = true;
                foreach (int index in inventorySlot.InventorySlots)
                {
                    Item oPtr = _items[index];
                    if (oPtr.BaseItemCategory != null && (itemFilter == null || itemFilter.ItemMatches(oPtr)))
                    {
                        ConsoleTableRow consoleRow = consoleTable.AddRow();
                        consoleRow["label"] = new ConsoleString(Colour.White, $"{index.IndexToLabel()})");

                        if (oPtr.BaseItemCategory != null)
                        {
                            // Apply flavour visuals
                            consoleRow["flavour"] = new ConsoleChar(oPtr.BaseItemCategory.FlavorColour, oPtr.BaseItemCategory.FlavorCharacter);
                        }
                        else
                        {
                            // There is no item.
                            consoleRow["flavour"] = new ConsoleChar(Colour.Background, ' ');
                        }
                        consoleRow["usage"] = new ConsoleString(Colour.White, $"{inventorySlot.MentionUse(index)}:");

                        Colour colour = oPtr.BaseItemCategory == null ? Colour.White : oPtr.BaseItemCategory.Colour;
                        consoleRow["description"] = new ConsoleString(colour, oPtr.Description(true, 3));

                        int wgt = oPtr.Weight * oPtr.Count;
                        consoleRow["weight"] = new ConsoleString(Colour.White, $"{wgt / 10}.{wgt % 10} lb");
                        slotIsEmpty = false;
                    }
                }
                if (options.ShowEmptySlotsAsNothing && slotIsEmpty)
                {
                    ConsoleTableRow consoleRow = consoleTable.AddRow();
                    consoleRow["label"] = new ConsoleString(Colour.White, $"{labels[consoleTable.Rows.Count() - 1]})");
                    consoleRow["usage"] = new ConsoleString(Colour.White, $"{inventorySlot.MentionUse(null)}:");
                    consoleRow["description"] = new ConsoleString(Colour.White, "(nothing)");
                    consoleRow["weight"] = new ConsoleString(Colour.White, $"0.0 lb");
                }
            }
            consoleTable.Print(SaveGame, new ConsoleWindow(0, 1, 79, 26), new ConsoleTopRightAlignment());
        }
    }
}