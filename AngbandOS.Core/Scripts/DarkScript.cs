// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DarkScript : Script, IScript
{
    private DarkScript(Game game) : base(game) { }

    /// <summary>
    /// Darkens the map.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int y = 0; y < Game.CurHgt; y++)
        {
            for (int x = 0; x < Game.CurWid; x++)
            {
                GridTile cPtr = Game.Map.Grid[y][x];
                cPtr.PlayerMemorized = false;
                foreach (Item oPtr in cPtr.Items)
                {
                    oPtr.Marked = false;
                }
            }
        }
        Game.SingletonRepository.FlaggedActions.Get(nameof(RemoveLightFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(RemoveViewFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
    }
}
