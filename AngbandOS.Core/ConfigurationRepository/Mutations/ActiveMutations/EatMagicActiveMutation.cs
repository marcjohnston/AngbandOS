﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class EatMagicActiveMutation : Mutation
{
    private EatMagicActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.SelectItem(out Item? oPtr, "Drain which item? ", false, true, true, new RechargableItemFilter()))
        {
            saveGame.MsgPrint("You have nothing appropriate to eat.");
            return;
        }
        if (!saveGame.CheckIfRacialPowerWorks(17, 1, Ability.Wisdom, 15))
        {
            return;
        }
        if (oPtr == null)
        {
            return;
        }

        int lev = oPtr.Factory.Level;
        if (oPtr.Category == ItemTypeEnum.Rod)
        {
            if (oPtr.TypeSpecificValue > 0)
            {
                saveGame.MsgPrint("You can't absorb energy from a discharged rod.");
            }
            else
            {
                saveGame.Mana += 2 * lev;
                oPtr.TypeSpecificValue = 500;
            }
        }
        else
        {
            if (oPtr.TypeSpecificValue > 0)
            {
                saveGame.Mana += oPtr.TypeSpecificValue * lev;
                oPtr.TypeSpecificValue = 0;
            }
            else
            {
                saveGame.MsgPrint("There's no energy there to absorb!");
            }
            oPtr.IdentEmpty = true;
        }
        if (saveGame.Mana > saveGame.MaxMana)
        {
            saveGame.Mana = saveGame.MaxMana;
        }
        SaveGame.SingletonRepository.FlaggedActions.Get<NoticeCombineAndReorderGroupSetFlaggedAction>().Set();
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 17 ? "eat magic        (unusable until level 17)" : "eat magic        (cost 1, WIS based)";
    }

    public override int Frequency => 1;
    public override string GainMessage => "Your magic items look delicious.";
    public override string HaveMessage => "You can consume magic energy for your own use.";
    public override string LoseMessage => "Your magic items no longer look delicious.";
}