// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Collections;

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal abstract class BaseInventorySlot : IEnumerable<int>, IItemContainer, IGetKey<string> // TODO: Rename to InventorySlot when the enumeration is refactored out of existence
{
    protected const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    public SaveGame SaveGame { get; }
    protected BaseInventorySlot(SaveGame saveGame)
    {
        SaveGame = saveGame;
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
    /// Modifies the quantity of an item.  For an inventory slot, the player's weight, bonuses and mana are updated accordingly.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    public virtual void ItemIncrease(Item oPtr, int num)
    {
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
            SaveGame.WeightCarried += num * oPtr.Weight;
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateManaFlaggedAction)).Set();
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        }
    }

    public virtual void AddItem(Item oPtr) // TODO: this doesn't support the multi-item slots
    {
        int slot = oPtr.WieldSlot;
        SaveGame.SetInventoryItem(slot, oPtr);
    }

    public virtual void RemoveItem(Item oPtr) // TODO: this doesn't support the multi-item slots
    {
        int slot = FindInventorySlot(oPtr);
        SaveGame.SetInventoryItem(slot, null);
    }

    /// <summary>
    /// Returns the alphabetical label for the position of the item in the container.  The player will use this label to select the item from the container.
    /// </summary>
    /// <param name="oPtr"></param>
    public abstract string Label(Item oPtr);

    /// <summary>
    /// Renders a description of the item.  For an inventory slot, the description is rendered as possessive.
    /// </summary>
    /// <param name="item"></param>
    public virtual void ItemDescribe(Item oPtr)
    {
        string oName = oPtr.Description(true, 3);
        SaveGame.MsgPrint($"You have {oName}.");
    }

    [Obsolete("Use InventorySlot.Items WIP")]
    protected int FindInventorySlot(Item oPtr)
    {
        foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
        {
            foreach (int slot in inventorySlot.InventorySlots)
            {
                if (SaveGame.GetInventoryItem(slot) == oPtr)
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
    public bool IsInInventory => true;

    public abstract bool IsInEquipment { get; }

    /// <summary>
    /// Hooks into the ProcessWorld event.  All inventory slots receive this event and can perform additional processing based on the items being carried, either in a pack or by being
    /// worn/wielded.  Does nothing, by default.
    /// </summary>
    public virtual void ProcessWorldHook(ProcessWorldEventArgs processWorldEventArgs) { }

    /// <summary>
    /// Returns the zero-based sort order when displayed in a list with other inventory slots.  Lower numbers show before higher numbers.
    /// </summary>
    public abstract int SortOrder { get; }

    /// <summary>
    /// Returns a new mana value after the inventory items performs its effect.  By default, the initial mana amount is returned, with no change.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <param name="msp">The total amount of mana.</param>
    /// <returns></returns>
    public virtual int CalcMana(SaveGame saveGame, int msp)
    {
        return msp;
    }

    public virtual string SenseLocation(int index) => $"you are {DescribeWieldLocation(index)}";

    /// <summary>
    /// Returns a weighted random chooser for an item in the slot.  Each item has an equal weight.
    /// </summary>
    public WeightedRandom<int> WeightedRandom => new WeightedRandom<int>(SaveGame, InventorySlots);

    /// <summary>
    /// Returns true, if the inventory slot provides light; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool ProvidesLight => false;

    /// <summary>
    /// Returns the message to be rendered to inform the player when wielding.  Returns a message for wearing armour, by default.
    /// </summary>
    public virtual string WieldPhrase => "You are wearing";

    /// <summary>
    /// Returns true, if the item can be cursed; false, otherwise.  Only the body armour returns true.
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
    /// Returns true, if the item in the inventory slot can be disenchanted; false, otherwise.  All armour (Body, head, cloak, arms, hands and feet) and
    /// melee (melee and ranged) positions, return true.
    /// </summary>
    public virtual bool CanBeDisenchanted => IsArmour || IsWeapon;

    /// <summary>
    /// Returns true, if the inventory slot is considered armour that the player is wearing.  Body, head, cloak, arms, hands and feet
    /// are all return true.
    /// </summary>
    public virtual bool IsArmour => false;

    /// <summary>
    /// Returns true, if items in the slot restrict player movement.  When true, the weight of the item may adversely affect the movement of the
    /// player.  By default, items denoted as armour (IsArmour = true), return true.
    /// </summary>
    public virtual bool IsWeightRestricting => IsArmour;

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

    /// <summary>
    /// Returns a string that describes the wielding location of an item in the slot.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    [Obsolete("Use DescribeItemLocation")]
    public abstract string DescribeWieldLocation(int index);

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
                if (SaveGame.GetInventoryItem(index) != null)
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
    /// Returns a bonus for armour class, for Monk and Mystic character classes when the player doesn't have use the slot.
    /// </summary>
    public virtual int BareArmourClassBonus => 0;


    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public virtual void Loaded() { }
}