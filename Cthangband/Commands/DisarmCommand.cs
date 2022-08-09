using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Attempt to disarm a trap on a door or chest
    /// </summary>
    [Serializable]
    internal class DisarmCommand : ICommand
    {
        public char Key => 'D';

        public int? Repeat => 99;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            bool disturb = false;
            MapCoordinate coord = new MapCoordinate();
            int numTraps =
                SaveGame.Instance.CountKnownTraps(coord);
            int numChests = SaveGame.Instance.CountChests(coord, true);
            // Count the possible traps and chests we might want to disarm
            if (numTraps != 0 || numChests != 0)
            {
                bool tooMany = (numTraps != 0 && numChests != 0) || numTraps > 1 || numChests > 1;
                // If only one then we have our target
                if (!tooMany)
                {
                    Gui.CommandDirection = saveGame.Level.CoordsToDir(coord.Y, coord.X);
                }
            }
            // Get a direction if we don't already have one
            if (targetEngine.GetDirectionNoAim(out int dir))
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[y][x];
                // Check for a chest
                int itemIndex = saveGame.Level.ChestCheck(y, x);
                if (!tile.FeatureType.IsTrap &&
                    itemIndex == 0)
                {
                    SaveGame.Instance.MsgPrint("You see nothing there to disarm.");
                }
                // Can't disarm with a monster in the way
                else if (tile.MonsterIndex != 0)
                {
                    SaveGame.Instance.MsgPrint("There is a monster in the way!");
                    SaveGame.Instance.PlayerAttackMonster(y, x);
                }
                // Disarm the chest or trap
                else if (itemIndex != 0)
                {
                    disturb = SaveGame.Instance.DisarmChest(y, x, itemIndex);
                }
                else
                {
                    disturb = SaveGame.Instance.DisarmTrap(y, x, dir);
                }
            }
            if (!disturb)
            {
                SaveGame.Instance.Disturb(false);
            }
        }
    }
}
