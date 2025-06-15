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
internal abstract class EatOrQuaffUniversalScript : IUniversalScript
{
    protected readonly Game Game;
    protected EatOrQuaffUniversalScript(Game game)
    {
        Game = game;
    }
    public virtual string LearnedDetails => "";
    public abstract bool UsesItem { get; }

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
