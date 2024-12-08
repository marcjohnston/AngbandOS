// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PersistConfigurationScript : Script, IScript
{
    private PersistConfigurationScript(Game game) : base(game) { }

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
            Game.SingletonRepository.ElvishText.PersistEntities();
            Game.SingletonRepository.FindQuests.PersistEntities();
            Game.SingletonRepository.FunnyComments.PersistEntities();
            Game.SingletonRepository.FunnyDescriptions.PersistEntities();
            Game.SingletonRepository.HorrificDescriptions.PersistEntities();
            Game.SingletonRepository.InsultPlayerAttacks.PersistEntities();
            Game.SingletonRepository.MoanPlayerAttacks.PersistEntities();
            Game.SingletonRepository.IllegibleFlavorSyllables.PersistEntities();
            Game.SingletonRepository.ShopkeeperAcceptedComments.PersistEntities();
            Game.SingletonRepository.ShopkeeperBargainComments.PersistEntities();
            Game.SingletonRepository.ShopkeeperGoodComments.PersistEntities();
            Game.SingletonRepository.ShopkeeperLessThanGuessComments.PersistEntities();
            Game.SingletonRepository.ShopkeeperWorthlessComments.PersistEntities();
            Game.SingletonRepository.SingingPlayerAttacks.PersistEntities();
            Game.SingletonRepository.WorshipPlayerAttacks.PersistEntities();

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
