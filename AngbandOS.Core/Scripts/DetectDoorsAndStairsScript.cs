// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectDoorsAndStairsScript : Script, IIdentifiedAndUsedScriptItemDirection, IIdentifableAndUsedScript
{
    private DetectDoorsAndStairsScript(Game game) : base(game) { }

    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        bool identified = false;
        if (Game.DetectDoors())
        {
            identified = true;
        }
        if (Game.DetectStairs())
        {
            identified = true;
        }
        return (identified, true);
    }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifiedAndUsedScriptItemDirection(Item item, int dir)
    {
        return ExecuteIdentifableAndUsedScript();
    }
}
