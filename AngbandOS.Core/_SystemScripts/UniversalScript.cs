// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]

internal abstract class UniversalScript : IActivateItemScript, IAimWandScript, IZapRodScript, IScript, IReadScrollOrUseStaffScript, ICastSpellScript, IEatOrQuaffScript, IGameCommandScript, IStoreCommandScript
{
    protected readonly Game Game;
    protected UniversalScript(Game game)
    {
        Game = game;
    }

    public virtual bool RequiresRerendering { get; } = false;

    /// <summary>
    /// Returns information about this message, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public virtual string LearnedDetails => "";

    /// <summary>
    /// Returns true, if the script uses the item; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool UsesItem { get; } = false;

    public virtual RepeatableResultEnum RepeatableResult { get; } = RepeatableResultEnum.False;

    /// <summary>
    /// Returns true, if the script identifies the item; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool IdentifiesItem { get; } = false;

    public abstract void ExecuteScript();

    #region Adapters
    public UsedResultEnum ExecuteActivateItemScript(Item item)
    {
        ExecuteScript();
        return UsesItem ? UsedResultEnum.True : UsedResultEnum.False;
    }

    public IdentifiedResultEnum ExecuteAimWandScript(int dir)
    {
        ExecuteScript();
        return IdentifiesItem ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        ExecuteScript();
        return new IdentifiedAndUsedResult(IdentifiesItem, UsesItem);
    }
    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        ExecuteScript();
        return new IdentifiedAndUsedResult(IdentifiesItem, UsesItem);
    }
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        ExecuteScript();
        return IdentifiesItem ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
    public RepeatableResultEnum ExecuteGameCommandScript()
    {
        ExecuteScript();
        return RepeatableResult;
    }
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
        storeCommandEvent.RequiresRerendering = RequiresRerendering;
    }
    #endregion
}
