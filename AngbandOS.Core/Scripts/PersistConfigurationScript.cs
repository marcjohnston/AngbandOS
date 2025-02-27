// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PersistConfigurationScript : Script, IScript, ICastSpellScript
{
    private PersistConfigurationScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.CorePersistentStorage == null)
        {
            Game.MsgPrint("No persistance interface was provided to save the configuration.");
            return;
        }

        try
        {
            // List repositories.
            Game.SingletonRepository.GetStringsRepository("ElvishText").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("FindQuests").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("FunnyComments").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("FunnyDescriptions").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("HorrificDescriptions").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("InsultPlayerAttacks").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("MoanPlayerAttacks").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("IllegibleFlavorSyllables").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("ShopkeeperAcceptedComments").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("ShopkeeperBargainComments").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("ShopkeeperGoodComments").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("ShopkeeperLessThanGuessComments").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("ShopkeeperWorthlessComments").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("SingingPlayerAttacks").PersistEntities();
            Game.SingletonRepository.GetStringsRepository("WorshipPlayerAttacks").PersistEntities();

            // Dictionary repositories.
            Game.SingletonRepository.PersistSingletons();
        }
        catch (NotImplementedException)
        {
            Game.MsgPrint("The persistance interface does not support entity persistance.");
            return;
        }
        catch (Exception)
        {
            Game.MsgPrint("The persistance interface failed to save the configuration.");
            return;
        }
    }
}
