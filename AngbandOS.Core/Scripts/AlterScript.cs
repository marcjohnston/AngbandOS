// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AlterScript : Script, IScript, IRepeatableScript
{
    private AlterScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the alter script and disposes of the successful result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteRepeatableScript();
    }

    /// <summary>
    /// Gets a direction from the player and alters the tile in that direction.  Returns false, if the action fails due to chance.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        // Assume we won't disturb the player
        bool more = false;

        // Get the direction in which to alter something
        if (SaveGame.GetDirectionNoAim(out int dir))
        {
            int y = SaveGame.MapY + SaveGame.KeypadDirectionYOffset[dir];
            int x = SaveGame.MapX + SaveGame.KeypadDirectionXOffset[dir];
            GridTile tile = SaveGame.Grid[y][x];
            // Altering a tile will take a turn
            SaveGame.EnergyUse = 100;
            // We 'alter' a tile by attacking it
            if (tile.MonsterIndex != 0)
            {
                SaveGame.PlayerAttackMonster(y, x);
            }
            else
            {
                // Check the action based on the type of tile
                AlterAction? alterAction = tile.FeatureType.AlterAction;
                if (alterAction == null)
                {
                    SaveGame.MsgPrint("You're not sure what you can do with that...");
                }
                else
                {
                    AlterEventArgs alterEventArgs = new AlterEventArgs(y, x);
                    alterAction.Execute(alterEventArgs);
                    more = alterEventArgs.More;
                }
            }
        }
        return more;
    }
}
