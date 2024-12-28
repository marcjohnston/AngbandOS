// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CharmAnimalScript : Script, IScript, IScriptInt, ICancellableScriptItem
{
    private CharmAnimalScript(Game game) : base(game) { }

    /// <summary>
    /// Runs the script and returns true because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScriptItem(Item item)
    {
        ExecuteScript();
        return true;
    }

    public void ExecuteScriptInt(int damage)
    {
        Game.ProjectAtAllInLos(Game.SingletonRepository.Get<Projectile>(nameof(ControlAnimalProjectile)), damage);
    }

    /// <summary>
    /// Executes the Int script with a damage rating of the player experience level * 2.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteScriptInt(Game.ExperienceLevel.IntValue * 2);
    }
}
