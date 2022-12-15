namespace AngbandOS.Commands
{
    /// <summary>
    /// Tunnel into the wall (or whatever is in front of us
    /// </summary>
    [Serializable]
    internal class TunnelCommand : ICommand
    {
        public char Key => 'T';

        public int? Repeat => 99;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            bool disturb = false;
            // Get the direction in which we wish to tunnel
            if (saveGame.GetDirectionNoAim(out int dir))
            {
                // Pick up the tile that the player wishes to tunnel through
                int tileY = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int tileX = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[tileY][tileX];
                // Check if it can be tunneled through
                if (tile.FeatureType.IsPassable || tile.FeatureType.Name == "YellowSign")
                {
                    saveGame.MsgPrint("You cannot tunnel through air.");
                }
                else if (tile.FeatureType.IsClosedDoor)
                {
                    saveGame.MsgPrint("You cannot tunnel through doors.");
                }
                // Can't tunnel if there's a monster there - so attack the monster instead
                else if (tile.MonsterIndex != 0)
                {
                    saveGame.EnergyUse = 100;
                    saveGame.MsgPrint("There is a monster in the way!");
                    saveGame.PlayerAttackMonster(tileY, tileX);
                }
                else
                {
                    // Tunnel through the tile
                    disturb = saveGame.TunnelThroughTile(tileY, tileX);
                }
            }
            // Something might have disturbed us
            if (!disturb)
            {
                saveGame.Disturb(false);
            }
        }
    }
}
