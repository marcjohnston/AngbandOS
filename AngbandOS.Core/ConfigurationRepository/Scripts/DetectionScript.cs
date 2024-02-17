// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectionScript : Script, IScript, ISuccessfulScript
{
    private DetectionScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Detects traps, doors, stairs, treasures, gold, normal objects, normal monsters and invisible monsters and returns true, if anything was detected; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        bool detect = SaveGame.DetectTraps();
        detect |= SaveGame.DetectDoors();
        detect |= SaveGame.DetectStairs();
        detect |= SaveGame.DetectTreasure();
        detect |= SaveGame.DetectObjectsGold();
        detect |= SaveGame.DetectObjectsNormal();
        detect |= SaveGame.DetectMonstersInvis();
        detect |= SaveGame.RunSuccessfulScript(nameof(DetectNormalMonstersScript));
        return detect;
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
