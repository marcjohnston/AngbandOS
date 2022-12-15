namespace AngbandOS.Commands
{
    /// <summary>
    /// Bash a door to open it
    /// </summary>
    [Serializable]
    internal class BashCommand : ICommand
    {
        public char Key => 'B';

        public int? Repeat => 99;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            // Assume it won't disturb us
            bool disturb = false;

            // Get the direction to bash
            if (saveGame.GetDirectionNoAim(out int dir))
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[y][x];
                // Can only bash closed doors
                if (!tile.FeatureType.IsClosedDoor)
                {
                    saveGame.MsgPrint("You see nothing there to bash.");
                }
                else if (tile.MonsterIndex != 0)
                {
                    // Oops - a montser got in the way
                    saveGame.EnergyUse = 100;
                    saveGame.MsgPrint("There is a monster in the way!");
                    saveGame.PlayerAttackMonster(y, x);
                }
                else
                {
                    // Bash the door
                    disturb = saveGame.BashClosedDoor(y, x, dir);
                }
            }
            if (!disturb)
            {
                saveGame.Disturb(false);
            }
        }
    }
}
