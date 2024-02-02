// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BuyHouseScript : Script, IScript, IStoreScript
{
    private BuyHouseScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the buy house script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the buy house script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int price;
        if (SaveGame.TownWithHouse != null && SaveGame.TownWithHouse.Value == SaveGame.CurTown.Index)
        {
            SaveGame.MsgPrint("You already have the deeds!");
        }
        else
        {
            if (!SaveGame.ServiceHaggle(SaveGame.CurTown.HousePrice, out price))
            {
                if (price >= SaveGame.Gold)
                {
                    SaveGame.MsgPrint("You do not have the gold!");
                }
                else
                {
                    SaveGame.Gold -= price;
                    SaveGame.SayComment_1();
                    SaveGame.PlaySound(SoundEffectEnum.StoreTransaction);
                    SaveGame.StorePrtGold();
                    int? oldHouse = SaveGame.TownWithHouse;
                    SaveGame.TownWithHouse = SaveGame.CurTown.Index;
                    if (oldHouse == null)
                    {
                        SaveGame.MsgPrint("You may move in at once.");
                    }
                    else
                    {
                        SaveGame.MsgPrint("I've sold your old house to pay for the removal service.");
                        SaveGame.MoveHouse(oldHouse.Value, SaveGame.TownWithHouse.Value);
                    }
                }
                SaveGame.HandleStuff();
            }
        }
    }
}
