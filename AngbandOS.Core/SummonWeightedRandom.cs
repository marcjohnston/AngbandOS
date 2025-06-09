// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class SummonWeightedRandom : GenericWeightedRandom<SummonScript>, IUniversalScript
{
    protected SummonWeightedRandom(Game game) : base(game) { }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        return Choose().ExecuteActivateItemScript(item);
    }

    public IdentifiedResult ExecuteAimWandScript(int dir)
    {
        return Choose().ExecuteAimWandScript(dir);
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        Choose().ExecuteCastSpellScript(spell);
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        return Choose().ExecuteReadScrollOrUseStaffScript();
    }

    public void ExecuteScript()
    {
        Choose().ExecuteScript();
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        return Choose().ExecuteZapRodScript(item, dir);
    }

    /// <summary>
    /// Returns information about the spell, or blank if there is no detailed information.  Returns blank, by default.  Returns blank, by default.
    /// </summary>
    public virtual string LearnedDetails => "";
}
