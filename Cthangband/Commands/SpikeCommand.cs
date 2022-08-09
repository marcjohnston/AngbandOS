using Cthangband.Enumerations;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Spike a door closed
    /// </summary>
    [Serializable]
    internal class SpikeCommand : ICommand
    {
        public char Key => 'j';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            // Get the location to be spiked
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            if (targetEngine.GetDirectionNoAim(out int dir))
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[y][x];
                // Make sure it can be spiked and we have spikes to do it with
                if (!tile.FeatureType.IsClosedDoor)
                {
                    SaveGame.Instance.MsgPrint("You see nothing there to spike.");
                }
                else
                {
                    if (!SaveGame.Instance.GetSpike(out int itemIndex))
                    {
                        SaveGame.Instance.MsgPrint("You have no spikes!");
                    }
                    // Can't close a door if there's someone in the way
                    else if (tile.MonsterIndex != 0)
                    {
                        // Attempting costs a turn anyway
                        SaveGame.Instance.EnergyUse = 100;
                        SaveGame.Instance.MsgPrint("There is a monster in the way!");
                        SaveGame.Instance.PlayerAttackMonster(y, x);
                    }
                    else
                    {
                        // Spiking a door costs a turn
                        SaveGame.Instance.EnergyUse = 100;
                        SaveGame.Instance.MsgPrint("You jam the door with a spike.");
                        // Replace the door feature with a jammed door
                        if (tile.FeatureType.Category == FloorTileTypeCategory.LockedDoor)
                        {
                            tile.SetFeature(tile.FeatureType.Name.Replace("Locked", "Jammed"));
                        }
                        // If it's already jammed, strengthen it
                        if (tile.FeatureType.Category == FloorTileTypeCategory.JammedDoor)
                        {
                            int strength = int.Parse(tile.FeatureType.Name.Substring(10));
                            if (strength < 7)
                            {
                                tile.SetFeature($"JammedDoor{strength + 1}");
                            }
                        }
                        // Use up the spike from the player's inventory
                        saveGame.Player.Inventory.InvenItemIncrease(itemIndex, -1);
                        saveGame.Player.Inventory.InvenItemDescribe(itemIndex);
                        saveGame.Player.Inventory.InvenItemOptimize(itemIndex);
                    }
                }
            }
        }

    }
}
