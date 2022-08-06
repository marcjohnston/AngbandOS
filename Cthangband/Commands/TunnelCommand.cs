using System;

namespace Cthangband.Commands
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
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            bool disturb = false;
            // Get the direction in which we wish to tunnel
            if (targetEngine.GetDirectionNoAim(out int dir))
            {
                // Pick up the tile that the player wishes to tunnel through
                int tileY = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int tileX = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[tileY][tileX];
                // Check if it can be tunneled through
                if (tile.FeatureType.IsPassable || tile.FeatureType.Name == "YellowSign")
                {
                    Profile.Instance.MsgPrint("You cannot tunnel through air.");
                }
                else if (tile.FeatureType.IsClosedDoor)
                {
                    Profile.Instance.MsgPrint("You cannot tunnel through doors.");
                }
                // Can't tunnel if there's a monster there - so attack the monster instead
                else if (tile.MonsterIndex != 0)
                {
                    SaveGame.Instance.EnergyUse = 100;
                    Profile.Instance.MsgPrint("There is a monster in the way!");
                    SaveGame.Instance.PlayerAttackMonster(tileY, tileX);
                }
                else
                {
                    // Tunnel through the tile
                    disturb = SaveGame.Instance.TunnelThroughTile(tileY, tileX);
                }
            }
            // Something might have disturbed us
            if (!disturb)
            {
                SaveGame.Instance.Disturb(false);
            }
        }
    }
}
