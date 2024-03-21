// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DestroyAdjacentDoorsScript : Script, IScript, ISuccessfulScript, ICancellableScript
{
    private DestroyAdjacentDoorsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Runs the successful script and returns true because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScript()
    {
        ExecuteSuccessfulScript();
        return true;
    }

    /// <summary>
    /// Projects the kill door to the current location with a radius of 1 to destory all doors that are adjacent to the player.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectHide;
        return SaveGame.Project(0, 1, SaveGame.MapY, SaveGame.MapX, 0, SaveGame.SingletonRepository.Projectiles.Get(nameof(KillDoorProjectile)), flg);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
