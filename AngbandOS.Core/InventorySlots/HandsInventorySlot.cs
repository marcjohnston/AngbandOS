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
    internal class HandsInventorySlot : EquipmentInventorySlot
    {
        private bool OldRestrictingGloves;
        private HandsInventorySlot(SaveGame saveGame) : base(saveGame) { }
        public override string Label(int index) => "l";
        public override int[] InventorySlots => new int[] { InventorySlot.Hands };
        public override string MentionUse(int? index) => "On hands";
        public override string DescribeWieldLocation(int index) => "wearing on your hands";
        public override int BareArmourClassBonus => SaveGame.Player.Level > 4 ? SaveGame.Player.Level / 2 : 0;
        public override bool IsWeightRestricting => true;
        public override bool IsArmour => true;
        public override int SortOrder => 12;

        public override int CalcMana(SaveGame saveGame, int msp)
        {
            if (SaveGame.Player.Spellcasting.Type == CastingType.Arcane)
            {
                foreach (int index in InventorySlots)
                {
                    Item oPtr = SaveGame.Player.Inventory[index];
                    oPtr.RefreshFlagBasedProperties();
                    if (oPtr.BaseItemCategory != null && !oPtr.Characteristics.FreeAct && !oPtr.Characteristics.Dex && oPtr.TypeSpecificValue > 0)
                    {
                        msp = 3 * msp / 4;
                        if (!OldRestrictingGloves)
                        {
                            SaveGame.MsgPrint("Your covered hands feel unsuitable for spellcasting.");
                            OldRestrictingGloves = true;
                        }
                    }
                    else
                    {
                        if (OldRestrictingGloves)
                        {
                            SaveGame.MsgPrint("Your hands feel more suitable for spellcasting.");
                            OldRestrictingGloves = false;
                        }
                    }
                }
            }
            return msp;
        }
    }
}