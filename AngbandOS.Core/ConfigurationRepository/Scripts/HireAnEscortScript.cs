// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HireAnEscortScript : Script, IScript, IStoreScript, ISuccessfulScript
{
    private HireAnEscortScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the hire escort script successful script and sets the leave store flag to true, if the script was successful.
    /// </summary>
    /// <param name="storeCommandEvent"></param>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        storeCommandEvent.LeaveStore = ExecuteSuccessfulScript();
    }

    /// <summary>
    /// Executes the hire escort script and disposes of the successful result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }

    /// <summary>
    /// Executes the hire escort script and returns true, if the player was escorted to another town; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        var validTowns = new Dictionary<char, Town>();
        foreach (Town town in SaveGame.SingletonRepository.Towns)
        {
            if (town.Visited && town.Name != SaveGame.CurTown.Name && town.CanBeEscortedHere)
            {
                validTowns.Add(town.Char, town);
            }
        }
        if (validTowns.Count == 0)
        {
            SaveGame.MsgPrint("There are no valid destinations to be escorted to.");
            SaveGame.MsgPrint("You must have visited a town before you can be escorted there.");
        }
        else
        {
            var destination = GetEscortDestination(validTowns);
            if (destination != null)
            {
                if (!SaveGame.ServiceHaggle(200, out int price))
                {
                    if (price > SaveGame.Gold)
                    {
                        SaveGame.MsgPrint("You do not have the gold!");
                    }
                    else
                    {
                        SaveGame.Gold -= price;
                        SaveGame.SayComment_1();
                        SaveGame.PlaySound(SoundEffectEnum.StoreTransaction);
                        SaveGame.StorePrtGold();
                        SaveGame.WildernessX = destination.X;
                        SaveGame.WildernessY = destination.Y;
                        SaveGame.CurTown = destination;
                        SaveGame.NewLevelFlag = true;
                        SaveGame.CameFrom = LevelStart.StartRandom;
                        SaveGame.MsgPrint("The journey takes all day.");
                        SaveGame.GameTime.ToNextDusk();
                        return true;
                    }
                }
            }
        }
        SaveGame.HandleStuff();
        return false;
    }

    private Town? GetEscortDestination(Dictionary<char, Town> towns)
    {
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        try
        {
            var keys = towns.Keys.ToList();
            keys.Sort();
            string outVal = $"Destination town ({keys[0].ToString().ToLower()} to {keys[keys.Count - 1].ToString().ToLower()})? ";
            for (int i = 0; i < keys.Count; i++)
            {
                SaveGame.Screen.Print(ColorEnum.White, $" {keys[i].ToString().ToLower()}) {towns[keys[i]].Name}".PadRight(60), i + 1, 20);
            }
            SaveGame.Screen.Print(ColorEnum.White, "".PadRight(60), keys.Count + 1, 20);
            while (SaveGame.GetCom(outVal, out char choice))
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
            SaveGame.Screen.Restore(savedScreen);
        }
        return null;
    }
}
