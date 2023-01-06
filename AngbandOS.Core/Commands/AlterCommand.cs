namespace AngbandOS.Commands
{
    /// <summary>
    /// Alter a tile in a 'sensibe' way given the tile type
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"> </exception>
    [Serializable]
    internal class AlterCommand : ICommand
    {
        private AlterCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => '+';

        public int? Repeat => 99;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            // Assume we won't disturb the player
            bool disturb = false;

            // Get the direction in which to alter something
            if (saveGame.GetDirectionNoAim(out int dir))
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[y][x];
                // Altering a tile will take a turn
                saveGame.EnergyUse = 100;
                // We 'alter' a tile by attacking it
                if (tile.MonsterIndex != 0)
                {
                    saveGame.PlayerAttackMonster(y, x);
                }
                else
                {
                    // Check the action based on the type of tile
                    AlterAction? alterAction = tile.FeatureType.AlterAction;
                    if (alterAction == null)
                    {
                        saveGame.MsgPrint("You're not sure what you can do with that...");
                    }
                    else
                    {
                        AlterEventArgs alterEventArgs = new AlterEventArgs(saveGame, y, x);
                        alterAction.Execute(alterEventArgs);
                        disturb = alterEventArgs.Disturbed;
                    }
                }
            }

            if (!disturb)
            {
                saveGame.Disturb(false);
            }
        }
    }
}
