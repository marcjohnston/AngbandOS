namespace AngbandOS.Commands
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
            int numDoors = saveGame.CountClosedDoors(coord);
            int numChests = saveGame.CountChests(coord, false);
            if (numDoors != 0 || numChests != 0)
            {
                bool tooMany = (numDoors != 0 && numChests != 0) || numDoors > 1 || numChests > 1;
                if (!tooMany)
                {
                    // There's only one thing we can open, so assume we mean that thing
                    saveGame.CommandDirection = saveGame.Level.CoordsToDir(coord.Y, coord.X);
                }
            }
            // If we don't already have a direction, prompt for one
            if (saveGame.GetDirectionNoAim(out int dir))
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[y][x];
                int itemIndex = saveGame.Level.ChestCheck(y, x);
                // Make sure there is something to open in the direction we chose
                if (!tile.FeatureType.IsClosedDoor &&
                    itemIndex == 0)
                {
                    saveGame.MsgPrint("You see nothing there to open.");
                }
                // Can't open something if there's a monster in the way
                else if (tile.MonsterIndex != 0)
                {
                    saveGame.EnergyUse = 100;
                    saveGame.MsgPrint("There is a monster in the way!");
                    saveGame.PlayerAttackMonster(y, x);
                }
                // Open the chest or door
                else if (itemIndex != 0)
                {
                    disturb = OpenChestAtGivenLocation(saveGame, y, x, itemIndex);
                }
                else
                {
                    disturb = saveGame.OpenDoor(y, x);
                }
            }
            if (!disturb)
            {
                saveGame.Disturb(false);
            }
        }

        /// <summary>
        /// Open a chest at a given location
        /// </summary>
        /// <param name="y"> The y coordinate of the location </param>
        /// <param name="x"> The x coordinate of the location </param>
        /// <param name="itemIndex"> The index of the chest item </param>
        /// <returns> Whether or not the player should be disturbed by the action </returns>
        private bool OpenChestAtGivenLocation(SaveGame saveGame, int y, int x, int itemIndex)
        {
            bool openedSuccessfully = true;
            bool more = false;
            Item item = saveGame.Level.Items[itemIndex];
            // Opening a chest takes an action
            saveGame.EnergyUse = 100;
            // If the chest is locked, we may need to pick it
            if (item.TypeSpecificValue > 0)
            {
                openedSuccessfully = false;
                // Our disable traps skill also doubles up as a lockpicking skill
                int i = saveGame.Player.SkillDisarmTraps;
                // Hard to pick locks in the dark
                if (saveGame.Player.TimedBlindness != 0 || saveGame.Level.NoLight())
                {
                    i /= 10;
                }
                // Hard to pick locks when you're confused or hallucinating
                if (saveGame.Player.TimedConfusion != 0 || saveGame.Player.TimedHallucinations != 0)
                {
                    i /= 10;
                }
                // Some locks are harder to pick than others
                int j = i - item.TypeSpecificValue;
                if (j < 2)
                {
                    j = 2;
                }
                // See if we succeeded
                if (Program.Rng.RandomLessThan(100) < j)
                {
                    saveGame.MsgPrint("You have picked the lock.");
                    saveGame.Player.GainExperience(1);
                    openedSuccessfully = true;
                }
                else
                {
                    more = true;
                    saveGame.MsgPrint("You failed to pick the lock.");
                }
            }
            // If we successfully opened it, set of any traps and then actually open the chest
            if (openedSuccessfully)
            {
                saveGame.ChestTrap(y, x, itemIndex);
                saveGame.OpenChest(y, x, itemIndex);
            }
            return more;
        }
    }
}
