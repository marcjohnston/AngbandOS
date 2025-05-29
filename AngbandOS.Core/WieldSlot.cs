// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Collections;

namespace AngbandOS.Core;

[Serializable]
internal abstract class WieldSlot : IEnumerable<int>, IItemContainer, IGetKey // TODO: Rename to InventorySlot when the enumeration is refactored out of existence
{
    protected const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    protected readonly Game Game;
    protected WieldSlot(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the maximum number of items that the inventory slot can hold.  Returns 1, by default.  All inventory slots return 1, except for the pack that returns 26 (a-z).
    /// </summary>
    public virtual int MaximumItemSlots => 1;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    //  private List<Item> Items = new List<Item>();
    public abstract int[] InventorySlots { get; }
    public virtual string TakeOffMessage(Item oPtr) => "You were wearing";

    [Obsolete("Use Label(Item)")]
    public abstract string Label(int index);

    /// <summary>
    /// Returns a description of an item in the container.
    /// </summary>
    public abstract string DescribeItemLocation(Item oPtr);

    /// <summary>
    /// Modifies the quantity of an item.  For a wielded slot, the player's weight, bonuses and mana are updated accordingly.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    public void ModifyItemStackCount(Item oPtr, int num)
    {
        oPtr.ModifyStackCount(num);

        // Items that are being wielded add or subtract from the players weight being carried.
        Game.WeightCarried += num * oPtr.Weight;
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
    }

    /// <summary>
    /// Adds an item to this inventory slot.  Since inventory slots participate as item containers, we need to implement the ability to add an item.
    /// </summary>
    /// <param name="item"></param>
    public abstract void AddItem(Item item);

    /// <summary>
    /// Removed an item from this inventory slot.  Since inventory slots participate as item containers, we need to implement the ability to remove an item.
    /// </summary>
    /// <param name="oPtr"></param>
    //public virtual void RemoveItem(Item oPtr) // TODO: this doesn't support the multi-item slots where we can wear multiple items on our neck etc.  not sure why it doesn't though
    //{
    //    int slot = FindInventorySlot(oPtr);
    //    Game.SetInventoryItem(slot, null);
    //    // TODO: need to drop the weight
    //}

    /// <summary>
    /// Returns the alphabetical label for the position of the item in the container.  The player will use this label to select the item from the container.
    /// </summary>
    /// <param name="oPtr"></param>
    public abstract string Label(Item oPtr);

    /// <summary>
    /// Renders a description of the item.  For an inventory slot, the description is rendered as possessive.
    /// </summary>
    /// <param name="item"></param>
    public string DescribeContainer(Item oPtr)
    {
        string oName = oPtr.GetFullDescription(true);
        return $"You have {oName}.";
    }

    [Obsolete("Use InventorySlot.Items WIP")]
    protected int FindInventorySlot(Item oPtr)
    {
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
        {
            foreach (int slot in inventorySlot.InventorySlots)
            {
                if (Game.GetInventoryItem(slot) == oPtr)
                {
                    return slot;
                }
            }
        }
        throw new Exception("Find slot failed.");
    }

    /// <summary>
    /// Checks the quantity of an item and removes it, when the quanity is zero.  This process differs depending on which inventory slot is containing the item.  The pack inventory slot will move
    /// subsequent items in the pack to the end of the pack; equipment slots won't.
    /// </summary>
    /// <param name="oPtr"></param>
    public abstract void ItemOptimize(Item oPtr);

    /// <summary>
    /// Returns true, because the item container belongs to the players inventory (pack & equipment).
    /// </summary>
    public bool IsWielded => true;

    public abstract bool IsWieldedAsEquipment { get; }

    /// <summary>
    /// Hooks into the ProcessWorld event.  All inventory slots receive this event and can perform additional processing based on the items being carried, either in a pack or by being
    /// worn/wielded.  Does nothing, by default.
    /// </summary>
    public virtual void ProcessWorld(ProcessWorldEventArgs processWorldEventArgs) { }

    /// <summary>
    /// Returns the zero-based sort order when displayed in a list with other inventory slots.  Lower numbers show before higher numbers.
    /// </summary>
    public abstract int SortOrder { get; }

    /// <summary>
    /// Returns a new mana value after the inventory items performs its effect.  By default, the initial mana amount is returned, with no change.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="msp">The total amount of mana.</param>
    /// <returns></returns>
    public virtual int CalcMana(Game game, int msp)
    {
        return msp;
    }

    public virtual string SenseLocation(Item item) => $"you are {DescribeItemLocation(item)}";

    /// <summary>
    /// Returns a weighted random chooser for an item in the slot.  Each item has an equal weight.
    /// </summary>
    public WeightedRandom<int> WeightedRandom => new WeightedRandom<int>(Game, InventorySlots);

    /// <summary>
    /// Returns true, if the inventory slot provides light; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool ProvidesLight => false;

    /// <summary>
    /// Returns the message to be rendered to inform the player when wielding.  Returns a message for wearing armor, by default.
    /// </summary>
    public virtual string WieldPhrase => "You are wearing";

    /// <summary>
    /// Returns true, if the item can be cursed; false, otherwise.  Only the body armor returns true.
    /// </summary>
    public virtual bool CanBeCursed => false;

    /// <summary>
    /// Returns true, if the inventory slot is a weapon; false, otherwise.  Melee and ranged inventory slots return true.
    /// </summary>
    public bool IsWeapon => IsRangedWeapon || IsMeleeWeapon;

    /// <summary>
    /// Returns true, if the inventory slot is a ranged weapon; false, otherwise.  The ranged inventory slots returns true.
    /// </summary>
    /// <value><c>true</c> if this instance is ranged weapon; otherwise, <c>false</c>.</value>
    public virtual bool IsRangedWeapon => false;

    /// <summary>
    /// Returns true, if the inventory slot is a melee weapon; false, otherwise.  The melee inventory slots returns true.
    /// </summary>
    /// <value><c>true</c> if this instance is ranged weapon; otherwise, <c>false</c>.</value>
    public virtual bool IsMeleeWeapon => false;

    /// <summary>
    /// Returns true, if the item in the inventory slot can be disenchanted; false, otherwise.  All armor (Body, head, cloak, arms, hands and feet) and
    /// melee (melee and ranged) positions, return true.
    /// </summary>
    public virtual bool CanBeDisenchanted => IsArmor || IsWeapon;

    /// <summary>
    /// Returns true, if the inventory slot is considered armor that the player is wearing.  Body, head, cloak, arms, hands and feet
    /// are all return true.
    /// </summary>
    public virtual bool IsArmor => false;

    /// <summary>
    /// Returns true, if items in the slot restrict player movement.  When true, the weight of the item may adversely affect the movement of the
    /// player.  By default, items denoted as armor (IsArmor = true), return true.
    /// </summary>
    public virtual bool IsWeightRestricting => IsArmor;

    /// <summary>
    /// Returns true, if the inventory slot represents equipment; false, if the inventory slot represents a pack.  Defaults to false.
    /// </summary>
    public virtual bool IsEquipment => false;

    /// <summary>
    /// Returns true, if an identity sense chance test passes so that the item is identified; false, if the
    /// the item should not identified.  Returns true, by default.  Wielded items always return true.   Items in the
    /// pack return a random positive result so that the item is identitied much less frequently.
    /// </summary>
    public virtual bool IdentitySenseChanceTest => true;

    /// <summary>
    /// Returns a string that describes how an item in the inventory slot is being used.
    /// </summary>
    /// <param name="index">The index of the item.  If null, a generic non-item based usage is returned.</param>
    /// <returns></returns>
    public abstract string MentionUse(int? index);

    public IEnumerator<int> GetEnumerator()
    {
        IEnumerable<int> inventorySlots = InventorySlots;
        return inventorySlots.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return InventorySlots.GetEnumerator();
    }

    /// <summary>
    /// Returns the quantity of items in the inventory slot.
    /// </summary>
    public virtual int Count
    {
        get
        {
            int count = 0;
            foreach (int index in InventorySlots)
            {
                if (Game.GetInventoryItem(index) != null)
                {
                    count++;
                }
            }
            return count;
        }
    }

    /// <summary>
    /// Returns the item in a specific inventory slot position.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public virtual int this[int index] => InventorySlots[index];

    /// <summary>
    /// Returns a bonus armor class that is applied for martial artist character classes for each inventory slot in which the player is not wearing any armor.  
    /// Monk and Mystic character classes are martial artists.  Returns 0, by default.
    /// </summary>
    public virtual int BareArmorClassBonus => 0;

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public virtual void Bind() { }
}