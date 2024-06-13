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

    protected readonly Game Game;
    public readonly StoreFactory StoreFactory;

    public Store(Game game, StoreFactory storeFactory)
    {
        Game = game;
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
    public Shopkeeper Owner { get; private set; }

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
            Game.Screen.PrintLine($" {storeCommand.KeyChar}) {storeCommand.Description}.", row, col);
        }
    }

    public void DisplayEntry(int itemIndex, char letter, int row)
    {
        int maxwid = StoreFactory.WidthOfDescriptionColumn;
        Item oPtr = StoreInventoryList[itemIndex];
        string outVal = $"{letter}) ";
        Game.Screen.PrintLine(outVal, row, 0);
        ColorEnum a = oPtr.Factory.FlavorColor;
        char c = oPtr.Factory.FlavorSymbol.Character;
        Game.Screen.Print(a, c.ToString(), row, 3);
        string oName = oPtr.GetFullDescription(true);

        if (maxwid < oName.Length)
        {
            oName = oName.Substring(0, maxwid);
        }
        Game.Screen.Print(oPtr.Factory.Color, oName, row, 5);
        int wgt = oPtr.Weight;
        outVal = $"{wgt / 10,3}.{wgt % 10}{(StoreFactory.RenderWeightUnitOfMeasurement ? " lb" : "")}";

        if (StoreFactory.ShowItemPricing)
        {
            Game.Screen.Print(outVal, row, 61);
            int x;
            if (oPtr.IdentFixed)
            {
                x = MarkupItem(oPtr);
                outVal = $"{x,9} F";
                Game.Screen.Print(outVal, row, 68);
            }
            else
            {
                x = MarkupItem(oPtr);
                x += x / 10;
                outVal = $"{x,9}  ";
                Game.Screen.Print(outVal, row, 68);
            }
        }
        else
        {
            Game.Screen.Print(outVal, row, 68);
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
            Game.Screen.PrintLine("-page up/down-", pageIndex + 6, 3);
            pageIndex++;
        }
        else if (pageDownAvailable)
        {
            Game.Screen.PrintLine("-page down-", pageIndex + 6, 3);
            pageIndex++;
        }
        else if (pageUpAvailable)
        {
            Game.Screen.PrintLine("-page up-", pageIndex + 6, 3);
            pageIndex++;
        }

        // For any additional inventory lines that remain, we need to clear the screen.
        while (pageIndex < StoreFactory.PageSize)
        {
            Game.Screen.PrintLine("", pageIndex + 6, 0);
            pageIndex++;
        }

        Game.Screen.Print(new string(' ', StoreInventoryList.Count.ToString().Length * 2 + 11), 5, 20);
        if (StoreInventoryList.Count > StoreFactory.PageSize)
        {
            Game.Screen.Print($"(Page {StoreTop / StoreFactory.PageSize + 1} of {StoreInventoryList.Count / StoreFactory.PageSize + 1})", 5, 20);
        }
    }

    private Shopkeeper GetRandomOwner()
    {
        return StoreFactory.Shopkeepers[Game.RandomLessThan(StoreFactory.Shopkeepers.Length)];
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
                level = level.Value + Game.RandomLessThan(level.Value);
                ItemFactory? itemFactory = Game.RandomItemType(level.Value, false, false);
                if (itemFactory == null)
                {
                    continue;
                }
                newItem = new Item(Game, itemFactory);
            }
            else
            {
                // Pick a random item fctory that will be used to create the item.
                ItemFactory itemFactory = InventoryFactories[Game.RandomLessThan(InventoryFactories.Length)];

                // Generate a level for the item.
                level = Game.RandomBetween(1, Constants.StoreObjLevel);

                // Create the item.
                newItem = new Item(Game, itemFactory);
            }

            // Apply magic to the item.
            newItem.EnchantItem(level.Value, false, false, false, false);
            newItem.BecomeKnown();
            newItem.IdentityIsStoreBought = true;

            // Chests cannot be created for stores.
            if (newItem.Factory.IsContainer)
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
        int what = Game.RandomLessThan(StoreInventoryList.Count);
        int num = StoreInventoryList[what].Count;
        if (Game.RandomLessThan(100) < 50)
        {
            num = (num + 1) / 2;
        }
        if (Game.RandomLessThan(100) < 50)
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
        char c = Game.CurrentCommand;
        bool matchingCommandFound = false;

        // Process commands
        foreach (StoreCommand command in Game.SingletonRepository.Get<StoreCommand>())
        {
            // TODO: The IF statement below can be converted into a dictionary with the applicable object 
            // attached for improved performance.
            if (command.KeyChar == c)
            {
                matchingCommandFound = true;

                // Ensure this command works in this store.
                if (command.IsEnabled(StoreFactory) && command.ExecuteScript != null)
                {
                    StoreCommandEvent storeCommandEvent = new(this);
                    command.ExecuteScript.ExecuteScriptStore(storeCommandEvent);

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
            Game.MsgPrint("That command does not work in this Store.");
        }
        else
        {
            Game.MsgPrint("That command does not work in stores.");
        }
    }

    private void DisplayStore()
    {
        Game.Screen.Clear();
        Game.SetBackground(BackgroundImageEnum.Normal);
        string ownerName = OwnerName;
        if (string.IsNullOrEmpty(ownerName))
        {
            Game.Screen.PrintLine(Title, 3, 30);
        }
        else
        {
            Game.Screen.Print(OwnerName, 3, 10);
            Game.Screen.PrintLine(Title, 3, 50);
        }

        if (StoreFactory.StoreMaintainsInventory)
        {
            Game.Screen.Print("Item Description", 5, 3);
            if (StoreFactory.ShowItemPricing)
            {
                Game.Screen.Print("Weight", 5, 60);
                Game.Screen.Print("Price", 5, 72);
            }
            else
            {
                Game.Screen.Print("Weight", 5, 70);
            }
        }
        Game.StorePrtGold();
        DisplayInventory();
    }

    public bool GetStock(out int comVal, string pmt, int i, int j)
    {
        char command;
        Game.MsgPrint(null);
        comVal = -1;
        string outVal = $"(Items {i.IndexToLetter()}-{j.IndexToLetter()}, ESC to exit) {pmt}";
        while (Game.GetCom(outVal, out command))
        {
            int k = char.IsLower(command) ? command.LetterToNumber() : -1;
            if (k >= i && k <= j)
            {
                comVal = k;
                break;
            }
        }
        Game.MsgClear();
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
            if (jPtr.CanAbsorb(oPtr))
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
        else if (Game.RandomLessThan(25) == 0)
        {
            discount = 25;
        }
        else if (Game.RandomLessThan(150) == 0)
        {
            discount = 50;
        }
        else if (Game.RandomLessThan(300) == 0)
        {
            discount = 75;
        }
        else if (Game.RandomLessThan(500) == 0)
        {
            discount = 90;
        }
        if (oPtr.IsRandomArtifact)
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
        factor += Game.AbilityScores[Ability.Charisma].ChaPriceAdjustment;
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
        factor += Game.AbilityScores[Ability.Charisma].ChaPriceAdjustment;
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
            Game.Screen.PrintLine("", 1, 0);
            int tmpCha = Game.AbilityScores[Ability.Charisma].Adjusted;
            Game.Screen.Clear(41);
            Game.Screen.PrintLine(" ESC) Exit from Building.", 42, 0);
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand1, 42, 31);
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand2, 43, 31);
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand3, 42, 56);
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand5, 43, 0); // This needs to be before #4 to not erase it.
            RenderAdvertisedCommand(StoreFactory.AdvertisedStoreCommand4, 43, 56);
            Game.Screen.Print("You may: ", 41, 0);
            Game.RequestCommand(true);
            ProcessCommand();
            Game.FullScreenOverlay = true;
            Game.NoticeStuff();
            Game.HandleStuff();
            const int itemIndex = InventorySlot.PackCount;
            Item? oPtr = Game.GetInventoryItem(itemIndex);
            if (oPtr != null)
            {
                if (GetType() != typeof(HomeStoreFactory))
                {
                    Game.MsgPrint("Your pack is so full that you flee the Stores...");
                    _leaveStore = true;
                }
                else if (!StoreCanAcceptMoreItems(oPtr))
                {
                    Game.MsgPrint("Your pack is so full that you flee your home...");
                    _leaveStore = true;
                }
                else
                {
                    Game.MsgPrint("Your pack overflows!");
                    Item qPtr = oPtr.Clone();
                    string oName = qPtr.GetFullDescription(true);
                    Game.MsgPrint($"You drop {oName} ({itemIndex.IndexToLabel()}).");
                    Game.InvenItemIncrease(itemIndex, -255);
                    Game.InvenItemDescribe(itemIndex);
                    Game.InvenItemOptimize(itemIndex);
                    Game.HandleStuff();
                    int itemPos = HomeCarry(qPtr);
                    if (itemPos >= 0)
                    {
                        StoreTop = itemPos / StoreFactory.PageSize * StoreFactory.PageSize;
                        DisplayInventory();
                    }
                }
            }
            if (tmpCha != Game.AbilityScores[Ability.Charisma].Adjusted)
            {
                DisplayInventory();
            }
        }
        Game.EnergyUse = 0;
        Game.FullScreenOverlay = false;
        Game.ViewingItemList = false;
        Game.MsgPrint(null); // TODO: This is a PrWipeRedrawAction
        Game.SetBackground(BackgroundImageEnum.Overhead);
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(PrExtraRedrawActionGroupSetFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(PrBasicRedrawActionGroupSetFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawEquippyFlaggedAction)).Set();
        Game.MainForm.Invalidate();
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
            string ownerName = Owner.Name;
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
        int oldRating = Game.TreasureRating;

        // First phase, is to delete some items from the store.  Get the number of inventory items and alter this count by the turnover rate.
        int desiredTurnOverInventoryCount = StoreInventoryList.Count;
        desiredTurnOverInventoryCount -= Game.DieRoll(StoreFactory.StoreTurnover);

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
        desiredFinalInventoryCount += Game.DieRoll(StoreFactory.StoreTurnover);

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
        Game.TreasureRating = oldRating;
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
            if (!oPtr.IsRandomArtifact)
            {
                oPtr.Discount = 50;
            }
            oPtr.IdentFixed = false;
            oPtr.Inscription = "on sale";
        }
    }
}