// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class Store
{
    private int _x;
    private int _y;

    protected readonly SaveGame SaveGame;
    public readonly StoreFactory StoreFactory;

    public Store(SaveGame saveGame, StoreFactory storeFactory)
    {
        SaveGame = saveGame;
        StoreFactory = storeFactory;

        StoreInventoryList.Clear();
        List<ItemFactory> table = new();
        if (StoreFactory.StoreStockManifests != null)
        {
            foreach (StoreStockManifest storeStockManifest in StoreFactory.StoreStockManifests)
            {
                for (int i = 0; i < storeStockManifest.Weight; i++)
                {
                    table.Add(storeStockManifest.ItemFactory);
                }
            }
        }
        InventoryFactories = table.ToArray();
    }

    /// <summary>
    /// The grid x coordinate of the store on the town level.
    /// </summary>
    public int X => _x;

    /// <summary>
    /// The grid y coordinate of the store on the town level.
    /// </summary>
    public int Y => _y;

    public readonly List<Item> StoreInventoryList = new List<Item>();

    /// <summary>
    /// Returns the ItemFactories that are used to generate new items for the store.  If the store doesn't create items, 
    /// </summary>
    private readonly ItemFactory[] InventoryFactories;

    private bool _leaveStore;
    public StoreOwner Owner { get; private set; }

    /// <summary>
    /// Represents the first item being displayed in a page of inventory items.
    /// </summary>
    public int StoreTop { get; private set; }

    public bool DoorsLocked() => StoreFactory.DoorsLocked();

    public void MoveInventoryToAnotherStore(Store newStore)
    {
        newStore.StoreInventoryList.Clear();
        newStore.StoreInventoryList.AddRange(StoreInventoryList);
        StoreInventoryList.Clear();
    }

    public void ScrollInventory(int count)
    {
        StoreTop += count;

        // Ensure the top doesn't go past the last item.
        if (StoreTop >= StoreInventoryList.Count)
        {
            StoreTop = StoreInventoryList.Count - 1;
        }

        // Ensure the top doesn't go below 0.
        if (StoreTop < 0)
        {
            StoreTop = 0;
        }

        DisplayInventory();
    }
    public void PageUp()
    {
        ScrollInventory(-StoreFactory.PageSize);
    }

    public void PageDown()
    {
        // Do not scroll down a page, if there are no more pages.
        if (StoreTop + StoreFactory.PageSize < StoreInventoryList.Count) 
        {
            ScrollInventory(StoreFactory.PageSize);
        }
    }

    public void ScrollDown()
    {
        ScrollInventory(1);
    }

    public void ScrollUp()
    {
        ScrollInventory(-1);
    }

    public void SetLocation(int x, int y)
    {
        _x = x;
        _y = y;
    }

    private void RenderAdvertisedCommand(StoreCommand? storeCommand, int row, int col)
    {
        if (storeCommand != null)
        {
            SaveGame.Screen.PrintLine($" {storeCommand.KeyChar}) {storeCommand.Description}.", row, col);
        }
    }

    public void DisplayEntry(int itemIndex, char letter, int row)
    {
        int maxwid = StoreFactory.WidthOfDescriptionColumn;
        Item oPtr = StoreInventoryList[itemIndex];
        string outVal = $"{letter}) ";
        SaveGame.Screen.PrintLine(outVal, row, 0);
        ColorEnum a = oPtr.Factory.FlavorColor;
        char c = oPtr.Factory.FlavorSymbol.Character;
        SaveGame.Screen.Print(a, c.ToString(), row, 3);
        string oName = StoreFactory.GetItemDescription(oPtr);
        if (maxwid < oName.Length)
        {
            oName = oName.Substring(0, maxwid);
        }
        SaveGame.Screen.Print(oPtr.Factory.Color, oName, row, 5);
        int wgt = oPtr.Weight;
        outVal = $"{wgt / 10,3}.{wgt % 10}{(StoreFactory.RenderWeightUnitOfMeasurement ? " lb" : "")}";

        if (StoreFactory.ShowItemPricing)
        {
            SaveGame.Screen.Print(outVal, row, 61);
            int x;
            if (oPtr.IdentFixed)
            {
                x = MarkupItem(oPtr);
                outVal = $"{x,9} F";
                SaveGame.Screen.Print(outVal, row, 68);
            }
            else
            {
                x = MarkupItem(oPtr);
                x += x / 10;
                outVal = $"{x,9}  ";
                SaveGame.Screen.Print(outVal, row, 68);
            }
        }
        else
        {
            SaveGame.Screen.Print(outVal, row, 68);
        }
    }

    public void ScrollToItem(int itemPos)
    {
        StoreTop = itemPos; // / StoreFactory.PageSize * StoreFactory.PageSize;
    }

    public void DisplayInventory()
    {
        int pageIndex = 0; // This is the index of the item in the page of results.  This pageIndex is converted to a letter (a-z) and is used to determine the render row on the screen.
        int itemIndex = StoreTop; // This is the index in the inventory of the item to render.
        while (itemIndex < StoreInventoryList.Count && pageIndex < StoreFactory.PageSize)
        {
            DisplayEntry(itemIndex, pageIndex.IndexToLetter(), pageIndex + 6);
            pageIndex++;
            itemIndex++;
        }

        bool pageDownAvailable = StoreTop + StoreFactory.PageSize < StoreInventoryList.Count;
        bool pageUpAvailable = StoreTop > 0;
        if (pageUpAvailable && pageDownAvailable)
        {
            SaveGame.Screen.PrintLine("-page up/down-", pageIndex + 6, 3);
            pageIndex++;
        }
        else if (pageDownAvailable)
        {
            SaveGame.Screen.PrintLine("-page down-", pageIndex + 6, 3);
            pageIndex++;
        }
        else if (pageUpAvailable)
        {
            SaveGame.Screen.PrintLine("-page up-", pageIndex + 6, 3);
            pageIndex++;
        }

        // For any additional inventory lines that remain, we need to clear the screen.
        while (pageIndex < StoreFactory.PageSize)
        {
            SaveGame.Screen.PrintLine("", pageIndex + 6, 0);
            pageIndex++;
        }

        SaveGame.Screen.Print(new string(' ', StoreInventoryList.Count.ToString().Length * 2 + 11), 5, 20);
        if (StoreInventoryList.Count > StoreFactory.PageSize)
        {
            SaveGame.Screen.Print($"(Page {StoreTop / StoreFactory.PageSize + 1} of {StoreInventoryList.Count / StoreFactory.PageSize + 1})", 5, 20);
        }
    }

    private StoreOwner GetRandomOwner()
    {
        return StoreFactory.StoreOwners[SaveGame.Rng.RandomLessThan(StoreFactory.StoreOwners.Length)];
    }

    private void StoreCreate()
    {
        if (StoreInventoryList.Count >= StoreFactory.MaxInventory)
        {
            return;
        }
        for (int tries = 0; tries < 4; tries++)
        {
            Item? newItem = null;

            // Allow the factory the option to create an item.  This allows the 
            int? level = StoreFactory.LevelForRandomItemCreation;
            if (level != null)
            {
                level = level.Value + SaveGame.Rng.RandomLessThan(level.Value);
                ItemFactory? itemFactory = SaveGame.RandomItemType(level.Value, false, false);
                if (itemFactory == null)
                {
                    continue;
                }
                newItem = itemFactory.CreateItem();
            }
            else
            {
                // Pick a random item fctory that will be used to create the item.
                ItemFactory itemFactory = InventoryFactories[SaveGame.Rng.RandomLessThan(InventoryFactories.Length)];

                // Generate a level for the item.
                level = SaveGame.Rng.RandomBetween(1, Constants.StoreObjLevel);

                // Create the item.
                newItem = itemFactory.CreateItem();
            }

                // Apply magic to the item.
            newItem.ApplyMagic(level.Value, false, false, false, this);
            newItem.BecomeKnown();
            newItem.IdentityIsStoreBought = true;

            // Chests cannot be created for stores.
            if (newItem.Category == ItemTypeEnum.Chest)
            {
                continue;
            }

            // Ensure the item meets the store minimum value.
            if (newItem.Value() < StoreFactory.MinimumItemValue)
            {
                continue;
            }

            // Success
            MassProduce(newItem);
            StoreCarry(newItem);
            break;
        }
    }

    private void StoreDelete()
    {
        int what = SaveGame.Rng.RandomLessThan(StoreInventoryList.Count);
        int num = StoreInventoryList[what].Count;
        if (SaveGame.Rng.RandomLessThan(100) < 50)
        {
            num = (num + 1) / 2;
        }
        if (SaveGame.Rng.RandomLessThan(100) < 50)
        {
            num = 1;
        }
        StoreItemIncrease(what, -num);
        StoreItemOptimize(what);
    }

    public void StoreItemIncrease(int item, int num)
    {
        Item oPtr = StoreInventoryList[item];
        int cnt = oPtr.Count + num;
        if (cnt > 255)
        {
            cnt = 255;
        }
        else if (cnt < 0)
        {
            cnt = 0;
        }
        num = cnt - oPtr.Count;
        oPtr.Count += num;
    }

    public void StoreItemOptimize(int item)
    {
        Item oPtr = StoreInventoryList[item];
        if (oPtr.Count > 0)
        {
            return;
        }
        StoreInventoryList.RemoveAt(item);
    }

    private void StoreObjectAbsorb(Item oPtr, Item jPtr)
    {
        int total = oPtr.Count + jPtr.Count;
        oPtr.Count = total > 99 ? 99 : total;
    }

    private void ProcessCommand()
    {
        char c = SaveGame.CurrentCommand;
        bool matchingCommandFound = false;

        // Process commands
        foreach (StoreCommand command in SaveGame.SingletonRepository.StoreCommands)
        {
            // TODO: The IF statement below can be converted into a dictionary with the applicable object 
            // attached for improved performance.
            if (command.KeyChar == c)
            {
                matchingCommandFound = true;

                // Ensure this command works in this store.
                if (command.IsEnabled(StoreFactory))
                {
                    StoreCommandEvent storeCommandEvent = new(this);
                    command.Execute(storeCommandEvent);

                    if (storeCommandEvent.RequiresRerendering)
                    {
                        DisplayStore();
                    }
                    _leaveStore = storeCommandEvent.LeaveStore;

                    return;
                }
            }
        }

        if (matchingCommandFound)
        {
            SaveGame.MsgPrint("That command does not work in this Store.");
        }
        else
        {
            SaveGame.MsgPrint("That command does not work in stores.");
        }
    }

    private void DisplayStore()
    {
        SaveGame.Screen.Clear();
        SaveGame.SetBackground(BackgroundImageEnum.Normal);
        string ownerName = OwnerName;
        if (string.IsNullOrEmpty(ownerName))
        {
            SaveGame.Screen.PrintLine(Title, 3, 30);
        }
        else
        {
            SaveGame.Screen.Print(OwnerName, 3, 10);
            SaveGame.Screen.PrintLine(Title, 3, 50);
        }

        if (StoreFactory.StoreMaintainsInventory)
        {
            SaveGame.Screen.Print("Item Description", 5, 3);
            if (StoreFactory.ShowItemPricing)
            {
                SaveGame.Screen.Print("Weight", 5, 60);
                SaveGame.Screen.Print("Price", 5, 72);
            }
            else
            {
                SaveGame.Screen.Print("Weight", 5, 70);
            }
        }
        SaveGame.StorePrtGold();
        DisplayInventory();
    }

    public bool GetStock(out int comVal, string pmt, int i, int j)
    {
        char command;
        SaveGame.MsgPrint(null);
        comVal = -1;
        string outVal = $"(Items {i.IndexToLetter()}-{j.IndexToLetter()}, ESC to exit) {pmt}";
        while (SaveGame.GetCom(outVal, out command))
        {
            int k = char.IsLower(command) ? command.LetterToNumber() : -1;
            if (k >= i && k <= j)
            {
                comVal = k;
                break;
            }
        }
        SaveGame.MsgClear();
        return command != '\x1b';
    }

    public int StoreCarry(Item oPtr)
    {
        int slot;
        Item jPtr;
        int value = oPtr.Value();
        if (value <= 0)
        {
            return -1;
        }
        if (StoreFactory.StoreIdentifiesItems)
        {
            oPtr.IdentMental = true;
            oPtr.Inscription = "";
        }
        for (slot = 0; slot < StoreInventoryList.Count; slot++)
        {
            jPtr = StoreInventoryList[slot];
            if (StoreFactory.StoreObjectSimilar(jPtr, oPtr))
            {
                StoreObjectAbsorb(jPtr, oPtr);
                return slot;
            }
        }
        if (StoreInventoryList.Count >= StoreFactory.MaxInventory)
        {
            return -1;
        }
        for (slot = 0; slot < StoreInventoryList.Count; slot++)
        {
            jPtr = StoreInventoryList[slot];
            int compareResult = oPtr.CompareTo(jPtr);
            if (compareResult < 0)
            {
                break;
            }
            else if (compareResult > 0)
            {
                continue;
            }
        }
        StoreInventoryList.Insert(slot, oPtr);
        return slot;
    }

    /// <summary>
    /// Items sold (not pawned) items
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public int HomeCarry(Item oPtr)
    {
        int slot;
        Item jPtr;
        for (slot = 0; slot < StoreInventoryList.Count; slot++)
        {
            jPtr = StoreInventoryList[slot];
            if (jPtr.CanAbsorb(oPtr))
            {
                jPtr.Absorb(oPtr);
                return slot;
            }
        }
        if (StoreInventoryList.Count >= StoreFactory.MaxInventory)
        {
            return -1;
        }
        int value = oPtr.Value();
        for (slot = 0; slot < StoreInventoryList.Count; slot++)
        {
            jPtr = StoreInventoryList[slot];
            int compareResult = oPtr.CompareTo(jPtr);
            if (compareResult < 0)
            {
                break;
            }
            else if (compareResult > 0)
            {
                continue;
            }
        }
        StoreInventoryList.Insert(slot, oPtr.Clone()); // Clone is different
        return slot;
    }

    private void MassProduce(Item oPtr)
    {
        int size = 1;
        int discount = 0;
        int cost = oPtr.Value();
        size += oPtr.Factory.GetAdditionalMassProduceCount(oPtr);
        if (cost < 5)
        {
            discount = 0;
        }
        else if (SaveGame.Rng.RandomLessThan(25) == 0)
        {
            discount = 25;
        }
        else if (SaveGame.Rng.RandomLessThan(150) == 0)
        {
            discount = 50;
        }
        else if (SaveGame.Rng.RandomLessThan(300) == 0)
        {
            discount = 75;
        }
        else if (SaveGame.Rng.RandomLessThan(500) == 0)
        {
            discount = 90;
        }
        if (!string.IsNullOrEmpty(oPtr.RandartName))
        {
            discount = 0;
        }
        oPtr.Discount = discount;
        oPtr.Count = size - size * discount / 100;
    }

    /// <summary>
    /// Returns the price of an item that the store is selling/player is buying.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public int MarkupItem(Item oPtr)
    {
        int price = oPtr.Value();
        if (price <= 0)
        {
            return 0;
        }

        int greed = Owner.MinInflate;
        int adjust;

        // Create a charisma factor that affects the store owner.
        int factor = 100;
        factor += SaveGame.AbilityScores[Ability.Charisma].ChaPriceAdjustment;
        adjust = 100 + (greed + factor - 300);
        if (adjust < 100)
        {
            adjust = 100;
        }

        // Allow the store to adjust pricing.
        price = StoreFactory.MarkupItem(price);
        price = (price * adjust + 50) / 100;
        if (price <= 0)
        {
            return 1;
        }
        return price;
    }

    /// <summary>
    /// Returns the price of an item that the store is buying/the player is selling.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public int MarkdownItem(Item oPtr)
    {
        int price = oPtr.Value();
        if (price <= 0)
        {
            return 0;
        }

        int greed = Owner.MinInflate;
        int adjust;

        // Create a charisma factor that affects the store owner.
        int factor = 100;
        factor += SaveGame.AbilityScores[Ability.Charisma].ChaPriceAdjustment;
        adjust = 100 + (300 - (greed + factor));
        if (adjust > 100)
        {
            adjust = 100;
        }

        // Allow the store to adjust pricing.
        price = StoreFactory.MarkdownItem(price);
        price = (price * adjust + 50) / 100;
        if (price <= 0)
        {
            return 1;
        }
        return price;
    }

    public bool StoreCanAcceptMoreItems(Item oPtr)
    {
        int i;
        Item jPtr;
        if (StoreInventoryList.Count < StoreFactory.MaxInventory)
        {
            return true;
        }
        for (i = 0; i < StoreInventoryList.Count; i++)
        {
            jPtr = StoreInventoryList[i];
            if (jPtr.CanAbsorb(oPtr))
            {
                return true;
            }
        }
        return false;
    }

    public void EnterStore()
    {
        StoreTop = 0;
        DisplayStore();
        _leaveStore = false;
        while (!_leaveStore)
        {
            SaveGame.Screen.PrintLine("", 1, 0);
            int tmpCha = SaveGame.AbilityScores[Ability.Charisma].Adjusted;
            SaveGame.Screen.Clear(41);
            SaveGame.Screen.PrintLine(" ESC) Exit from Building.", 42, 0);
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand1, 42, 31);
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand2, 43, 31);
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand3, 42, 56);
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand5, 43, 0); // This needs to be before #4 to not erase it.
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand4, 43, 56);
            SaveGame.Screen.Print("You may: ", 41, 0);
            SaveGame.RequestCommand(true);
            ProcessCommand();
            SaveGame.FullScreenOverlay = true;
            SaveGame.NoticeStuff();
            SaveGame.HandleStuff();
            const int itemIndex = InventorySlot.PackCount;
            Item? oPtr = SaveGame.GetInventoryItem(itemIndex);
            if (oPtr != null)
            {
                if (GetType() != typeof(HomeStoreFactory))
                {
                    SaveGame.MsgPrint("Your pack is so full that you flee the Stores...");
                    _leaveStore = true;
                }
                else if (!StoreCanAcceptMoreItems(oPtr))
                {
                    SaveGame.MsgPrint("Your pack is so full that you flee your home...");
                    _leaveStore = true;
                }
                else
                {
                    SaveGame.MsgPrint("Your pack overflows!");
                    Item qPtr = oPtr.Clone();
                    string oName = qPtr.Description(true, 3);
                    SaveGame.MsgPrint($"You drop {oName} ({itemIndex.IndexToLabel()}).");
                    SaveGame.InvenItemIncrease(itemIndex, -255);
                    SaveGame.InvenItemDescribe(itemIndex);
                    SaveGame.InvenItemOptimize(itemIndex);
                    SaveGame.HandleStuff();
                    int itemPos = HomeCarry(qPtr);
                    if (itemPos >= 0)
                    {
                        StoreTop = itemPos / StoreFactory.PageSize * StoreFactory.PageSize;
                        DisplayInventory();
                    }
                }
            }
            if (tmpCha != SaveGame.AbilityScores[Ability.Charisma].Adjusted)
            {
                DisplayInventory();
            }
        }
        SaveGame.EnergyUse = 0;
        SaveGame.FullScreenOverlay = false;
        SaveGame.ViewingItemList = false;
        SaveGame.MsgPrint(null); // TODO: This is a PrWipeRedrawAction
        SaveGame.Screen.Clear();// TODO: This is a PrWipeRedrawAction
        SaveGame.SetBackground(BackgroundImageEnum.Overhead);
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(PrExtraRedrawActionGroupSetFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(PrBasicRedrawActionGroupSetFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawEquippyFlaggedAction)).Set();
    }

    /// <summary>
    /// Returns the title of the store.  By default, this name of the store and their maximum cost is returned.
    /// </summary>
    protected string Title
    {
        get
        {
            string? storeName = StoreFactory.Title;
            if (storeName == null)
            {
                storeName = StoreFactory.Tile.Description;
                storeName = $"{storeName} ({Owner.MaxCost})";
            }
            return storeName;
        }
    }

    /// <summary>
    /// Returns the name of the owner.  By default, the name of the owner and their race is returned.  If there is no owner race, just the owner name is returned.
    /// </summary>
    protected virtual string OwnerName
    {
        get
        {
            string ownerName = Owner.OwnerName;
            if (Owner.OwnerRace == null)
                return $"{ownerName}";
            else
                return $"{ownerName} ({Owner.OwnerRace.Title})";
        }
    }

    public void StoreInit()
    {
        Owner = GetRandomOwner();
        StoreInventoryList.Clear();
    }

    public void StoreMaint()
    {
        if (!StoreFactory.MaintainsStockLevels)
        {
            return;
        }

        // We need to preserve the treasure rating for the level because we will be creating items that will alter the treasure rating state.  We will restore
        // this treasure rating when we are done.
        int oldRating = SaveGame.TreasureRating;

        // First phase, is to delete some items from the store.  Get the number of inventory items and alter this count by the turnover rate.
        int desiredTurnOverInventoryCount = StoreInventoryList.Count;
        desiredTurnOverInventoryCount -= SaveGame.Rng.DieRoll(StoreFactory.StoreTurnover);

        // Ensure the count didn't go below zero.
        if (desiredTurnOverInventoryCount < 0)
        {
            desiredTurnOverInventoryCount = 0;
        }

        // Now delete the items that are being turned over.
        while (StoreInventoryList.Count > desiredTurnOverInventoryCount)
        {
            StoreDelete();
        }

        // Now add new items to the store to meet the store minimum and maximum counts.
        int desiredFinalInventoryCount = StoreInventoryList.Count;

        // Add a turnover rating to the count.
        desiredFinalInventoryCount += SaveGame.Rng.DieRoll(StoreFactory.StoreTurnover);

        // Ensure the new inventory level meets the store standards.
        if (desiredFinalInventoryCount > StoreFactory.MaxInventory)
        {
            desiredFinalInventoryCount = StoreFactory.MaxInventory;
        }
        if (desiredFinalInventoryCount < StoreFactory.MinInventory)
        {
            desiredFinalInventoryCount = StoreFactory.MinInventory;
        }
        if (desiredFinalInventoryCount >= StoreFactory.MaxInventory)
        {
            desiredFinalInventoryCount = StoreFactory.MaxInventory - 1;
        }
        while (StoreInventoryList.Count < desiredFinalInventoryCount)
        {
            StoreCreate();
        }

        // Restore the level treasure rating.
        SaveGame.TreasureRating = oldRating;
    }

    public void StoreShuffle()
    {
        if (!StoreFactory.ShufflesOwnersAndPricing)
        {
            return;
        }
        Owner = GetRandomOwner();
        for (int i = 0; i < StoreInventoryList.Count; i++)
        {
            Item oPtr = StoreInventoryList[i];
            if (string.IsNullOrEmpty(oPtr.RandartName))
            {
                oPtr.Discount = 50;
            }
            oPtr.IdentFixed = false;
            oPtr.Inscription = "on sale";
        }
    }
}