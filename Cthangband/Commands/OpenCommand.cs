using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Open a door or chest
    /// </summary>
    [Serializable]
    internal class OpenCommand : ICommand
    {
        public char Key => 'o';

        public int? Repeat => 99;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            bool disturb = false;
            // Check if there's only one thing we can open
            MapCoordinate coord = new MapCoordinate();
            int numDoors =
                SaveGame.Instance.CountClosedDoors(coord);
            int numChests = SaveGame.Instance.CountChests(coord, false);
            if (numDoors != 0 || numChests != 0)
            {
                bool tooMany = (numDoors != 0 && numChests != 0) || numDoors > 1 || numChests > 1;
                if (!tooMany)
                {
                    // There's only one thing we can open, so assume we mean that thing
                    Gui.CommandDirection = saveGame.Level.CoordsToDir(coord.Y, coord.X);
                }
            }
            // If we don't already have a direction, prompt for one
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            if (targetEngine.GetDirectionNoAim(out int dir))
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[y][x];
                int itemIndex = saveGame.Level.ChestCheck(y, x);
                // Make sure there is something to open in the direction we chose
                if (!tile.FeatureType.IsClosedDoor &&
                    itemIndex == 0)
                {
                    Profile.Instance.MsgPrint("You see nothing there to open.");
                }
                // Can't open something if there's a monster in the way
                else if (tile.MonsterIndex != 0)
                {
                    SaveGame.Instance.EnergyUse = 100;
                    Profile.Instance.MsgPrint("There is a monster in the way!");
                    SaveGame.Instance.PlayerAttackMonster(y, x);
                }
                // Open the chest or door
                else if (itemIndex != 0)
                {
                    disturb = SaveGame.Instance.OpenChestAtGivenLocation(y, x, itemIndex);
                }
                else
                {
                    disturb = SaveGame.Instance.OpenDoor(y, x);
                }
            }
            if (!disturb)
            {
                SaveGame.Instance.Disturb(false);
            }
        }

    }
}
