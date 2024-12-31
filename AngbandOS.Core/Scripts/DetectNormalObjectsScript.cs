// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Reveals normal objects that are within the viewport.
/// </summary>
[Serializable]
internal class DetectNormalObjectsScript : Script, IScript, ISuccessByChanceScript, IIdentifiedAndUsedScript
{
    private DetectNormalObjectsScript(Game game) : base(game) { }

    public bool ExecuteSuccessByChanceScript()
    {
        bool detect = false;
        for (int y = 1; y < Game.CurHgt - 1; y++)
        {
            for (int x = 1; x < Game.CurWid - 1; x++)
            {
                GridTile cPtr = Game.Map.Grid[y][x];
                foreach (Item oPtr in cPtr.Items)
                {
                    if (!Game.PanelContains(y, x))
                    {
                        continue;
                    }
                    if (oPtr.GoldPieces == 0)
                    {
                        oPtr.WasNoticed = true;
                        Game.MainForm.RefreshMapLocation(y, x);
                        detect = true;
                    }
                }
            }
        }
        if (detect)
        {
            Game.MsgPrint("You sense the presence of objects!");
        }
        if (Game.DetectMonstersString("!=?|"))
        {
            detect = true;
        }
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

    public (bool identified, bool used) ExecuteIdentifiedAndUsedScript()
    {
        bool identified = ExecuteSuccessByChanceScript();
        return (identified, true);
    }
}
