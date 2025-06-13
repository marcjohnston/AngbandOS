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
internal class DetectNormalObjectsScript : Script, IScript, ICastSpellScript, IEatOrQuaffScript, IReadScrollOrUseStaffScript
{
    private DetectNormalObjectsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        bool isIdentified = false;
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
                        Game.ConsoleView.RefreshMapLocation(y, x);
                        isIdentified = true;
                    }
                }
            }
        }
        if (isIdentified)
        {
            Game.MsgPrint("You sense the presence of objects!");
        }
        if (Game.DetectMonstersString("!=?|"))
        {
            isIdentified = true;
        }
        return new IdentifiedResult(isIdentified);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        IdentifiedResult identifiedResult = ExecuteEatOrQuaffScript();
        return new IdentifiedAndUsedResult(identifiedResult, true);
    }
    public string LearnedDetails => "";
}
