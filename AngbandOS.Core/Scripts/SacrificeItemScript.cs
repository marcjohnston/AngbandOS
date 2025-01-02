// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SacrificeItemScript : Script, IStoreCommandScript
{
    private SacrificeItemScript(Game game) : base(game) { }

    /// <summary>
    /// Allows an item to be sacrificed to regain health and mana.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        God? god = GetDestinationTown();
        if (god == null)
        {
            return;
        }
        God? deity = god;
        string pmt = "Sacrifice which item? ";
        if (!Game.SelectItem(out Item? oPtr, pmt, true, true, false, null))
        {
            Game.MsgPrint("You have nothing to sacrifice.");
            return;
        }
        if (oPtr == null)
        {
            return;
        }
        if (oPtr.IsInEquipment && oPtr.IsCursed)
        {
            Game.MsgPrint("Hmmm, it seems to be cursed.");
            return;
        }
        int amt = 1;
        if (oPtr.StackCount > 1)
        {
            amt = Game.GetQuantity(oPtr.StackCount, true);
            if (amt <= 0)
            {
                return;
            }
        }
        Item qPtr = oPtr.TakeFromStack(amt);
        string oName = qPtr.GetFullDescription(true);
        qPtr.Inscription = "";
        int finalAsk = storeCommandEvent.Store.MarkdownItem(qPtr) * qPtr.StackCount;
        oPtr.ItemDescribe();
        oPtr.ItemOptimize();
        Game.HandleStuff();
        var deityName = deity.ShortName;
        if (finalAsk <= 0)
        {
            finalAsk = -100;
        }
        var favour = finalAsk / 10;
        var oldFavour = deity.AdjustedFavour;
        Game.AddFavor(god, favour);
        var newFavour = deity.AdjustedFavour;
        var change = newFavour - oldFavour;
        if (change < 0)
        {
            Game.MsgPrint($"{deityName} is displeased with your sacrifice!");
        }
        else if (change == 0)
        {
            Game.MsgPrint($"{deityName} is indifferent to your sacrifice!");
        }
        else if (change == 1)
        {
            Game.MsgPrint($"{deityName} approves of your sacrifice!");
        }
        else if (change == 2)
        {
            Game.MsgPrint($"{deityName} likes your sacrifice!");
        }
        else if (change == 3)
        {
            Game.MsgPrint($"{deityName} loves your sacrifice!");
        }
        else
        {
            Game.MsgPrint($"{deityName} is delighted by your sacrifice!");
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
    }

    private God? GetDestinationTown()
    {
        ScreenBuffer savedScreen = Game.Screen.Clone();
        try
        {
            //var deities = Game.GetAllDeities();
            var names = new List<string>();
            var keys = new List<char>();
            foreach (God god in Game.SingletonRepository.Get<God>())
            {
                names.Add(god.LongName);
                keys.Add(god.LongName[0]);
            }
            names.Sort();
            keys.Sort();
            string outVal = $"Destination town ({keys[0].ToString().ToLower()} to {keys[keys.Count - 1].ToString().ToLower()})? ";
            for (int i = 0; i < keys.Count; i++)
            {
                Game.Screen.Print(ColorEnum.White, $" {keys[i].ToString().ToLower()}) {names[i]}".PadRight(60), i + 1, 20);
            }
            Game.Screen.Print(ColorEnum.White, "".PadRight(60), keys.Count + 1, 20);
            while (Game.GetCom(outVal, out char choice))
            {
                choice = choice.ToString().ToUpper()[0];
                foreach (var c in keys)
                {
                    if (choice == c)
                    {
                        foreach (God god in Game.SingletonRepository.Get<God>())
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
            Game.Screen.Restore(savedScreen);
        }
    }
}
