// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal abstract class ProjectileWeightedRandomScript : GenericWeightedRandom<ProjectileScript>, IProjectile
{
    protected ProjectileWeightedRandomScript(Game game) : base(game) { }


    public bool ExecuteDirectionalActivationScript(Item item, int direction)
    {
        return Choose().ExecuteDirectionalActivationScript(item, direction);
    }

    public IdentifiedResult ExecuteIdentifiedScriptDirection(int dir)
    {
        return Choose().ExecuteIdentifiedScriptDirection(dir);
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        return Choose().ExecuteZapRodScript(item, dir);
    }

    public void ExecuteScript()
    {
        Choose().ExecuteScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollAndUseStaffScript()
    {
        return Choose().ExecuteReadScrollAndUseStaffScript();
    }

    public bool ExecuteUsedScriptItem(Item item)
    {
        return Choose().ExecuteUsedScriptItem(item);
    }

    public bool ExecuteSuccessByChanceScript()
    {
        return Choose().ExecuteSuccessByChanceScript();
    }
}
