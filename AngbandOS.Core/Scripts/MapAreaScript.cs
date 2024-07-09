// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MapAreaScript : Script, IScript, IIdentifableAndUsedScript
{
    private MapAreaScript(Game game) : base(game) { }

    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        ExecuteScript();
        return (true, true);
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int y1 = Game.PanelRowMin - Game.DieRoll(10);
        int y2 = Game.PanelRowMax + Game.DieRoll(10);
        int x1 = Game.PanelColMin - Game.DieRoll(20);
        int x2 = Game.PanelColMax + Game.DieRoll(20);
        if (y1 < 1)
        {
            y1 = 1;
        }
        if (y2 > Game.CurHgt - 2)
        {
            y2 = Game.CurHgt - 2;
        }
        if (x1 < 1)
        {
            x1 = 1;
        }
        if (x2 > Game.CurWid - 2)
        {
            x2 = Game.CurWid - 2;
        }
        for (int y = y1; y <= y2; y++)
        {
            for (int x = x1; x <= x2; x++)
            {
                GridTile cPtr = Game.Map.Grid[y][x];
                if (!cPtr.FeatureType.IsWall)
                {
                    if (!cPtr.FeatureType.IsOpenFloor)
                    {
                        cPtr.PlayerMemorized = true;
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        cPtr = Game.Map.Grid[y + Game.OrderedDirectionYOffset[i]][x + Game.OrderedDirectionXOffset[i]];
                        if (cPtr.FeatureType.IsWall)
                        {
                            cPtr.PlayerMemorized = true;
                        }
                    }
                }
            }
        }
        Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
    }
}
