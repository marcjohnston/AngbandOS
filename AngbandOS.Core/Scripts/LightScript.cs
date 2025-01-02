// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class LightScript : Script, IScript, ICastSpellScript
{
    private LightScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Lights the map.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int y = 1; y < Game.CurHgt - 1; y++)
        {
            for (int x = 1; x < Game.CurWid - 1; x++)
            {
                GridTile cPtr = Game.Map.Grid[y][x];
                if (!cPtr.FeatureType.IsWall)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        int yy = y + Game.OrderedDirectionYOffset[i];
                        int xx = x + Game.OrderedDirectionXOffset[i];
                        cPtr = Game.Map.Grid[yy][xx];
                        cPtr.SelfLit = true;
                        if (!cPtr.FeatureType.IsOpenFloor)
                        {
                            cPtr.PlayerMemorized = true;
                        }
                        cPtr.PlayerMemorized = true;
                    }
                }
                foreach (Item oPtr in cPtr.Items)
                {
                    oPtr.WasNoticed = true;
                }
            }
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
    }
}
