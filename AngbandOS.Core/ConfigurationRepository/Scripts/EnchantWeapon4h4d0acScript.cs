// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnchantWeapon4h4d0acScript : Script, IScript, IStoreScript, ISuccessfulScript
{
    private EnchantWeapon4h4d0acScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the enchant weapon script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        if (!SaveGame.ServiceHaggle(800, out int price))
        {
            if (price > SaveGame.Gold.Value)
            {
                SaveGame.MsgPrint("You do not have the gold!");
            }
            else
            {
                SaveGame.Gold.Value -= price;
                SaveGame.SayComment_1();
                SaveGame.PlaySound(SoundEffectEnum.StoreTransaction);
                SaveGame.StorePrtGold();
                ExecuteScript();
            }
            SaveGame.HandleStuff();
        }
    }

    public bool ExecuteSuccessfulScript()
    {
        return SaveGame.EnchantItem(4, 4, 0);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
