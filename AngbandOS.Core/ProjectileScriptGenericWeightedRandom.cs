// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal abstract class ProjectileScriptGenericWeightedRandom : GenericWeightedRandom<ProjectileScript>, IDirectionalCancellableScriptItem, IIdentifableDirectionalScript, IIdentifiedAndUsedScriptItemDirection, IScript
{
    protected ProjectileScriptGenericWeightedRandom(Game game) : base(game) { }


    public bool ExecuteCancellableScriptItem(Item item, int direction)
    {
        return Choose().ExecuteCancellableScriptItem(item, direction);
    }

    public bool ExecuteIdentifableDirectionalScript(int dir)
    {
        return Choose().ExecuteIdentifableDirectionalScript(dir);
    }

    public (bool identified, bool used) ExecuteIdentifiedAndUsedScriptItemDirection(Item item, int dir)
    {
        return Choose().ExecuteIdentifiedAndUsedScriptItemDirection(item, dir);
    }

    public void ExecuteScript()
    {
        Choose().ExecuteScript();
    }
}
