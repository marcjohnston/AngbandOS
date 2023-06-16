
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateManaFlaggedAction : FlaggedAction
{
    /// <summary>
    /// Returns the previous computation of weight restricting armour.  This is used to render a message to the player, when the player puts on
    /// or takes off armour that is restricting the spell casting ability.  This value is static because multiple pieces of armour
    /// will have this affect.
    /// </summary>
    private bool OldRestrictingArmour;

    public UpdateManaFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        
        if (SaveGame.Player.BaseCharacterClass.SpellCastingType == null)
        {
            return;
        }
        int levels = SaveGame.Player.BaseCharacterClass.SpellCastingType.Levels;
        if (levels < 0)
        {
            levels = 0;
        }
        int msp = SaveGame.Player.AbilityScores[SaveGame.Player.BaseCharacterClass.SpellStat].ManaBonus * levels / 2;
        if (msp != 0)
        {
            msp++;
        }
        if (msp != 0 && SaveGame.Player.BaseCharacterClass.ID == CharacterClass.HighMage)
        {
            msp += msp / 4;
        }

        // Allow inventory slots access to the CalcMana process.
        foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
        {
            // Update the mana for the inventory slot.
            msp = inventorySlot.CalcMana(SaveGame, msp);
        }

        if (SaveGame.Player.BaseCharacterClass.SpellCastingType.WeightEncumbersMovement)
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
            int maxWgt = SaveGame.Player.BaseCharacterClass.SpellWeight;
            if ((curWgt - maxWgt) / 10 > 0)
            {
                msp -= (curWgt - maxWgt) / 10;
                if (!OldRestrictingArmour)
                {
                    SaveGame.MsgPrint("The weight of your armour encumbers your movement.");
                    OldRestrictingArmour = true;
                }
            }
            else
            {
                if (OldRestrictingArmour)
                {
                    SaveGame.MsgPrint("You feel able to move more freely.");
                    OldRestrictingArmour = false;
                }
            }
        }

        if (msp < 0)
        {
            msp = 0;
        }

        var mult = SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Tamash).AdjustedFavour + 10;
        msp *= mult;
        msp /= 10;
        if (SaveGame.Player.MaxMana != msp)
        {
            if (SaveGame.Player.Mana >= msp)
            {
                SaveGame.Player.Mana = msp;
                SaveGame.Player.FractionalMana = 0;
            }
            SaveGame.Player.MaxMana = msp;
            SaveGame.RedrawManaFlaggedAction.Set();
        }
    }
}
