// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores
{
    [Serializable]
    internal abstract class Store : IItemFilter
    {
        private int _x;
        private int _y;

        protected readonly SaveGame SaveGame;

        public abstract StoreType StoreType { get; }

        public virtual int PageSize => 26;

        /// <summary>
        /// The grid x coordinate of the store on the town level.
        /// </summary>
        public int X => _x;

        /// <summary>
        /// The grid y coordinate of the store on the town level.
        /// </summary>
        public int Y => _y;

        private readonly List<Item> _inventory = new List<Item>();

        protected virtual int CarryItem(Item qPtr) => StoreCarry(qPtr);

        /// <summary>
        /// Returns true, if the store will accept items from the player (e.g. sell or drop).
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public abstract bool ItemMatches(Item item);

        /// <summary>
        /// Returns true, if the doors to the store are locked; false, if the store is open.  Returns false, by default.
        /// </summary>
        /// <param name="saveGame"></param>
        /// <returns></returns>
        public virtual bool DoorsLocked(SaveGame saveGame) => false;

        /// <summary>
        /// Returns the index of each ItemType in the ItemTypeArray that the store carries.  Multiple instances of the same item type allows the item to have a higher
        /// chance that it will be selected.  Each item in the table has a 1-in-count chance of being selected.
        /// </summary>
        private readonly int[]? _table = null;
        private bool _leaveStore;
        private StoreOwner _owner;

        /// <summary>
        /// Represents the first item being displayed in a page of inventory items.
        /// </summary>
        private int _storeTop;

        /// <summary>
        /// Returns the maximum number of items the store can accomodate.  Returns one pagesize (26), by default.
        /// </summary>
        public virtual int MaxInventory => PageSize; // Cthangband only supports 1 page of items 

        /// <summary>
        /// Returns whether or not the store should perform maintenance.  When true, which is by default, the store will automatically 
        /// maintain stock levels based on the MinKeep, MaxKeep and Turnover values.
        /// </summary>
        protected virtual bool MaintainsStockLevels => true;

        /// <summary>
        /// Returns the maximum number of items the store should maintain.  Applies only when MaintainsStockLevels returns true.
        /// </summary>
        public virtual int StoreMaxKeep => 18;

        /// <summary>
        /// Returns the minimum number of items the store should maintain.  Applies only when MaintainsStockLevels returns true.
        /// </summary>
        public virtual int StoreMinKeep => 6; 

        /// <summary>
        /// Returns the number of items the store should delete during maintenance.  Applies only when MaintainsStockLevels returns true.
        /// </summary>
        public virtual int StoreTurnover => 9;

        /// <summary>
        /// Returns an array of item types that the store carries.  Returns null, if the store does not carry items for sale.
        /// </summary>
        /// <returns></returns>
        protected abstract StockStoreInventoryItem[] GetStoreTable();

        protected virtual string FleeMessage => "Your pack is so full that you flee the Stores...";

        public abstract string FeatureType { get; }

        /// <summary>
        /// Returns whether or not the store should occasionally change the owner and put items on sale.  When true, which is by default, the store will
        /// automatically perform this shuffling.
        /// </summary>
        public virtual bool ShufflesOwnersAndPricing => true;

        /// <summary>
        /// Represents a pool of possible store owners for the store.
        /// </summary>
        protected abstract StoreOwner[] StoreOwners { get; }

        /// <summary>
        /// Returns the store command that should be advertised to the player @ position 42, 31.
        /// </summary>
        /// <remarks>
        /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
        /// won't affect game play.
        /// </remarks>
        protected virtual BaseStoreCommand AdvertisedStoreCommand1 => SaveGame.SingletonRepository.StoreCommands.Get<PurchaseStoreCommand>();

        /// <summary>
        /// Returns the store command that should be advertised to the player @ position 43, 31.
        /// </summary>
        /// <remarks>
        /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
        /// won't affect game play.
        /// </remarks>
        protected virtual BaseStoreCommand AdvertisedStoreCommand2 => SaveGame.SingletonRepository.StoreCommands.Get<SellStoreCommand>();

        /// <summary>
        /// Returns the store command that should be advertised to the player @ position 42, 56.
        /// </summary>
        /// <remarks>
        /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
        /// won't affect game play.
        /// </remarks>
        protected virtual BaseStoreCommand AdvertisedStoreCommand3 => SaveGame.SingletonRepository.StoreCommands.Get<ExamineStoreCommand>();

        /// <summary>
        /// Returns the store command that should be advertised to the player @ position 43, 56.
        /// </summary>
        /// <remarks>
        /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
        /// won't affect game play.
        /// </remarks>
        protected virtual BaseStoreCommand AdvertisedStoreCommand4 => null;

        /// <summary>
        /// Returns the store command that should be advertised to the player @ position 43, 0.
        /// </summary>
        /// <remarks>
        /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
        /// won't affect game play.
        /// </remarks>
        protected virtual BaseStoreCommand AdvertisedStoreCommand5 => null;

        /// <summary>
        /// Returns the width of the description column for rendering items in the store inventory.
        /// </summary>
        protected virtual int WidthOfDescriptionColumn => 58;

        /// <summary>
        /// Returns whether the weight column should render the lb. units of measurement.  The players home has sufficient space to render, but the other stores do not.
        /// </summary>
        protected virtual bool RenderWeightUnitOfMeasurement => false;

        public abstract char Character { get; }
        public abstract Colour Colour { get; }
        public virtual string Description => FeatureType;

        public StoreFloorTileType CreateFloorTileType() => new StoreFloorTileType(SaveGame, Character, Colour, FeatureType, FeatureType, Description);

        protected Store(SaveGame saveGame)
        {
            SaveGame = saveGame;

            _inventory.Clear();
            StockStoreInventoryItem[] master = GetStoreTable();
            if (master == null)
            {
                return;
            }
            List<int> table = new List<int>();
            for (int k = 0; k < master.Length; k++)
            {
                int kIdx = -1;
                for (int i = 0; i < SaveGame.SingletonRepository.ItemCategories.Count; i++)
                {
                    ItemClass itemType = SaveGame.SingletonRepository.ItemCategories[i];
                    if (itemType.GetType().IsAssignableFrom(master[k].ItemType))
                    {
                        kIdx = i;
                        break;
                    }
                }
                for (int i = 0; i < master[k].Weight; i++)
                {
                    table.Add(kIdx);
                }
            }
            _table = table.ToArray();
        }

        public void MoveInventoryToAnotherStore(Store newStore)
        {
            newStore._inventory.Clear();
            newStore._inventory.AddRange(_inventory);
            _inventory.Clear();
        }

        public void PageUp()
        {
            if (_storeTop > 0)
            {
                _storeTop = 0;
                DisplayInventory();
            }
        }

        public void PageDown()
        {
            if (_storeTop + PageSize < _inventory.Count)
            {
                _storeTop += PageSize;
                DisplayInventory();
            }
        }

        public void SetLocation(int x, int y)
        {
            _x = x;
            _y = y;
        }

        private void RenderAdvertisedCommand(BaseStoreCommand command, int row, int col)
        {
            if (command != null)
            {
                SaveGame.Screen.PrintLine($" {command.Key}) {command.Description}.", row, col);
            }
        }

        public virtual void EnterStore()
        {
            _storeTop = 0;
            DisplayStore();
            _leaveStore = false;
            while (!_leaveStore)
            {
                SaveGame.Screen.PrintLine("", 1, 0);
                int tmpCha = SaveGame.Player.AbilityScores[Ability.Charisma].Adjusted;
                SaveGame.Screen.Clear(41);
                SaveGame.Screen.PrintLine(" ESC) Exit from Building.", 42, 0);
                RenderAdvertisedCommand(AdvertisedStoreCommand1, 42, 31);
                RenderAdvertisedCommand(AdvertisedStoreCommand2, 43, 31);
                RenderAdvertisedCommand(AdvertisedStoreCommand3, 42, 56);
                RenderAdvertisedCommand(AdvertisedStoreCommand5, 43, 0); // This needs to be before #4 to not erase it.
                RenderAdvertisedCommand(AdvertisedStoreCommand4, 43, 56);
                SaveGame.Screen.Print("You may: ", 41, 0);
                SaveGame.RequestCommand(true);
                StoreProcessCommand();
                SaveGame.FullScreenOverlay = true;
                SaveGame.NoticeStuff();
                SaveGame.HandleStuff();
                if (SaveGame.Player.Inventory[InventorySlot.PackCount].BaseItemCategory != null)
                {
                    const int item = InventorySlot.PackCount;
                    Item oPtr = SaveGame.Player.Inventory[item];
                    if (StoreType != StoreType.StoreHome)
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
                        SaveGame.MsgPrint($"You drop {oName} ({item.IndexToLabel()}).");
                        SaveGame.Player.InvenItemIncrease(item, -255);
                        SaveGame.Player.InvenItemDescribe(item);
                        SaveGame.Player.InvenItemOptimize(item);
                        SaveGame.HandleStuff();
                        int itemPos = HomeCarry(qPtr);
                        if (itemPos >= 0)
                        {
                            _storeTop = itemPos / PageSize * PageSize;
                            DisplayInventory();
                        }
                    }
                }
                if (tmpCha != SaveGame.Player.AbilityScores[Ability.Charisma].Adjusted)
                {
                    DisplayInventory();
                }
            }
            SaveGame.EnergyUse = 0;
            SaveGame.FullScreenOverlay = false;
            SaveGame.QueuedCommand = '\0';
            SaveGame.ViewingItemList = false;
            SaveGame.MsgPrint(null); // TODO: This is a PrWipeRedrawAction
            SaveGame.Screen.Clear();// TODO: This is a PrWipeRedrawAction
            SaveGame.SetBackground(BackgroundImage.Overhead);
            SaveGame.UpdateLightFlaggedAction.Set();
            SaveGame.UpdateViewFlaggedAction.Set();
            SaveGame.UpdateMonstersFlaggedAction.Set();
            SaveGame.PrExtraRedrawAction.Set();
            SaveGame.PrBasicRedrawAction.Set();
            SaveGame.RedrawMapFlaggedAction.Set();
            SaveGame.RedrawEquippyFlaggedAction.Set();
        }

        public virtual void StoreInit()
        {
            _owner = GetRandomOwner();
            _inventory.Clear();
        }

        public virtual void StoreMaint()
        {
            int oldRating = 0;
            if (SaveGame.Level != null)
            {
                oldRating = SaveGame.Level.TreasureRating;
            }
            if (!MaintainsStockLevels)
            {
                return;
            }
            int j = _inventory.Count;
            j -= Program.Rng.DieRoll(StoreTurnover);
            if (j > StoreMaxKeep)
            {
                j = StoreMaxKeep;
            }
            if (j < StoreMinKeep)
            {
                j = StoreMinKeep;
            }
            if (j < 0)
            {
                j = 0;
            }
            while (_inventory.Count > j)
            {
                StoreDelete();
            }
            j = _inventory.Count;
            j += Program.Rng.DieRoll(StoreTurnover);
            if (j > StoreMaxKeep)
            {
                j = StoreMaxKeep;
            }
            if (j < StoreMinKeep)
            {
                j = StoreMinKeep;
            }
            if (j >= MaxInventory)
            {
                j = MaxInventory - 1;
            }
            while (_inventory.Count < j && _table != null && _table.Length > 0)
            {
                StoreCreate();
            }
            if (SaveGame.Level != null)
            {
                SaveGame.Level.TreasureRating = oldRating;
            }
        }

        private StoreOwner GetRandomOwner()
        {
            return StoreOwners[Program.Rng.RandomLessThan(StoreOwners.Length)];
        }

        public virtual void StoreShuffle()
        {
            if (!ShufflesOwnersAndPricing)
            {
                return;
            }
            _owner = GetRandomOwner();
            for (int i = 0; i < _inventory.Count; i++)
            {
                Item oPtr = _inventory[i];
                if (string.IsNullOrEmpty(oPtr.RandartName))
                {
                    oPtr.Discount = 50;
                }
                oPtr.IdentFixed = false;
                oPtr.Inscription = "on sale";
            }
        }

        /// <summary>
        /// Returns the description of an item that is rendered in the store inventory.  Pawn shops and the players home render different descriptions.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        protected virtual string GetItemDescription(Item oPtr)
        {
            return oPtr.StoreDescription(true, 3);
        }

        private void DisplayEntry(int pos)
        {
            string oName;
            int maxwid = WidthOfDescriptionColumn;
            Item oPtr = _inventory[pos];
            int i = pos % PageSize;
            string outVal = $"{i.IndexToLetter()}) ";
            SaveGame.Screen.PrintLine(outVal, i + 6, 0);
            Colour a = oPtr.BaseItemCategory.FlavorColour;
            char c = oPtr.BaseItemCategory.FlavorCharacter;
            SaveGame.Screen.Print(a, c.ToString(), i + 6, 3);
            oName = GetItemDescription(oPtr);
            if (maxwid < oName.Length)
            {
                oName = oName.Substring(0, maxwid);
            }
            SaveGame.Screen.Print(oPtr.BaseItemCategory.Colour, oName, i + 6, 5);
            int wgt = oPtr.Weight;
            outVal = $"{wgt / 10,3}.{wgt % 10}{(RenderWeightUnitOfMeasurement ? " lb" : "")}";
            SaveGame.Screen.Print(outVal, i + 6, 61);

            if (ShowInventoryDisplayType == StoreInventoryDisplayTypeEnum.InventoryWithPrice)
            {
                int x;
                if (oPtr.IdentFixed)
                {
                    x = PriceItem(oPtr, _owner.MinInflate, false);
                    outVal = $"{x,9} F";
                    SaveGame.Screen.Print(outVal, i + 6, 68);
                }
                else
                {
                    x = PriceItem(oPtr, _owner.MinInflate, false);
                    x += x / 10;
                    outVal = $"{x,9}  ";
                    SaveGame.Screen.Print(outVal, i + 6, 68);
                }
            }
        }

        private void DisplayInventory()
        {
            int k;
            for (k = 0; k < PageSize; k++)
            {
                if (_storeTop + k >= _inventory.Count)
                {
                    break;
                }
                DisplayEntry(_storeTop + k);
            }
            for (int i = k; i <= PageSize; i++)
            {
                SaveGame.Screen.PrintLine("", i + 6, 0);
            }
            SaveGame.Screen.Print(new String(' ', _inventory.Count.ToString().Length * 2 + 11), 5, 20);
            if (_storeTop + PageSize < _inventory.Count)
            {
                SaveGame.Screen.PrintLine("-more-", k + 6, 3);
            }
            if (_inventory.Count > PageSize)
            {
                SaveGame.Screen.Print($"(Page {(_storeTop / PageSize) + 1} of {(_inventory.Count / PageSize) + 1})", 5, 20);
            }
        }

        /// <summary>
        /// Returns the name of the owner.  By default, the name of the owner and their race is returned.  If there is no owner race, just the owner name is returned.
        /// </summary>
        protected virtual string OwnerName
        {
            get
            {
                string ownerName = _owner.OwnerName;
                if (_owner.OwnerRace == null)
                    return $"{ownerName}";
                else
                    return $"{ownerName} ({_owner.OwnerRace.Title})";
            }
        }

        /// <summary>
        /// Returns the title of the store.  By default, this name of the store and their maximum cost is returned.
        /// </summary>
        protected virtual string Title
        {
            get
            {
                string storeName = SaveGame.SingletonRepository.FloorTileTypes[FeatureType].Description;
                return $"{storeName} ({_owner.MaxCost})";
            }
        }

        /// <summary>
        /// Returns whether or not the store should show an item inventory.
        /// </summary>
        protected virtual StoreInventoryDisplayTypeEnum ShowInventoryDisplayType => StoreInventoryDisplayTypeEnum.InventoryWithPrice;

        private void DisplayStore()
        {
            SaveGame.Screen.Clear();
            SaveGame.SetBackground(BackgroundImage.Normal);
            string ownerName = OwnerName;
            if (String.IsNullOrEmpty(ownerName))
            {
                SaveGame.Screen.PrintLine(Title, 3, 30);
            }
            else
            {
                SaveGame.Screen.Print(OwnerName, 3, 10);
                SaveGame.Screen.PrintLine(Title, 3, 50);
            }

            if (ShowInventoryDisplayType != StoreInventoryDisplayTypeEnum.DoNotShowInventory)
            {
                SaveGame.Screen.Print("Item Description", 5, 3);
            }
            if (ShowInventoryDisplayType == StoreInventoryDisplayTypeEnum.InventoryWithPrice)
            {
                SaveGame.Screen.Print("Weight", 5, 60);
                SaveGame.Screen.Print("Price", 5, 72);
            }
            else if (ShowInventoryDisplayType == StoreInventoryDisplayTypeEnum.InventoryWithoutPrice)
            {
                SaveGame.Screen.Print("Weight", 5, 70);
            }
            StorePrtGold();
            DisplayInventory();
        }

        private void DoStoreBrowse(Item oPtr)
        {
            int num = 0;
            int[] spells = new int[64];
            int sval = oPtr.ItemSubCategory;
            for (int spell = 0; spell < 32; spell++)
            {
                if ((Constants.BookSpellFlags[sval] & (1u << spell)) != 0)
                {
                    spells[num++] = spell;
                }
            }
            ScreenBuffer savedScreen = SaveGame.Screen.Clone();
            BookItemClass book = (BookItemClass)oPtr.BaseItemCategory;
            SaveGame.Player.PrintSpells(spells, num, 1, 20, book.ToRealm);
            SaveGame.Screen.PrintLine("", 0, 0);
            SaveGame.Screen.Print("[Press any key to continue]", 0, 23);
            SaveGame.Inkey();
            SaveGame.Screen.Restore(savedScreen);
        }

        private Town GetEscortDestination(Dictionary<char, Town> towns)
        {
            ScreenBuffer savedScreen = SaveGame.Screen.Clone();
            try
            {
                var keys = towns.Keys.ToList();
                keys.Sort();
                string outVal = $"Destination town ({keys[0].ToString().ToLower()} to {keys[keys.Count - 1].ToString().ToLower()})? ";
                for (int i = 0; i < keys.Count; i++)
                {
                    SaveGame.Screen.Print(Colour.White, $" {keys[i].ToString().ToLower()}) {towns[keys[i]].Name}".PadRight(60), i + 1, 20);
                }
                SaveGame.Screen.Print(Colour.White, "".PadRight(60), keys.Count + 1, 20);
                while (SaveGame.GetCom(outVal, out char choice))
                {
                    choice = choice.ToString().ToUpper()[0];
                    foreach (var c in keys)
                    {
                        if (choice == c)
                        {
                            return towns[c];
                        }
                    }
                }
            }
            finally
            {
                SaveGame.Screen.Restore(savedScreen);
            }
            return null;
        }

        private GodName GetSacrificeTarget()
        {
            ScreenBuffer savedScreen = SaveGame.Screen.Clone();
            try
            {
                var deities = SaveGame.Player.Religion.GetAllDeities();
                var names = new List<string>();
                var keys = new List<char>();
                foreach (var deity in deities)
                {
                    names.Add(deity.LongName);
                    keys.Add(deity.LongName[0]);
                }
                names.Sort();
                keys.Sort();
                string outVal = $"Destination town ({keys[0].ToString().ToLower()} to {keys[keys.Count - 1].ToString().ToLower()})? ";
                for (int i = 0; i < keys.Count; i++)
                {
                    SaveGame.Screen.Print(Colour.White, $" {keys[i].ToString().ToLower()}) {names[i]}".PadRight(60), i + 1, 20);
                }
                SaveGame.Screen.Print(Colour.White, "".PadRight(60), keys.Count + 1, 20);
                while (SaveGame.GetCom(outVal, out char choice))
                {
                    choice = choice.ToString().ToUpper()[0];
                    foreach (var c in keys)
                    {
                        if (choice == c)
                        {
                            foreach (var deity in deities)
                            {
                                if (deity.ShortName.StartsWith(choice.ToString()))
                                {
                                    return deity.Name;
                                }
                            }
                            return GodName.None;
                        }
                    }
                }
                return GodName.None;

            }
            finally
            {
                SaveGame.Screen.Restore(savedScreen);
            }
        }

        private bool GetStock(out int comVal, string pmt, int i, int j)
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
            SaveGame.Screen.PrintLine("", 0, 0);
            return command != '\x1b';
        }

        private int StoreCarry(Item oPtr)
        {
            int slot;
            Item jPtr;
            int value = oPtr.Value();
            if (value <= 0)
            {
                return -1;
            }
            if (StoreIdentifiesItems)
            {
                oPtr.IdentMental = true;
                oPtr.Inscription = "";
            }
            for (slot = 0; slot < _inventory.Count; slot++)
            {
                jPtr = _inventory[slot];
                if (StoreObjectSimilar(jPtr, oPtr))
                {
                    StoreObjectAbsorb(jPtr, oPtr);
                    return slot;
                }
            }
            if (_inventory.Count >= MaxInventory)
            {
                return -1;
            }
            for (slot = 0; slot < _inventory.Count; slot++)
            {
                jPtr = _inventory[slot];
                if (oPtr.Category > jPtr.Category)
                {
                    break;
                }
                if (oPtr.Category < jPtr.Category)
                {
                    continue;
                }
                if (oPtr.ItemSubCategory < jPtr.ItemSubCategory)
                {
                    break;
                }
                if (oPtr.ItemSubCategory > jPtr.ItemSubCategory)
                {
                    continue;
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
                if (value > jValue)
                {
                    break;
                }
                if (value < jValue)
                {
                }
            }
            _inventory.Insert(slot, oPtr);
            return slot;
        }

        /// <summary>
        /// Items sold (not pawned) items
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        protected int HomeCarry(Item oPtr)
        {
            int slot;
            Item jPtr;
            for (slot = 0; slot < _inventory.Count; slot++)
            {
                jPtr = _inventory[slot];
                if (jPtr.CanAbsorb(oPtr))
                {
                    jPtr.Absorb(oPtr);
                    return slot;
                }
            }
            if (_inventory.Count >= MaxInventory)
            {
                return -1;
            }
            int value = oPtr.Value();
            for (slot = 0; slot < _inventory.Count; slot++)
            {
                jPtr = _inventory[slot];
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
                if (value > jValue)
                {
                    break;
                }
                if (value < jValue)
                {
                }
            }
            _inventory.Insert(slot, oPtr.Clone());
            return slot;
        }

        private void MassProduce(Item oPtr)
        {
            int size = 1;
            int discount = 0;
            int cost = oPtr.Value();
            size += oPtr.BaseItemCategory.GetAdditionalMassProduceCount(oPtr);
            if (cost < 5)
            {
                discount = 0;
            }
            else if (Program.Rng.RandomLessThan(25) == 0)
            {
                discount = 25;
            }
            else if (Program.Rng.RandomLessThan(150) == 0)
            {
                discount = 50;
            }
            else if (Program.Rng.RandomLessThan(300) == 0)
            {
                discount = 75;
            }
            else if (Program.Rng.RandomLessThan(500) == 0)
            {
                discount = 90;
            }
            if (!string.IsNullOrEmpty(oPtr.RandartName))
            {
                discount = 0;
            }
            oPtr.Discount = discount;
            oPtr.Count = size - (size * discount / 100);
        }

        protected virtual int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
        {
            return price;
        }

        private int PriceItem(Item oPtr, int greed, bool trueToMarkDownFalseToMarkUp)
        {
            int adjust;
            int price = oPtr.Value();
            if (price <= 0)
            {
                return 0;
            }
            int factor = 100;
            factor += SaveGame.Player.AbilityScores[Ability.Charisma].ChaPriceAdjustment;
            if (trueToMarkDownFalseToMarkUp == true)
            {
                adjust = 100 + (300 - (greed + factor));
                if (adjust > 100)
                {
                    adjust = 100;
                }
            }
            else
            {
                adjust = 100 + (greed + factor - 300);
                if (adjust < 100)
                {
                    adjust = 100;
                }
            }
            price = AdjustPrice(price, trueToMarkDownFalseToMarkUp);
            price = ((price * adjust) + 50) / 100;
            if (price <= 0)
            {
                return 1;
            }
            return price;
        }

        private void PurchaseAnalyze(int price, int value, int guess)
        {
            if (value <= 0 && price > value)
            {
                SaveGame.MsgPrint(new ShopKeeperWorthlessComments().Choose());
                SaveGame.PlaySound(SoundEffect.StoreSoldWorthless);
            }
            else if (value < guess && price > value)
            {
                SaveGame.MsgPrint(new ShopKeeperLessThanGuessComments().Choose());
                SaveGame.PlaySound(SoundEffect.StoreSoldBargain);
            }
            else if (value > guess && value < 4 * guess && price < value)
            {
                SaveGame.MsgPrint(new ShopKeeperGoodComments().Choose());
                SaveGame.PlaySound(SoundEffect.StoreSoldCheaply);
            }
            else if (value > guess && price < value)
            {
                SaveGame.MsgPrint(new ShopKeeperBargainComments().Choose());
                SaveGame.PlaySound(SoundEffect.StoreSoldExtraCheaply);
            }
        }

        private bool PurchaseHaggle(Item oPtr, out int price)
        {
            int finalAsk = PriceItem(oPtr, _owner.MinInflate, false);
            SaveGame.MsgPrint("You quickly agree upon the price.");
            SaveGame.MsgPrint(null);
            finalAsk += finalAsk / 10;
            const string pmt = "Final Offer";
            finalAsk *= oPtr.Count;
            price = finalAsk;
            string outVal = $"{pmt} :  {finalAsk}";
            SaveGame.Screen.Print(outVal, 1, 0);
            return !SaveGame.GetCheck("Accept deal? ");
        }

        protected virtual bool PerformsMaintenanceWhenResting => true;

        private void RoomRest(bool toDusk)
        {
            if (toDusk)
            {
                SaveGame.Player.GameTime.ToNextDusk();
                SaveGame.MsgPrint("You awake, ready for the night.");
                SaveGame.MsgPrint("You eat a tasty supper.");
            }
            else
            {
                SaveGame.Player.GameTime.ToNextDawn();
                SaveGame.MsgPrint("You awake refreshed for the new day.");
                SaveGame.MsgPrint("You eat a hearty breakfast.");
            }
            SaveGame.Player.Religion.DecayFavour();
            SaveGame.UpdateHealthFlaggedAction.Set();
            SaveGame.UpdateManaFlaggedAction.Set();
            SaveGame.Player.SetFood(Constants.PyFoodMax - 1);
            foreach (Town town in SaveGame.SingletonRepository.Towns)
            {
                foreach (Store store in town.Stores)
                {
                    if (PerformsMaintenanceWhenResting)
                    {
                        store.StoreMaint();
                    }
                }
            }
            SaveGame.Player.TimedHaste.SetValue();
            SaveGame.Player.TimedSlow.SetValue();
            SaveGame.Player.TimedBlindness.SetValue();
            SaveGame.Player.TimedParalysis.SetValue();
            SaveGame.Player.TimedConfusion.SetValue();
            SaveGame.Player.TimedFear.SetValue();
            SaveGame.Player.TimedHallucinations.SetValue();
            SaveGame.Player.TimedPoison.SetValue();
            SaveGame.Player.TimedBleeding.SetValue();
            SaveGame.Player.TimedStun.SetValue();
            SaveGame.Player.TimedProtectionFromEvil.SetValue();
            SaveGame.Player.TimedInvulnerability.SetValue();
            SaveGame.Player.TimedHeroism.SetValue();
            SaveGame.Player.TimedSuperheroism.SetValue();
            SaveGame.Player.TimedStoneskin.SetValue();
            SaveGame.Player.TimedBlessing.SetValue();
            SaveGame.Player.TimedSeeInvisibility.SetValue();
            SaveGame.Player.TimedEtherealness.SetValue();
            SaveGame.Player.TimedInfravision.SetValue();
            SaveGame.Player.TimedAcidResistance.SetValue();
            SaveGame.Player.TimedLightningResistance.SetValue();
            SaveGame.Player.TimedFireResistance.SetValue();
            SaveGame.Player.TimedColdResistance.SetValue();
            SaveGame.Player.TimedPoisonResistance.SetValue();
            SaveGame.Player.Health = SaveGame.Player.MaxHealth;
            SaveGame.Player.Mana = SaveGame.Player.MaxMana;
            SaveGame.Player.TimedBlindness.SetValue();
            SaveGame.Player.TimedConfusion.SetValue();
            SaveGame.Player.TimedStun.SetValue();
            SaveGame.NewLevelFlag = true;
            SaveGame.CameFrom = LevelStart.StartWalk;
        }

        public void SacrificeItem()
        {
            var godName = GetSacrificeTarget();
            if (godName == GodName.None)
            {
                return;
            }
            var deity = SaveGame.Player.Religion.GetNamedDeity(godName);
            string pmt = "Sacrifice which item? ";
            if (!SaveGame.GetItem(out int item, pmt, true, true, false, null))
            {
                if (item == -2)
                {
                    SaveGame.MsgPrint("You have nothing to sacrifice.");
                    return;
                }
            }
            Item oPtr = item >= 0 ? SaveGame.Player.Inventory[item] : SaveGame.Level.Items[0 - item];
            if (item >= InventorySlot.MeleeWeapon && oPtr.IsCursed())
            {
                SaveGame.MsgPrint("Hmmm, it seems to be cursed.");
                return;
            }
            int amt = 1;
            if (oPtr.Count > 1)
            {
                amt = SaveGame.GetQuantity(null, oPtr.Count, true);
                if (amt <= 0)
                {
                    return;
                }
            }
            Item qPtr = oPtr.Clone(amt);
            string oName = qPtr.Description(true, 3);
            qPtr.Inscription = "";
            int finalAsk = PriceItem(qPtr, _owner.MinInflate, true) * qPtr.Count;
            SaveGame.Player.InvenItemIncrease(item, -amt);
            SaveGame.Player.InvenItemDescribe(item);
            SaveGame.Player.InvenItemOptimize(item);
            SaveGame.HandleStuff();
            var deityName = deity.ShortName;
            if (finalAsk <= 0)
            {
                finalAsk = -100;
            }
            var favour = finalAsk / 10;
            var oldFavour = deity.AdjustedFavour;
            SaveGame.Player.Religion.AddFavour(godName, favour);
            var newFavour = deity.AdjustedFavour;
            var change = newFavour - oldFavour;
            if (change < 0)
            {
                SaveGame.MsgPrint($"{deityName} is displeased with your sacrifice!");
            }
            else if (change == 0)
            {
                SaveGame.MsgPrint($"{deityName} is indifferent to your sacrifice!");
            }
            else if (change == 1)
            {
                SaveGame.MsgPrint($"{deityName} approves of your sacrifice!");
            }
            else if (change == 2)
            {
                SaveGame.MsgPrint($"{deityName} likes your sacrifice!");
            }
            else if (change == 3)
            {
                SaveGame.MsgPrint($"{deityName} loves your sacrifice!");
            }
            else
            {
                SaveGame.MsgPrint($"{deityName} is delighted by your sacrifice!");
            }
            SaveGame.UpdateHealthFlaggedAction.Set();
            SaveGame.UpdateManaFlaggedAction.Set();
        }

        protected void SayComment_1()
        {
            SaveGame.MsgPrint(new StoreOwnerAcceptedComments().Choose());
        }

        private bool SellHaggle(Item oPtr, out int price)
        {
            int finalAsk = PriceItem(oPtr, _owner.MinInflate, true);
            int purse = _owner.MaxCost;
            if (finalAsk >= purse)
            {
                SaveGame.MsgPrint("You instantly agree upon the price.");
                SaveGame.MsgPrint(null);
                finalAsk = purse;
            }
            else
            {
                SaveGame.MsgPrint("You quickly agree upon the price.");
                SaveGame.MsgPrint(null);
                finalAsk -= finalAsk / 10;
            }
            const string pmt = "Final Offer";
            finalAsk *= oPtr.Count;
            price = finalAsk;
            string outVal = $"{pmt} :  {finalAsk}";
            SaveGame.Screen.Print(outVal, 1, 0);
            return !SaveGame.GetCheck("Accept deal? ");
        }

        protected bool ServiceHaggle(int serviceCost, out int price)
        {
            int finalAsk = serviceCost;
            SaveGame.MsgPrint("You quickly agree upon the price.");
            SaveGame.MsgPrint(null);
            finalAsk += finalAsk / 10;
            price = finalAsk;
            const string pmt = "Final Offer";
            string outVal = $"{pmt} :  {finalAsk}";
            SaveGame.Screen.Print(outVal, 1, 0);
            return !SaveGame.GetCheck("Accept deal? ");
        }

        protected virtual bool StoreCanMergeItem(Item oPtr, Item jPtr) => StoreObjectSimilar(jPtr, oPtr);

        private bool StoreCanAcceptMoreItems(Item oPtr)
        {
            int i;
            Item jPtr;
            if (_inventory.Count < MaxInventory)
            {
                return true;
            }
            for (i = 0; i < _inventory.Count; i++)
            {
                jPtr = _inventory[i];
                if (StoreCanMergeItem(oPtr, jPtr))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual Item CreateItem()
        {
            // Pick an item to create from the inventory.
            int i = _table[Program.Rng.RandomLessThan(_table.Length)];

            // Generate a level for the item.
            int level = Program.Rng.RandomBetween(1, Constants.StoreObjLevel);

            // Retrieve the item class.
            ItemClass itemType = SaveGame.SingletonRepository.ItemCategories[i];

            // Create the item.
            Item qPtr = itemType.CreateItem(SaveGame);

            // Apply magic to the item.
            qPtr.ApplyMagic(level, false, false, false);

            return qPtr;
        }

        protected virtual int MinimumItemValue => 0;

        private void StoreCreate()
        {
            if (_inventory.Count >= MaxInventory)
            {
                return;
            }
            for (int tries = 0; tries < 4; tries++)
            {
                Item qPtr = CreateItem();
                if (qPtr == null)
                {
                    continue;
                }

                if (qPtr.Category == ItemTypeEnum.Light)
                {
                    if (qPtr.ItemSubCategory == LightType.Torch)
                    {
                        qPtr.TypeSpecificValue = Constants.FuelTorch / 2;
                    }
                    if (qPtr.ItemSubCategory == LightType.Lantern)
                    {
                        qPtr.TypeSpecificValue = Constants.FuelLamp / 2;
                    }
                }
                qPtr.BecomeKnown();
                qPtr.IdentStoreb = true;
                if (qPtr.Category == ItemTypeEnum.Chest)
                {
                    continue;
                }
                if (qPtr.Value() < MinimumItemValue)
                {
                    continue;
                }
                MassProduce(qPtr);
                StoreCarry(qPtr);
                break;
            }
        }

        private void StoreDelete()
        {
            int what = Program.Rng.RandomLessThan(_inventory.Count);
            int num = _inventory[what].Count;
            if (Program.Rng.RandomLessThan(100) < 50)
            {
                num = (num + 1) / 2;
            }
            if (Program.Rng.RandomLessThan(100) < 50)
            {
                num = 1;
            }
            StoreItemIncrease(what, -num);
            StoreItemOptimize(what);
        }

        public void StoreExamine()
        {
            if (_inventory.Count <= 0)
            {
                SaveGame.MsgPrint(NoStockMessage);
                return;
            }
            int i = _inventory.Count - _storeTop;
            if (i > PageSize)
            {
                i = PageSize;
            }
            const string outVal = "Which item do you want to examine? ";
            if (!GetStock(out int item, outVal, 0, i - 1))
            {
                return;
            }
            item += _storeTop;
            Item oPtr = _inventory[item];
            if (BookItemClass.IsBook(oPtr.BaseItemCategory))
            {
                //BookItemClass book = (BookItemClass)oPtr.BaseItemCategory;
                if (SaveGame.Player.PrimaryRealm?.SpellBookItemCategory == oPtr.Category)
                {
                    DoStoreBrowse(oPtr);
                }
                else
                {
                    SaveGame.MsgPrint("The spells in the book are unintelligible to you.");
                    return;
                }
            }
            if (!oPtr.IdentMental)
            {
                SaveGame.MsgPrint("You have no special knowledge about that item.");
                return;
            }
            string oName = oPtr.Description(true, 3);
            SaveGame.MsgPrint($"Examining {oName}...");
            if (!oPtr.IdentifyFully())
            {
                SaveGame.MsgPrint("You see nothing special.");
            }
        }

        private void StoreItemIncrease(int item, int num)
        {
            Item oPtr = _inventory[item];
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

        private void StoreItemOptimize(int item)
        {
            Item oPtr = _inventory[item];
            if (oPtr.BaseItemCategory == null)
            {
                return;
            }
            if (oPtr.Count > 0)
            {
                return;
            }
            _inventory.RemoveAt(item);
        }

        private void StoreObjectAbsorb(Item oPtr, Item jPtr)
        {
            int total = oPtr.Count + jPtr.Count;
            oPtr.Count = total > 99 ? 99 : total;
        }

        private bool StoreObjectSimilar(Item oPtr, Item jPtr)
        {
            if (oPtr == jPtr)
            {
                return false;
            }
            if (oPtr.BaseItemCategory != jPtr.BaseItemCategory)
            {
                return false;
            }
            if (oPtr.TypeSpecificValue != jPtr.TypeSpecificValue)
            {
                return false;
            }
            if (oPtr.BonusToHit != jPtr.BonusToHit)
            {
                return false;
            }
            if (oPtr.BonusDamage != jPtr.BonusDamage)
            {
                return false;
            }
            if (oPtr.BonusArmourClass != jPtr.BonusArmourClass)
            {
                return false;
            }
            if (oPtr.FixedArtifactIndex != jPtr.FixedArtifactIndex)
            {
                return false;
            }
            if (oPtr.RareItemTypeIndex != jPtr.RareItemTypeIndex)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(oPtr.RandartName) || !string.IsNullOrEmpty(jPtr.RandartName))
            {
                return false;
            }
            if (oPtr.RandartItemCharacteristics != jPtr.RandartItemCharacteristics)
            {
                return false;
            }
            if (oPtr.BonusPowerType != 0 || jPtr.BonusPowerType != 0)
            {
                return false;
            }
            if (oPtr.RechargeTimeLeft != 0 || jPtr.RechargeTimeLeft != 0)
            {
                return false;
            }
            if (oPtr.BaseArmourClass != jPtr.BaseArmourClass)
            {
                return false;
            }
            if (oPtr.DamageDice != jPtr.DamageDice)
            {
                return false;
            }
            if (oPtr.DamageDiceSides != jPtr.DamageDiceSides)
            {
                return false;
            }
            if (oPtr.Category == ItemTypeEnum.Chest)
            {
                return false;
            }
            if (oPtr.Discount != jPtr.Discount)
            {
                return false;
            }
            return true;
        }

        private void DoCmdStudy()
        {
            string spellType = SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Arcane ? "spell" : "prayer";
            // If we don't have a realm then we can't do anything
            if (!SaveGame.Player.CanCastSpells)
            {
                SaveGame.MsgPrint("You cannot read books!");
                return;
            }
            // We can't learn spells if we're blind or confused
            if (SaveGame.Player.TimedBlindness.TurnsRemaining != 0)
            {
                SaveGame.MsgPrint("You cannot see!");
                return;
            }
            if (SaveGame.Player.TimedConfusion.TurnsRemaining != 0)
            {
                SaveGame.MsgPrint("You are too confused!");
                return;
            }
            // We can only learn new spells if we have spare slots
            if (SaveGame.Player.SpareSpellSlots == 0)
            {
                SaveGame.MsgPrint($"You cannot learn any new {spellType}s!");
                return;
            }
            string plural = SaveGame.Player.SpareSpellSlots == 1 ? "" : "s";
            SaveGame.MsgPrint($"You can learn {SaveGame.Player.SpareSpellSlots} new {spellType}{plural}.");
            SaveGame.MsgPrint(null);
            // Get the spell books we have
            if (!SaveGame.GetItem(out int itemIndex, "Study which book? ", false, true, true, new UsableSpellBookItemFilter(SaveGame)))
            {
                if (itemIndex == -2)
                {
                    SaveGame.MsgPrint("You have no books that you can read.");
                }
                return;
            }
            // Check each book
            Item item = itemIndex >= 0 ? SaveGame.Player.Inventory[itemIndex] : SaveGame.Level.Items[0 - itemIndex];
            int itemSubCategory = item.ItemSubCategory;
            bool useSetTwo = item.Category == SaveGame.Player.SecondaryRealm.SpellBookItemCategory;
            SaveGame.HandleStuff();
            int spellIndex;
            // Arcane casters can choose their spell
            if (SaveGame.Player.BaseCharacterClass.SpellCastingType != CastingType.Divine)
            {
                if (!SaveGame.GetSpell(out spellIndex, "study", itemSubCategory, false, useSetTwo, SaveGame.Player) && spellIndex == -1)
                {
                    return;
                }
            }
            else
            {
                // We need to choose a spell at random
                int k = 0;
                int gift = -1;
                // Gather the potential spells from the book
                for (spellIndex = 0; spellIndex < 32; spellIndex++)
                {
                    if ((Constants.BookSpellFlags[itemSubCategory] & (1u << spellIndex)) != 0)
                    {
                        if (!SaveGame.Player.SpellOkay(spellIndex, false, useSetTwo))
                        {
                            continue;
                        }
                        k++;
                        if (Program.Rng.RandomLessThan(k) == 0)
                        {
                            gift = spellIndex;
                        }
                    }
                }
                spellIndex = gift;
            }
            // If we failed to get a spell, return
            if (spellIndex < 0)
            {
                SaveGame.MsgPrint($"You cannot learn any {spellType}s from that book.");
                return;
            }
            // Learning a spell takes a turn (although that's not very relevant)
            SaveGame.EnergyUse = 100;
            // Mark the spell as learned
            Spell spell = useSetTwo ? SaveGame.Spells[1][spellIndex] : SaveGame.Spells[0][spellIndex];
            spell.Learned = true;

            // Mark the spell as the last spell learned, in case we need to start forgetting them
            SaveGame.SpellOrder.Add(spell);

            // Let the player know they've learned a spell
            SaveGame.MsgPrint($"You have learned the {spellType} of {spell.Name}.");
            SaveGame.PlaySound(SoundEffect.Study);
            SaveGame.Player.SpareSpellSlots--;
            if (SaveGame.Player.SpareSpellSlots != 0)
            {
                plural = SaveGame.Player.SpareSpellSlots != 1 ? "s" : "";
                SaveGame.MsgPrint($"You can learn {SaveGame.Player.SpareSpellSlots} more {spellType}{plural}.");
            }
            SaveGame.Player.OldSpareSpellSlots = SaveGame.Player.SpareSpellSlots;
            SaveGame.RedrawStudyFlaggedAction.Set();
        }

        private void StoreProcessCommand()
        {
            char c = SaveGame.CurrentCommand;
            bool matchingCommandFound = false;

            // Process commands
            foreach (BaseStoreCommand command in SaveGame.SingletonRepository.StoreCommands)
            {
                // TODO: The IF statement below can be converted into a dictionary with the applicable object 
                // attached for improved performance.
                if (command.Key == c)
                {
                    matchingCommandFound = true;

                    // Ensure this command works in this store.
                    if (command.IsEnabled(this))
                    {
                        StoreCommandEvent storeCommandEvent = new StoreCommandEvent(this);
                        command.Execute(storeCommandEvent);

                        if (storeCommandEvent.RequiresRerendering)
                            DisplayStore();
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

        public void IdentifyAll()
        {
            int price;
            if (!ServiceHaggle(500, out price))
            {
                if (price >= SaveGame.Player.Gold)
                {
                    SaveGame.MsgPrint("You do not have the gold!");
                }
                else
                {
                    SaveGame.Player.Gold -= price;
                    SayComment_1();
                    SaveGame.PlaySound(SoundEffect.StoreTransaction);
                    StorePrtGold();
                    SaveGame.IdentifyPack();
                    SaveGame.MsgPrint("All your goods have been identified.");
                }
                SaveGame.HandleStuff();
            }
        }

        public void HireRoom()
        {
            int price;
            if (SaveGame.Player.TimedPoison.TurnsRemaining > 0 || SaveGame.Player.TimedBleeding.TurnsRemaining > 0)
            {
                SaveGame.MsgPrint("You need a healer, not a room!");
                SaveGame.MsgPrint("I'm sorry, but  I don't want anyone dying in here.");
            }
            else
            {
                if (!ServiceHaggle(10, out price))
                {
                    if (price >= SaveGame.Player.Gold)
                    {
                        SaveGame.MsgPrint("You do not have the gold!");
                    }
                    else
                    {
                        SaveGame.Player.Gold -= price;
                        SayComment_1();
                        SaveGame.PlaySound(SoundEffect.StoreTransaction);
                        StorePrtGold();
                        RoomRest(SaveGame.Player.Race.RestsTillDuskInsteadOfDawn);
                    }
                }
            }
        }

        public void ResearchSpell()
        {
            DoCmdStudy();
        }

        public void Rest()
        {
            if (SaveGame.Player.TimedPoison.TurnsRemaining > 0 || SaveGame.Player.TimedBleeding.TurnsRemaining > 0)
            {
                SaveGame.MsgPrint("Your wounds prevent you from sleeping.");
            }
            else
            {
                RoomRest(SaveGame.Player.Race.RestsTillDuskInsteadOfDawn);
            }
        }

        public void ResearchItem()
        {
            int price;
            if (!ServiceHaggle(2000, out price))
            {
                if (price > SaveGame.Player.Gold)
                {
                    SaveGame.MsgPrint("You do not have the gold!");
                }
                else
                {
                    SaveGame.Player.Gold -= price;
                    SayComment_1();
                    SaveGame.PlaySound(SoundEffect.StoreTransaction);
                    StorePrtGold();
                    SaveGame.IdentifyFully();
                }
                SaveGame.HandleStuff();
            }
        }

        public void Restoration()
        {
            int price;
            if (!ServiceHaggle(750, out price))
            {
                if (price > SaveGame.Player.Gold)
                {
                    SaveGame.MsgPrint("You do not have the gold!");
                }
                else
                {
                    SaveGame.Player.Gold -= price;
                    SayComment_1();
                    SaveGame.PlaySound(SoundEffect.StoreTransaction);
                    StorePrtGold();
                    SaveGame.Player.TryRestoringAbilityScore(Ability.Strength);
                    SaveGame.Player.TryRestoringAbilityScore(Ability.Intelligence);
                    SaveGame.Player.TryRestoringAbilityScore(Ability.Wisdom);
                    SaveGame.Player.TryRestoringAbilityScore(Ability.Dexterity);
                    SaveGame.Player.TryRestoringAbilityScore(Ability.Constitution);
                    SaveGame.Player.TryRestoringAbilityScore(Ability.Charisma);
                    SaveGame.Player.RestoreLevel();
                }
                SaveGame.HandleStuff();
            }
        }

        public void RemoveCurse()
        {
            int price;
            if (!ServiceHaggle(500, out price))
            {
                if (price > SaveGame.Player.Gold)
                {
                    SaveGame.MsgPrint("You do not have the gold!");
                }
                else
                {
                    SaveGame.Player.Gold -= price;
                    SayComment_1();
                    SaveGame.PlaySound(SoundEffect.StoreTransaction);
                    StorePrtGold();
                    SaveGame.RemoveCurse();
                }
                SaveGame.HandleStuff();
            }
        }

        public void EnchantWeapon()
        {
            int price;
            if (!ServiceHaggle(800, out price))
            {
                if (price > SaveGame.Player.Gold)
                {
                    SaveGame.MsgPrint("You do not have the gold!");
                }
                else
                {
                    SaveGame.Player.Gold -= price;
                    SayComment_1();
                    SaveGame.PlaySound(SoundEffect.StoreTransaction);
                    StorePrtGold();
                    SaveGame.EnchantSpell(4, 4, 0);
                }
                SaveGame.HandleStuff();
            }
        }

        public void EnchantArmour()
        {
            int price;
            if (!ServiceHaggle(400, out price))
            {
                if (price > SaveGame.Player.Gold)
                {
                    SaveGame.MsgPrint("You do not have the gold!");
                }
                else
                {
                    SaveGame.Player.Gold -= price;
                    SayComment_1();
                    SaveGame.PlaySound(SoundEffect.StoreTransaction);
                    StorePrtGold();
                    SaveGame.EnchantSpell(0, 0, 4);
                }
                SaveGame.HandleStuff();
            }
        }

        public void HireAnEscort()
        {
            int price;
            var escortable = new Dictionary<char, Town>();
            foreach (Town town in SaveGame.SingletonRepository.Towns)
            {
                if (town.Visited && town.Name != SaveGame.CurTown.Name && town.Char != 'K')
                {
                    escortable.Add(town.Char, town);
                }
            }
            if (escortable.Count == 0)
            {
                SaveGame.MsgPrint("There are no valid destinations to be escorted to.");
                SaveGame.MsgPrint("You must have visited a town before you can be escorted there.");
            }
            else
            {
                var destination = GetEscortDestination(escortable);
                if (destination != null)
                {
                    if (!ServiceHaggle(200, out price))
                    {
                        if (price > SaveGame.Player.Gold)
                        {
                            SaveGame.MsgPrint("You do not have the gold!");
                        }
                        else
                        {
                            SaveGame.Player.Gold -= price;
                            SayComment_1();
                            SaveGame.PlaySound(SoundEffect.StoreTransaction);
                            StorePrtGold();
                            SaveGame.Player.WildernessX = destination.X;
                            SaveGame.Player.WildernessY = destination.Y;
                            SaveGame.CurTown = destination;
                            SaveGame.NewLevelFlag = true;
                            SaveGame.CameFrom = LevelStart.StartRandom;
                            SaveGame.MsgPrint("The journey takes all day.");
                            SaveGame.Player.GameTime.ToNextDusk();
                            _leaveStore = true;
                        }
                    }
                }
            }
            SaveGame.HandleStuff();
        }

        protected void StorePrtGold()
        {
            SaveGame.Screen.PrintLine("Gold Remaining: ", 39, 53);
            string outVal = $"{SaveGame.Player.Gold,9}";
            SaveGame.Screen.PrintLine(outVal, 39, 68);
        }

        protected virtual string NoStockMessage => "I am currently out of stock.";
        protected virtual string PurchaseMessage => "Which item are you interested in? ";

        /// <summary>
        /// Returns true, if the store sells items for gold to the player.  The home does not sell items.
        /// </summary>
        protected virtual bool StoreSellsItems => true;

        public void StorePurchase()
        {
            int itemNew;
            string oName;
            if (_inventory.Count <= 0)
            {
                SaveGame.MsgPrint(NoStockMessage);
                return;
            }
            int i = _inventory.Count - _storeTop;
            if (i > PageSize)
            {
                i = PageSize;
            }
            string outVal = PurchaseMessage;
            if (!GetStock(out int item, outVal, 0, i - 1))
            {
                return;
            }
            item += _storeTop;
            Item oPtr = _inventory[item];
            int amt = 1;
            Item jPtr = oPtr.Clone(amt);
            if (!SaveGame.Player.InvenCarryOkay(jPtr))
            {
                SaveGame.MsgPrint("You cannot carry that many different items.");
                return;
            }
            int best = PriceItem(jPtr, _owner.MinInflate, false);
            if (oPtr.Count > 1)
            {
                if (StoreSellsItems && oPtr.IdentFixed)
                {
                    SaveGame.MsgPrint($"That costs {best} gold per item.");
                }
                int maxBuy = Math.Min(SaveGame.Player.Gold / best, oPtr.Count);
                if (maxBuy < 2)
                {
                    amt = 1;
                }
                else
                {
                    amt = SaveGame.GetQuantity(null, maxBuy, false);
                    if (amt <= 0)
                    {
                        return;
                    }
                }
            }
            jPtr = oPtr.Clone(amt);
            if (!SaveGame.Player.InvenCarryOkay(jPtr))
            {
                SaveGame.MsgPrint("You cannot carry that many items.");
                return;
            }
            if (StoreSellsItems)
            {
                bool choice;
                int price;
                if (oPtr.IdentFixed)
                {
                    choice = false;
                    price = best * jPtr.Count;
                }
                else
                {
                    oName = GetItemDescription(jPtr);
                    SaveGame.MsgPrint($"Buying {oName} ({item.IndexToLetter()}).");
                    SaveGame.MsgPrint(null);
                    choice = PurchaseHaggle(jPtr, out price);
                }
                if (!choice)
                {
                    if (SaveGame.Player.Gold >= price)
                    {
                        SayComment_1();
                        SaveGame.PlaySound(SoundEffect.StoreTransaction);
                        SaveGame.Player.Gold -= price;
                        StorePrtGold();
                        if (StoreIdentifiesItems)
                        {
                            jPtr.BecomeFlavourAware();
                        }
                        jPtr.IdentFixed = false;
                        oName = jPtr.Description(true, 3);
                        SaveGame.MsgPrint(BoughtMessage(oName, price));
                        jPtr.Inscription = "";
                        itemNew = SaveGame.Player.InvenCarry(jPtr, false);
                        oName = SaveGame.Player.Inventory[itemNew].Description(true, 3);
                        SaveGame.MsgPrint($"You have {oName} ({itemNew.IndexToLabel()}).");
                        SaveGame.HandleStuff();
                        i = _inventory.Count;
                        StoreItemIncrease(item, -amt);
                        StoreItemOptimize(item);
                        if (_inventory.Count == 0)
                        {
                            if (MaintainsStockLevels)
                            {
                                if (Program.Rng.RandomLessThan(Constants.StoreShuffle) == 0)
                                {
                                    SaveGame.MsgPrint("The shopkeeper retires.");
                                    StoreShuffle();
                                }
                                else
                                {
                                    SaveGame.MsgPrint("The shopkeeper brings out some new stock.");
                                }
                                for (i = 0; i < 10; i++)
                                {
                                    StoreMaint();
                                }
                            }
                            _storeTop = 0;
                            DisplayInventory();
                        }
                        else if (_inventory.Count != i)
                        {
                            if (_storeTop >= _inventory.Count)
                            {
                                _storeTop -= PageSize;
                            }
                            DisplayInventory();
                        }
                        else
                        {
                            DisplayEntry(item);
                        }
                    }
                    else
                    {
                        SaveGame.MsgPrint("You do not have enough gold.");
                    }
                }
            }
            else
            {
                itemNew = SaveGame.Player.InvenCarry(jPtr, false);
                oName = SaveGame.Player.Inventory[itemNew].Description(true, 3);
                SaveGame.MsgPrint($"You have {oName} ({itemNew.IndexToLabel()}).");
                SaveGame.HandleStuff();
                i = _inventory.Count;
                StoreItemIncrease(item, -amt);
                StoreItemOptimize(item);
                if (i == _inventory.Count)
                {
                    DisplayEntry(item);
                }
                else
                {
                    if (_inventory.Count == 0)
                    {
                        _storeTop = 0;
                    }
                    else if (_storeTop >= _inventory.Count)
                    {
                        _storeTop -= PageSize;
                    }
                    DisplayInventory();
                }
            }
        }
        protected virtual string BoughtMessage(string oName, int price) => $"You bought {oName} for {price} gold.";

        protected virtual string SellPrompt => "Sell which item? ";
        protected virtual string StoreFullMessage => "I have not the room in my Stores to keep it.";

        /// <summary>
        /// Returns true, if the store keeps inscriptions on items it acquires.  Only the players home does this.
        /// </summary>
        protected virtual bool StoreMaintainsInscription => false;

        protected virtual bool StoreBuysItems => true;

        /// <summary>
        /// Returns the verb when the player sells or drops an item to the store.  Normally, "sold", but the home "drops" and the pawn shop "pawns".
        /// </summary>
        protected virtual string BoughtVerb => "sold";

        /// <summary>
        /// Returns true, if the store identifies items when the player sells an item to the store.  Does not apply to stores that do not buy items.
        /// </summary>
        protected virtual bool StoreIdentifiesItems => true;

        protected virtual bool StoreAnalyzesPurchases => true;

        public void StoreSell()
        {
            int itemPos;
            if (!SaveGame.GetItem(out int item, SellPrompt, true, true, false, this)) // We use the store itself as the ItemFilter because the Store implements IItemFilter.
            {
                if (item == -2)
                {
                    SaveGame.MsgPrint("You have nothing that I want.");
                }
                return;
            }
            Item oPtr = item >= 0 ? SaveGame.Player.Inventory[item] : SaveGame.Level.Items[0 - item];
            if (item >= InventorySlot.MeleeWeapon && oPtr.IsCursed())
            {
                SaveGame.MsgPrint("Hmmm, it seems to be cursed.");
                return;
            }
            int amt = 1;
            if (oPtr.Count > 1)
            {
                amt = SaveGame.GetQuantity(null, oPtr.Count, true);
                if (amt <= 0)
                {
                    return;
                }
            }
            Item qPtr = oPtr.Clone();
            qPtr.Count = amt;
            string oName = qPtr.Description(true, 3);
            if (!StoreMaintainsInscription)
            {
                qPtr.Inscription = "";
            }
            if (!StoreCanAcceptMoreItems(qPtr))
            {
                SaveGame.MsgPrint(StoreFullMessage);
                return;
            }
            if (StoreBuysItems)
            {
                SaveGame.MsgPrint($"Selling {oName} ({item.IndexToLabel()}).");
                SaveGame.MsgPrint(null);
                bool choice = SellHaggle(qPtr, out int price);
                if (!choice)
                {
                    SayComment_1();
                    SaveGame.PlaySound(SoundEffect.StoreTransaction);
                    SaveGame.Player.Gold += price;
                    StorePrtGold();
                    int guess = qPtr.Value() * qPtr.Count;
                    if (StoreIdentifiesItems)
                    {
                        oPtr.BecomeFlavourAware();
                        oPtr.BecomeKnown();
                    }
                    SaveGame.NoticeCombineAndReorderFlaggedAction.Set();
                    qPtr = oPtr.Clone();
                    qPtr.Count = amt;
                    int value;
                    if (!StoreAnalyzesPurchases)
                    {
                        value = guess;
                    }
                    else
                    {
                        value = qPtr.Value() * qPtr.Count;
                        oName = qPtr.Description(true, 3);
                    }
                    SaveGame.MsgPrint($"You {BoughtVerb} {oName} for {price} gold.");
                    PurchaseAnalyze(price, value, guess);
                }
            }
            else
            {
                SaveGame.MsgPrint($"You drop {oName} ({item.IndexToLabel()}).");
            }

            SaveGame.Player.InvenItemIncrease(item, -amt);
            SaveGame.Player.InvenItemDescribe(item);
            SaveGame.Player.InvenItemOptimize(item);
            SaveGame.HandleStuff();
            itemPos = CarryItem(qPtr);
            if (itemPos >= 0)
            {
                _storeTop = itemPos / PageSize * PageSize;
                DisplayInventory();
            }
        }
    }
}