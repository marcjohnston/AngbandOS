// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class GameCommandUniversalScript : IGameCommandScript, IScript, ICastSpellScript, IStoreCommandScript, IGetKey
{
    protected readonly Game Game;
    protected GameCommandUniversalScript(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public virtual string LearnedDetails => "";
    public abstract RepeatableResultEnum ExecuteGameCommandScript();

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public virtual void Bind() { }

    #region Adapters
    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteGameCommandScript();
    }
    public void ExecuteScript()
    {
        ExecuteGameCommandScript();
    }
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteGameCommandScript();
    }
    #endregion
}
