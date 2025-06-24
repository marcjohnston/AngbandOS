// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class UsedResultUniversalScript : IScript, ICastSpellScript, IActivateItemScript, IAimWandScript, IZapRodScript, IReadScrollOrUseStaffScript, IEatOrQuaffScript, IStoreCommandScript, IGameCommandScript
{
    protected readonly Game Game;

    protected UsedResultUniversalScript(Game game)
    {
        Game = game;
    }

    public string LearnedDetails => throw new NotImplementedException();

    /// <summary>
    /// Run the associated script and return false, if the script is cancelled; true, otherwise.  A script is considered to have been run if it fails by chance.  A script is considered cancelled
    /// if the player doesn't have an item for the script to run against, or the player cancels an item or other selection.
    /// </summary>
    /// <returns></returns>
    public abstract UsedResultEnum ExecuteUsedScript();

    public virtual RepeatableResultEnum RepeatableResult { get; } = RepeatableResultEnum.False;
    /// <summary>
    /// Returns true, if the script identifies the item; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual IdentifiedResultEnum IdentifiesItem { get; } = IdentifiedResultEnum.False;
    public virtual bool RequiresRerendering { get; } = false;

    #region Adapters
    public void ExecuteScript()
    {
        ExecuteUsedScript();
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteUsedScript();
    }

    public UsedResultEnum ExecuteActivateItemScript(Item item)
    {
        return ExecuteUsedScript();
    }

    public IdentifiedResultEnum ExecuteAimWandScript(int dir)
    {
        ExecuteUsedScript();
        return IdentifiesItem;
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        UsedResultEnum usedResult = ExecuteUsedScript();
        return new IdentifiedAndUsedResult(IdentifiesItem, usedResult);
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        UsedResultEnum usedResult = ExecuteUsedScript();
        return new IdentifiedAndUsedResult(IdentifiesItem, usedResult);
    }

    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        ExecuteUsedScript();
        return IdentifiesItem;
    }

    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteUsedScript();
        storeCommandEvent.RequiresRerendering = RequiresRerendering;
    }

    public RepeatableResultEnum ExecuteGameCommandScript()
    {
        ExecuteUsedScript();
        return RepeatableResult;
    }
    #endregion
}
