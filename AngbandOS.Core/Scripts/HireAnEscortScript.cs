// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HireAnEscortScript : Script, IScript, ICastSpellScript, IScriptStore, ISuccessByChanceScript
{
    private HireAnEscortScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the hire escort script successful script and sets the leave store flag to true, if the script was successful.
    /// </summary>
    /// <param name="storeCommandEvent"></param>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        storeCommandEvent.LeaveStore = ExecuteSuccessByChanceScript();
    }

    /// <summary>
    /// Executes the hire escort script and disposes of the successful result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }

    /// <summary>
    /// Executes the hire escort script and returns true, if the player was escorted to another town; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        var validTowns = new Dictionary<char, Town>();
        foreach (Town town in Game.SingletonRepository.Get<Town>())
        {
            if (town.Visited && town.Name != Game.CurTown.Name && town.CanBeEscortedHere)
            {
                validTowns.Add(town.Char, town);
            }
        }
        if (validTowns.Count == 0)
        {
            Game.MsgPrint("There are no valid destinations to be escorted to.");
            Game.MsgPrint("You must have visited a town before you can be escorted there.");
        }
        else
        {
            var destination = GetEscortDestination(validTowns);
            if (destination != null)
            {
                if (!Game.ServiceHaggle(200, out int price))
                {
                    if (price > Game.Gold.IntValue)
                    {
                        Game.MsgPrint("You do not have the gold!");
                    }
                    else
                    {
                        Game.Gold.IntValue -= price;
                        Game.SayComment_1();
                        Game.PlaySound(SoundEffectEnum.StoreTransaction);
                        Game.StorePrtGold();
                        Game.WildernessX = destination.X;
                        Game.WildernessY = destination.Y;
                        Game.CurTown = destination;
                        Game.NewLevelFlag = true;
                        Game.CameFrom = LevelStartEnum.StartRandom;
                        Game.MsgPrint("The journey takes all day.");
                        Game.ToNextDusk();
                        return true;
                    }
                }
            }
        }
        Game.HandleStuff();
        return false;
    }

    private Town? GetEscortDestination(Dictionary<char, Town> towns)
    {
        ScreenBuffer savedScreen = Game.Screen.Clone();
        try
        {
            var keys = towns.Keys.ToList();
            keys.Sort();
            string outVal = $"Destination town ({keys[0].ToString().ToLower()} to {keys[keys.Count - 1].ToString().ToLower()})? ";
            for (int i = 0; i < keys.Count; i++)
            {
                Game.Screen.Print(ColorEnum.White, $" {keys[i].ToString().ToLower()}) {towns[keys[i]].Name}".PadRight(60), i + 1, 20);
            }
            Game.Screen.Print(ColorEnum.White, "".PadRight(60), keys.Count + 1, 20);
            while (Game.GetCom(outVal, out char choice))
            {
                choice = choice.ToString().ToUpper()[0];
                foreach (var c in keys)
                {
                    if (choice == c)
                    {
                        return towns[c];
                    }
                }
            }
        }
        finally
        {
            Game.Screen.Restore(savedScreen);
        }
        return null;
    }
}
