// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WallOfStoneScript : Script, IScript
{
    private WallOfStoneScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem;
        SaveGame.Project(0, 1, SaveGame.MapY, SaveGame.MapX, 0, SaveGame.SingletonRepository.Projectiles.Get(nameof(StoneWallProjectile)), flg);
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateScentFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
    }
}
