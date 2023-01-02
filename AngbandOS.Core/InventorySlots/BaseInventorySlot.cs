// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Collections;

namespace AngbandOS.Core.InventorySlots
{
    [Serializable]
    internal abstract class BaseInventorySlot : IEnumerable<Item>
    {
        protected const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public SaveGame SaveGame { get; }
        public BaseInventorySlot(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
        private List<Item> Items = new List<Item>();
        public abstract string Label(int index);

        public virtual string SenseLocation => $"you are {DescribeWieldLocation}";

        public WeightedRandom<Item> WeightedRandom => new WeightedRandom<Item>(Items);

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
        /// Returns true, if the inventory slot is a melee item; false, otherwise.  Melee and ranged return true.
        /// </summary>
        public virtual bool IsMelee => false;

        /// <summary>
        /// Returns true, if the item in the inventory slot can be disenchanted; false, otherwise.  All armour (Body, head, cloak, arms, hands and feet) and
        /// melee (melee and ranged) positions, return true.
        /// </summary>
        public virtual bool CanBeDisenchanted => IsArmour || IsMelee;

        /// <summary>
        /// Returns true, if the inventory slot is considered armour that the player is wearing.  Body, head, cloak, arms, hands and feet
        /// are all return true.
        /// </summary>
        public virtual bool IsArmour => false;

        /// <summary>
        /// Returns true, if items in the slot are restricting, based on their weight.  Returns false, by default.
        /// </summary>
        public virtual bool IsWeightRestricting => false;

        /// <summary>
        /// Returns true, if the inventory slot represents equipment; false, if the inventory slot represents a pack.  Defaults to true.
        /// </summary>
        public virtual bool IsEquipment => true;

        /// <summary>
        /// Returns true, if an identity sense chance test passes so that the item is identified; false, if the
        /// the item should not identified.  Returns true, by default.  Wielded items always return true.   Items in the
        /// pack return a random positive result so that the item is identitied much less frequently.
        /// </summary>
        public virtual bool IdentitySenseChanceTest => true;

        public IEnumerator<Item> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public abstract string MentionUse { get; }
        public abstract string DescribeWieldLocation { get; }
        public virtual int Count => Items.Count;
        public virtual Item this[int index] => Items[index];

        /// <summary>
        /// Returns a bonus for armour class, for Monk and Mystic character classes when the player doesn't have use the slot.
        /// </summary>
        public virtual int BareArmourClassBonus => 0;
    }
}