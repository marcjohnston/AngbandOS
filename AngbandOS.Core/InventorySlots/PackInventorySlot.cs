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
        public PackInventorySlot(SaveGame saveGame) : base(saveGame) { }
        public override string Label(int index) => alphabet[index].ToString();
        public override string MentionUse => "In pack";
        public override string SenseLocation => "in your pack";
        public override string DescribeWieldLocation => "carrying in your pack";

        public override bool IsEquipment => false;
        /// <summary>
        /// Returns true, to sense the identity of items in the pack only 20% of the time.
        /// </summary>
        public override bool IdentitySenseChanceTest => Program.Rng.RandomLessThan(5) == 0;
    }
}