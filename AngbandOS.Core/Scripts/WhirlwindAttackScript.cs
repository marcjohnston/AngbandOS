// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WhirlwindAttackScript : Script, IScript
{
    private WhirlwindAttackScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int dir = 0; dir <= 9; dir++)
        {
            int y = SaveGame.MapY + SaveGame.KeypadDirectionYOffset[dir];
            int x = SaveGame.MapX + SaveGame.KeypadDirectionXOffset[dir];
            GridTile cPtr = SaveGame.Grid[y][x];
            Monster mPtr = SaveGame.Monsters[cPtr.MonsterIndex];
            if (cPtr.MonsterIndex != 0 && (mPtr.IsVisible || SaveGame.GridPassable(y, x)))
            {
                SaveGame.PlayerAttackMonster(y, x);
            }
        }
    }
}
