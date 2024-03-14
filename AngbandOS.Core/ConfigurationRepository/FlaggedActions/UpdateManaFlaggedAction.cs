// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateManaFlaggedAction : FlaggedAction
{
    /// <summary>
    /// Returns the previous computation of weight restricting armor.  This is used to render a message to the player, when the player puts on
    /// or takes off armor that is restricting the spell casting ability.  This value is static because multiple pieces of armor
    /// will have this affect.
    /// </summary>
    private bool OldRestrictingArmor;

    private UpdateManaFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        
        if (SaveGame.BaseCharacterClass.SpellCastingType == null)
        {
            return;
        }
        int levels = SaveGame.BaseCharacterClass.SpellCastingType.Levels;
        if (levels < 0)
        {
            levels = 0;
        }
        int msp = SaveGame.AbilityScores[SaveGame.BaseCharacterClass.SpellStat].ManaBonus * levels / 2;
        if (msp != 0)
        {
            msp++;
        }
        if (msp != 0 && SaveGame.BaseCharacterClass.ID == CharacterClass.HighMage)
        {
            msp += msp / 4;
        }

        // Allow inventory slots access to the CalcMana process.
        foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
        {
            // Update the mana for the inventory slot.
            msp = inventorySlot.CalcMana(SaveGame, msp);
        }

        if (SaveGame.BaseCharacterClass.SpellCastingType.WeightEncumbersMovement)
        {
            int curWgt = 0;
            foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
            {
                if (inventorySlot.IsWeightRestricting)
                {
                    foreach (int index in inventorySlot)
                    {
                        Item? item = SaveGame.GetInventoryItem(index);
                        if (item != null)
                        {
                            curWgt += item.Weight;
                        }
                    }
                }
            }
            int maxWgt = SaveGame.BaseCharacterClass.SpellWeight;
            if ((curWgt - maxWgt) / 10 > 0)
            {
                msp -= (curWgt - maxWgt) / 10;
                if (!OldRestrictingArmor)
                {
                    SaveGame.MsgPrint("The weight of your armor encumbers your movement.");
                    OldRestrictingArmor = true;
                }
            }
            else
            {
                if (OldRestrictingArmor)
                {
                    SaveGame.MsgPrint("You feel able to move more freely.");
                    OldRestrictingArmor = false;
                }
            }
        }

        if (msp < 0)
        {
            msp = 0;
        }

        var mult = SaveGame.SingletonRepository.Gods.Get(nameof(TamashGod)).AdjustedFavour + 10;
        msp *= mult;
        msp /= 10;
        if (SaveGame.MaxMana.Value != msp)
        {
            if (SaveGame.Mana.Value >= msp)
            {
                SaveGame.Mana.Value = msp;
                SaveGame.FractionalMana = 0;
            }
            SaveGame.MaxMana.Value = msp;
        }
    }
}
