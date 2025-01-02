// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BuyHouseScript : Script, IScript, ICastSpellScript, IStoreCommandScript
{
    private BuyHouseScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the buy house script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
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
        if (Game.TownWithHouse != null && Game.TownWithHouse == Game.CurTown)
        {
            Game.MsgPrint("You already have the deeds!");
        }
        else
        {
            if (!Game.ServiceHaggle(Game.CurTown.HousePrice, out price))
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
                    Town? oldHouse = Game.TownWithHouse;
                    Game.TownWithHouse = Game.CurTown;
                    if (oldHouse == null)
                    {
                        Game.MsgPrint("You may move in at once.");
                    }
                    else
                    {
                        Game.MsgPrint("I've sold your old house to pay for the removal service.");
                        Game.MoveHouse(oldHouse, Game.TownWithHouse);
                    }
                }
                Game.HandleStuff();
            }
        }
    }
}
