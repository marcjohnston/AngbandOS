// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectionScript : Script, IScript, ISuccessByChanceScript
{
    private DetectionScript(Game game) : base(game) { }

    /// <summary>
    /// Detects traps, doors, stairs, treasures, gold, normal objects, normal monsters and invisible monsters and returns true, if anything was detected; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        bool detect = Game.DetectTraps();
        detect |= Game.DetectDoors();
        detect |= Game.DetectStairs();
        detect |= Game.DetectTreasure();
        detect |= Game.DetectObjectsGold();
        detect |= Game.RunSuccessfulScript(nameof(DetectNormalObjectsScript));
        detect |= Game.DetectMonstersInvis();
        detect |= Game.RunSuccessfulScript(nameof(DetectNormalMonstersScript));
        return detect;
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
