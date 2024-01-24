// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WizardLearnScript : Script, IScript
{
    private WizardLearnScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the learn script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        foreach (ItemFactory kPtr in SaveGame.SingletonRepository.ItemFactories)
        {
            if (kPtr.Level <= SaveGame.CommandArgument)
            {
                kPtr.FlavourAware = true;
            }
        }
    }
}
