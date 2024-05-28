// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DestroyAdjacentDoorsScript : Script, IScript, ISuccessByChanceScript, ICancellableScript
{
    private DestroyAdjacentDoorsScript(Game game) : base(game) { }

    /// <summary>
    /// Runs the successful script and returns false because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScript()
    {
        ExecuteSuccessByChanceScript();
        return false;
    }

    /// <summary>
    /// Projects the kill door to the current location with a radius of 1 to destory all doors that are adjacent to the player.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectHide;
        return Game.Project(0, 1, Game.MapY.IntValue, Game.MapX.IntValue, 0, Game.SingletonRepository.Get<Projectile>(nameof(DestroyTrapOrDoorProjectile)), flg);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }
}
