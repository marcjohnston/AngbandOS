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

    private UpdateManaFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {       
        if (!Game.UsesMana)
        {
            return;
        }
        int msp = Game.BaseCharacterClass.SpellStat.ManaBonus * Game.HalfLevelsOfSpellcraft() / 2;
        if (msp != 0)
        {
            msp++;
        }
        if (msp != 0 && Game.BaseCharacterClass.ID == CharacterClassEnum.HighMage)
        {
            msp += msp / 4;
        }

        // Allow wield slots to access to the CalcMana process.
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
        {
            // Update the mana for the wield slot.
            msp = inventorySlot.CalcMana(Game, msp);
        }

        if (Game.BaseCharacterClass.WeightEncumbersMovement)
        {
            int curWgt = 0;
            foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
            {
                if (inventorySlot.IsWeightRestricting)
                {
                    foreach (int index in inventorySlot)
                    {
                        Item? item = Game.GetInventoryItem(index);
                        if (item != null)
                        {
                            curWgt += item.Weight;
                        }
                    }
                }
            }
            int maxWgt = Game.BaseCharacterClass.SpellWeight;
            if ((curWgt - maxWgt) / 10 > 0)
            {
                msp -= (curWgt - maxWgt) / 10;
                if (!OldRestrictingArmor)
                {
                    Game.MsgPrint("The weight of your armor encumbers your movement.");
                    OldRestrictingArmor = true;
                }
            }
            else
            {
                if (OldRestrictingArmor)
                {
                    Game.MsgPrint("You feel able to move more freely.");
                    OldRestrictingArmor = false;
                }
            }
        }

        if (msp < 0)
        {
            msp = 0;
        }

        var mult = Game.SingletonRepository.Get<God>(nameof(TamashGod)).AdjustedFavour + 10;
        msp *= mult;
        msp /= 10;
        if (Game.MaxMana.IntValue != msp)
        {
            if (Game.Mana.IntValue >= msp)
            {
                Game.Mana.IntValue = msp;
                Game.FractionalMana = 0;
            }
            Game.MaxMana.IntValue = msp;
        }
    }
}
