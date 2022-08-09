using Cthangband.Enumerations;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Close a door
    /// </summary>
    [Serializable]
    internal class CloseCommand : ICommand
    {
        public char Key => 'c';

        public int? Repeat => 99;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            MapCoordinate coord = new MapCoordinate();
            bool disturb = false;
            // If there's only one door, assume we mean that one and don't ask for a direction
            if (saveGame.CountOpenDoors(coord) == 1)
            {
                Gui.CommandDirection = saveGame.Level.CoordsToDir(coord.Y, coord.X);
            }
            // Get the location to close
            if (targetEngine.GetDirectionNoAim(out int dir))
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[y][x];
                // Can only close actual open doors
                if (tile.FeatureType.Category != FloorTileTypeCategory.OpenDoorway)
                {
                    saveGame.MsgPrint("You see nothing there to close.");
                }
                // Can't close if there's a monster in the way
                else if (tile.MonsterIndex != 0)
                {
                    saveGame.EnergyUse = 100;
                    saveGame.MsgPrint("There is a monster in the way!");
                    saveGame.PlayerAttackMonster(y, x);
                }
                // Actually close the door
                else
                {
                    disturb = saveGame.CloseDoor(y, x);
                }
            }
            if (!disturb)
            {
                saveGame.Disturb(false);
            }
        }
    }
}
