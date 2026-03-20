// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HireAnEscortScript : Script, IStoreCommandScript
{
    private HireAnEscortScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the hire escort script successful script and sets the leave store flag to true, if the script was successful.
    /// </summary>
    /// <param name="storeCommandEvent"></param>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
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
            var destination = Game.GetEscortDestination(validTowns);
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
                        Game.MsgPrint("The journey takes all day.");
                        Game.GoToTown(destination);
                        storeCommandEvent.LeaveStore = true;
                    }
                }
            }
        }
        Game.HandleStuff();
        storeCommandEvent.LeaveStore = false;
    }
}
