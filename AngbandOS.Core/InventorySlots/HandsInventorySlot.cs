// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class HandsInventorySlot : EquipmentInventorySlot
{
    private bool RestrictingGloves;
    private HandsInventorySlot(SaveGame saveGame) : base(saveGame) { }
    public override string Label(int index) => "l";
    public override string Label(Item oPtr) => "l";
    public override int[] InventorySlots => new int[] { InventorySlot.Hands };
    public override string MentionUse(int? index) => "On hands";
    public override string DescribeWieldLocation(int index) => "wearing on your hands";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your hands";
    public override int BareArmorClassBonus => SaveGame.ExperienceLevel.Value > 4 ? SaveGame.ExperienceLevel.Value / 2 : 0;
    public override bool IsWeightRestricting => true;
    public override bool IsArmor => true;
    public override int SortOrder => 12;

    public override int CalcMana(SaveGame saveGame, int msp)
    {
        if (SaveGame.BaseCharacterClass.CoveredHandsRestrictCasting)
        {
            bool previousRestrictingGloves = RestrictingGloves;
            RestrictingGloves = false;
            foreach (int index in InventorySlots)
            {
                Item? oPtr = SaveGame.GetInventoryItem(index);
                if (oPtr != null)
                {
                    oPtr.RefreshFlagBasedProperties();
                    if (!oPtr.Characteristics.FreeAct && !oPtr.Characteristics.Dex && oPtr.TypeSpecificValue > 0)
                    {
                        msp = 3 * msp / 4;
                        RestrictingGloves = true;
                    }
                }
            }
            if (RestrictingGloves && !previousRestrictingGloves)
            {
                SaveGame.MsgPrint("Your covered hands feel unsuitable for spellcasting.");
            }
            else if (!RestrictingGloves && previousRestrictingGloves)
            {
                SaveGame.MsgPrint("Your hands feel more suitable for spellcasting.");
            }
        }
        return msp;
    }
}