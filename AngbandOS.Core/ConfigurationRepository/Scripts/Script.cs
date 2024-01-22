// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal abstract class Script : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected Script(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public virtual void Bind() { }

    /// <summary>
    /// Execute the script and return true, if the script fails due to chance; otherwise, false is returned.  A true return value indicates to the parent, that if the script/process is repeated, the process may succeed.
    /// </summary>
    /// <returns></returns>
    public abstract bool Execute();
}
