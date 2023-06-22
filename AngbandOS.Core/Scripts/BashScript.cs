// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    /// <summary>
    /// Get a direction and bash a door, returning true, if the command can be repeated; false, if the command succeeds or is futile.</returns>
    /// </summary>
    [Serializable]
    internal class BashScript : Script
    {
        private BashScript(SaveGame saveGame) : base(saveGame) { }

        /// <summary>
        /// Allows the player to select a direction and bashes the object found in that direction.  Returns false, if the action fails due to chance.
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            // Assume it won't disturb us
            bool more = false;

            // Get the direction to bash
            if (SaveGame.GetDirectionNoAim(out int dir))
            {
                int y = SaveGame.Player.MapY + SaveGame.Level.KeypadDirectionYOffset[dir];
                int x = SaveGame.Player.MapX + SaveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = SaveGame.Level.Grid[y][x];
                // Can only bash closed doors
                if (!tile.FeatureType.IsClosedDoor)
                {
                    SaveGame.MsgPrint("You see nothing there to bash.");
                }
                else if (tile.MonsterIndex != 0)
                {
                    // Oops - a monster got in the way
                    SaveGame.EnergyUse = 100;
                    SaveGame.MsgPrint("There is a monster in the way!");
                    SaveGame.PlayerAttackMonster(y, x);
                }
                else
                {
                    // Bash the door.
                    more = SaveGame.BashClosedDoor(y, x);
                }
            }
            return more;
        }
    }
}
