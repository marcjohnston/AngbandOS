// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SacrificeItemScript : Script, IStoreScript
{
    private SacrificeItemScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Allows an item to be sacrificed to regain health and mana.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        God? god = GetDestinationTown();
        if (god == null)
        {
            return;
        }
        God? deity = god;
        string pmt = "Sacrifice which item? ";
        if (!SaveGame.SelectItem(out Item? oPtr, pmt, true, true, false, null))
        {
            SaveGame.MsgPrint("You have nothing to sacrifice.");
            return;
        }
        if (oPtr == null)
        {
            return;
        }
        if (oPtr.IsInEquipment && oPtr.IsCursed())
        {
            SaveGame.MsgPrint("Hmmm, it seems to be cursed.");
            return;
        }
        int amt = 1;
        if (oPtr.Count > 1)
        {
            amt = SaveGame.GetQuantity(null, oPtr.Count, true);
            if (amt <= 0)
            {
                return;
            }
        }
        Item qPtr = oPtr.Clone(amt);
        string oName = qPtr.Description(true, 3);
        qPtr.Inscription = "";
        int finalAsk = storeCommandEvent.Store.MarkdownItem(qPtr) * qPtr.Count;
        oPtr.ItemIncrease(-amt);
        oPtr.ItemDescribe();
        oPtr.ItemOptimize();
        SaveGame.HandleStuff();
        var deityName = deity.ShortName;
        if (finalAsk <= 0)
        {
            finalAsk = -100;
        }
        var favour = finalAsk / 10;
        var oldFavour = deity.AdjustedFavour;
        SaveGame.AddFavor(god, favour);
        var newFavour = deity.AdjustedFavour;
        var change = newFavour - oldFavour;
        if (change < 0)
        {
            SaveGame.MsgPrint($"{deityName} is displeased with your sacrifice!");
        }
        else if (change == 0)
        {
            SaveGame.MsgPrint($"{deityName} is indifferent to your sacrifice!");
        }
        else if (change == 1)
        {
            SaveGame.MsgPrint($"{deityName} approves of your sacrifice!");
        }
        else if (change == 2)
        {
            SaveGame.MsgPrint($"{deityName} likes your sacrifice!");
        }
        else if (change == 3)
        {
            SaveGame.MsgPrint($"{deityName} loves your sacrifice!");
        }
        else
        {
            SaveGame.MsgPrint($"{deityName} is delighted by your sacrifice!");
        }
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateHealthFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateManaFlaggedAction)).Set();
    }

    private God? GetDestinationTown()
    {
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        try
        {
            //var deities = SaveGame.GetAllDeities();
            var names = new List<string>();
            var keys = new List<char>();
            foreach (God god in SaveGame.SingletonRepository.Gods)
            {
                names.Add(god.LongName);
                keys.Add(god.LongName[0]);
            }
            names.Sort();
            keys.Sort();
            string outVal = $"Destination town ({keys[0].ToString().ToLower()} to {keys[keys.Count - 1].ToString().ToLower()})? ";
            for (int i = 0; i < keys.Count; i++)
            {
                SaveGame.Screen.Print(ColorEnum.White, $" {keys[i].ToString().ToLower()}) {names[i]}".PadRight(60), i + 1, 20);
            }
            SaveGame.Screen.Print(ColorEnum.White, "".PadRight(60), keys.Count + 1, 20);
            while (SaveGame.GetCom(outVal, out char choice))
            {
                choice = choice.ToString().ToUpper()[0];
                foreach (var c in keys)
                {
                    if (choice == c)
                    {
                        foreach (God god in SaveGame.SingletonRepository.Gods)
                        {
                            if (god.ShortName.StartsWith(choice.ToString()))
                            {
                                return god;
                            }
                        }
                        return null;
                    }
                }
            }
            return null;

        }
        finally
        {
            SaveGame.Screen.Restore(savedScreen);
        }
    }
}
