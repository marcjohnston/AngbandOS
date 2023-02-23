// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots
{
    [Serializable]
    internal class PackInventorySlot : BaseInventorySlot
    {
        private PackInventorySlot(SaveGame saveGame) : base(saveGame) { }
        public override int[] InventorySlots => new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        public override string Label(int index) => alphabet[index].ToString();
        public override string MentionUse(int? index) => "In pack";
        public override string SenseLocation(int index) => "in your pack";
        public override int SortOrder => 0;
        public override string DescribeWieldLocation(int index) => "carrying in your pack";

        public override bool IsEquipment => false;
        /// <summary>
        /// Returns true, to sense the identity of items in the pack only 20% of the time.
        /// </summary>
        public override bool IdentitySenseChanceTest => Program.Rng.RandomLessThan(5) == 0;

        /// <summary>
        /// Allows items being carried in a pack to hook into the ProcessWorld event.  By default, this method initiates the hook for all items in the inventory slot to perform processing 
        /// during the ProcessWorld event through the PackProcessWorld method.
        /// </summary>
        public override void ProcessWorldHook(ProcessWorldEventArgs processWorldEventArgs)
        {
            base.ProcessWorldHook(processWorldEventArgs);

            foreach (int index in InventorySlots)
            {
                Item oPtr = SaveGame.Player.Inventory[index];
                oPtr.PackProcessWorldHook(SaveGame);
            }
        }
    }
}