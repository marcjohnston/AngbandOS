// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an eat or quaff script (a call with no parameters that returns an IdentifiedResult) with adapters for the other calling mechanisms.
/// </summary>
[Serializable]
internal abstract class EatOrQuaffScript : IActivateItemScript, IAimWandScript, IZapRodScript, IScript, IReadScrollOrUseStaffScript, ICastSpellScript, IEatOrQuaffScript
{
    protected readonly Game Game;
    protected EatOrQuaffScript(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the details to reveal to the player when learned.  Returns blank, by default.
    /// </summary>
    public virtual string LearnedDetails => "";

    /// <summary>
    /// Returns true, if the timer update should be done with no notification to the player; false, for normal operation.  When true, the identified
    /// return value is always false.
    /// </summary>
    public virtual bool UsesItem { get; }


    public UsedResult ExecuteActivateItemScript(Item item)
    {
        ExecuteEatOrQuaffScript();
        return new UsedResult(UsesItem);
    }

    public IdentifiedResult ExecuteAimWandScript(int dir)
    {
        return ExecuteEatOrQuaffScript();
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteEatOrQuaffScript();
    }

    public abstract IdentifiedResult ExecuteEatOrQuaffScript();

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        IdentifiedResult identified = ExecuteEatOrQuaffScript();
        return new IdentifiedAndUsedResult(identified, UsesItem);
    }

    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        return ExecuteReadScrollOrUseStaffScript();
    }
}
