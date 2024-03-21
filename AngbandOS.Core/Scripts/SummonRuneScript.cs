// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonRuneScript : Script, IScript
{
    private SummonRuneScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        GridTile tile = SaveGame.Grid[SaveGame.MapY][SaveGame.MapX];
        SaveGame.MsgPrint("There is a flash of shimmering light!");
        // Trap disappears when triggered
        tile.TileFlags.Clear(GridTile.PlayerMemorized);
        SaveGame.RevertTileToBackground(SaveGame.MapY, SaveGame.MapX);
        // Summon 1d3+2 monsters
        int num = 2 + SaveGame.DieRoll(3);
        for (int i = 0; i < num; i++)
        {
            SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty, null);
        }
        // Have a chance of also cursing the player
        if (SaveGame.Difficulty > SaveGame.DieRoll(100))
        {
            do
            {
                SaveGame.ActivateDreadCurse();
            } while (SaveGame.DieRoll(6) == 1);
        }
    }
}
