// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpikeClosedDoorScript : Script, IScript, IRepeatableScript
{
    private SpikeClosedDoorScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the spike closed door script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the spike closed door script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Get the location to be spiked
        if (Game.GetDirectionNoAim(out int dir))
        {
            int y = Game.MapY.Value + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX.Value + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Grid[y][x];
            // Make sure it can be spiked and we have spikes to do it with
            if (!tile.FeatureType.IsVisibleDoor)
            {
                Game.MsgPrint("You see nothing there to spike.");
            }
            else
            {
                if (!Game.GetSpike(out int itemIndex))
                {
                    Game.MsgPrint("You have no spikes!");
                }
                // Can't close a door if there's someone in the way
                else if (tile.MonsterIndex != 0)
                {
                    // Attempting costs a turn anyway
                    Game.EnergyUse = 100;
                    Game.MsgPrint("There is a monster in the way!");
                    Game.PlayerAttackMonster(y, x);
                }
                else
                {
                    // Spiking a door costs a turn
                    Game.EnergyUse = 100;
                    Game.MsgPrint("You jam the door with a spike.");
                    // Replace the door feature with a jammed door
                    if (tile.FeatureType.IsVisibleDoor)
                    {
                        Tile? jammedTile = Game.SingletonRepository.Tiles.Get(nameof(JammedDoor0Tile));
                        if (jammedTile == null)
                        {
                            throw new Exception("No jammed door specified.");
                        }
                        tile.SetFeature(jammedTile);
                    }

                    // Use up the spike from the player's inventory
                    Game.InvenItemIncrease(itemIndex, -1);
                    Game.InvenItemDescribe(itemIndex);
                    Game.InvenItemOptimize(itemIndex);
                }
            }
        }
   }
}
