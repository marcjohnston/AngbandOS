
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateManaFlaggedAction : FlaggedAction
    {
        public UpdateManaFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            int levels;
            switch (SaveGame.Player.Spellcasting.Type)
            {
                case CastingType.None:
                    return;

                case CastingType.Arcane:
                case CastingType.Divine:
                    levels = SaveGame.Player.Level - SaveGame.Player.Spellcasting.SpellFirst + 1;
                    break;

                case CastingType.Mentalism:
                case CastingType.Channeling:
                    levels = SaveGame.Player.Level;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (levels < 0)
            {
                levels = 0;
            }
            int msp = SaveGame.Player.AbilityScores[SaveGame.Player.Spellcasting.SpellStat].ManaBonus * levels / 2;
            if (msp != 0)
            {
                msp++;
            }
            if (msp != 0 && SaveGame.Player.ProfessionIndex == CharacterClass.HighMage)
            {
                msp += msp / 4;
            }

            // Allow inventory slots access to the CalcMana process.
            foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
            {
                // Update the mana for the inventory slot.
                msp = inventorySlot.CalcMana(SaveGame, msp);
            }

            if (SaveGame.Player.Spellcasting.Type == CastingType.Arcane)
            {
                int curWgt = 0;
                foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
                {
                    if (inventorySlot.IsWeightRestricting)
                    {
                        foreach (int index in inventorySlot)
                        {
                            Item item = SaveGame.Player.Inventory[index];
                            if (item.BaseItemCategory != null)
                            {
                                curWgt += item.Weight;
                            }
                        }
                    }
                }
                int maxWgt = SaveGame.Player.Spellcasting.SpellWeight;
                if ((curWgt - maxWgt) / 10 > 0)
                {
                    msp -= (curWgt - maxWgt) / 10;
                    if (!SaveGame.Player.OldRestrictingArmour)
                    {
                        SaveGame.MsgPrint("The weight of your armour encumbers your movement.");
                        SaveGame.Player.OldRestrictingArmour = true;
                    }
                }
                else
                {
                    if (SaveGame.Player.OldRestrictingArmour)
                    {
                        SaveGame.MsgPrint("You feel able to move more freely.");
                        SaveGame.Player.OldRestrictingArmour = false;
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
}
