// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class NoopScript : Script, IScript, IRepeatableScript, IStoreScript
{
    private NoopScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the no-op script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
    }

    /// <summary>
    /// Returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        return false;
    }

    /// <summary>
    /// Does nothing.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
    }
}
