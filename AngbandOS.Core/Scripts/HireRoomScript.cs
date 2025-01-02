// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HireRoomScript : Script, IStoreCommandScript
{
    private HireRoomScript(Game game) : base(game) { }

    /// <summary>
    /// Offers and sells a room.  When sold the player wakes up the next day fully rested.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        int price;
        if (Game.PoisonTimer.Value > 0 || Game.BleedingTimer.Value > 0)
        {
            Game.MsgPrint("You need a healer, not a room!");
            Game.MsgPrint("I'm sorry, but  I don't want anyone dying in here.");
        }
        else
        {
            if (!Game.ServiceHaggle(10, out price))
            {
                if (price >= Game.Gold.IntValue)
                {
                    Game.MsgPrint("You do not have the gold!");
                }
                else
                {
                    Game.Gold.IntValue -= price;
                    Game.SayComment_1();
                    Game.PlaySound(SoundEffectEnum.StoreTransaction);
                    Game.StorePrtGold();
                    Game.RunScript(nameof(RestInRoomScript));
                }
            }
        }
    }
}
