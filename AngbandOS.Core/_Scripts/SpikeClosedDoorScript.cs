// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpikeClosedDoorScript : UniversalScript
{
    private SpikeClosedDoorScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the spike closed door script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        // Get the location to be spiked
        if (Game.GetDirectionNoAim(out int dir))
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Map.Grid[y][x];
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

                Item? item = Game.GetInventoryItem(itemIndex);
                if (item == null)
                {
                    Game.MsgPrint("There are no spikes here.");
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
                        Tile? jammedTile = Game.SingletonRepository.Get<Tile>(nameof(JammedDoor0Tile));
                        if (jammedTile == null)
                        {
                            throw new Exception("No jammed door specified.");
                        }
                        tile.SetFeature(jammedTile);
                    }

                    // Use up the spike from the player's inventory
                    item.ModifyStackCount(-1);
                    Game.InvenItemDescribe(itemIndex);
                    Game.InvenItemOptimize(itemIndex);
                }
            }
        }
   }
}
