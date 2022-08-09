using Cthangband.Enumerations;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Alter a tile in a 'sensibe' way given the tile type
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"> </exception>
    [Serializable]
    internal class AlterCommand : ICommand
    {
        public char Key => '+';

        public int? Repeat => 99;
        
        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            // Assume we won't disturb the player
            bool disturb = false;
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);

            // Get the direction in which to alter something
            if (targetEngine.GetDirectionNoAim(out int dir))
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[y][x];
                // Altering a tile will take a turn
                SaveGame.Instance.EnergyUse = 100;
                // We 'alter' a tile by attacking it
                if (tile.MonsterIndex != 0)
                {
                    SaveGame.Instance.PlayerAttackMonster(y, x);
                }
                else
                {
                    // Check the action based on the type of tile
                    switch (tile.FeatureType.AlterAction)
                    {
                        case FloorTileAlterAction.Nothing:
                            SaveGame.Instance.MsgPrint("You're not sure what you can do with that...");
                            break;

                        case FloorTileAlterAction.Tunnel:
                            disturb = SaveGame.Instance.TunnelThroughTile(y, x);
                            break;

                        case FloorTileAlterAction.Disarm:
                            disturb = SaveGame.Instance.DisarmTrap(y, x, dir);
                            break;

                        case FloorTileAlterAction.Open:
                            disturb = SaveGame.Instance.OpenDoor(y, x);
                            break;

                        case FloorTileAlterAction.Close:
                            disturb = SaveGame.Instance.CloseDoor(y, x);
                            break;

                        case FloorTileAlterAction.Bash:
                            disturb = SaveGame.Instance.BashClosedDoor(y, x, dir);
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            if (!disturb)
            {
                SaveGame.Instance.Disturb(false);
            }
        }
    }
}
