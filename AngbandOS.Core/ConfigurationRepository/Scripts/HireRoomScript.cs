// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HireRoomScript : Script, IStoreScript
{
    private HireRoomScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Offers and sells a room.  When sold the player wakes up the next day fully rested.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        int price;
        if (SaveGame.PoisonTimer.Value > 0 || SaveGame.TimedBleeding.Value > 0)
        {
            SaveGame.MsgPrint("You need a healer, not a room!");
            SaveGame.MsgPrint("I'm sorry, but  I don't want anyone dying in here.");
        }
        else
        {
            if (!SaveGame.ServiceHaggle(10, out price))
            {
                if (price >= SaveGame.Gold.Value)
                {
                    SaveGame.MsgPrint("You do not have the gold!");
                }
                else
                {
                    SaveGame.Gold.Value -= price;
                    SaveGame.SayComment_1();
                    SaveGame.PlaySound(SoundEffectEnum.StoreTransaction);
                    SaveGame.StorePrtGold();
                    SaveGame.RunScript(nameof(RestInRoomScript));
                }
            }
        }
    }
}
