using System;

namespace Cthangband.Commands
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
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);

            // Get the direction to bash
            if (targetEngine.GetDirectionNoAim(out int dir))
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
                GridTile tile = saveGame.Level.Grid[y][x];
                // Can only bash closed doors
                if (!tile.FeatureType.IsClosedDoor)
                {
                    Profile.Instance.MsgPrint("You see nothing there to bash.");
                }
                else if (tile.MonsterIndex != 0)
                {
                    // Oops - a montser got in the way
                    SaveGame.Instance.EnergyUse = 100;
                    Profile.Instance.MsgPrint("There is a monster in the way!");
                    SaveGame.Instance.PlayerAttackMonster(y, x);
                }
                else
                {
                    // Bash the door
                    disturb = SaveGame.Instance.BashClosedDoor(y, x, dir);
                }
            }
            if (!disturb)
            {
                SaveGame.Instance.Disturb(false);
            }
        }
    }
}
