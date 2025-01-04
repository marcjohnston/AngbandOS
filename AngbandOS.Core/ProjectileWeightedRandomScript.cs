// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class ProjectileWeightedRandomScript : GenericWeightedRandom<ProjectileScript>, IUniversalScript // DO NOT ADD MORE INTERFACES HERE, ADD IT TO THE IPROJECTILE
{
    protected ProjectileWeightedRandomScript(Game game) : base(game) { }


    public UsedResult ExecuteDirectionalActivationScript(Item item, int direction)
    {
        return Choose().ExecuteDirectionalActivationScript(item, direction);
    }

    public IdentifiedResult ExecuteAimWandScript(int dir)
    {
        return Choose().ExecuteAimWandScript(dir);
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        return Choose().ExecuteZapRodScript(item, dir);
    }

    public void ExecuteScript()
    {
        Choose().ExecuteScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        return Choose().ExecuteReadScrollOrUseStaffScript();
    }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        return Choose().ExecuteActivateItemScript(item);
    }

    public bool ExecuteSuccessByChanceScript()
    {
        return Choose().ExecuteSuccessByChanceScript();
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        Choose().ExecuteCastSpellScript(spell);
    }
}
