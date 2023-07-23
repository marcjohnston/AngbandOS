// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CloseScript : Script
{
    private CloseScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        bool more = false;
        // If there's only one door, assume we mean that one and don't ask for a direction
        if (SaveGame.CountOpenDoors(out GridCoordinate? coord) == 1)
        {
            SaveGame.CommandDirection = SaveGame.CoordsToDir(coord.Y, coord.X);
        }
        // Get the location to close
        if (SaveGame.GetDirectionNoAim(out int dir))
        {
            int y = SaveGame.MapY + SaveGame.KeypadDirectionYOffset[dir];
            int x = SaveGame.MapX + SaveGame.KeypadDirectionXOffset[dir];
            GridTile tile = SaveGame.Grid[y][x];
            // Can only close actual open doors
            if (!tile.FeatureType.IsOpenDoor)
            {
                SaveGame.MsgPrint("You see nothing there to close.");
            }
            // Can't close if there's a monster in the way
            else if (tile.MonsterIndex != 0)
            {
                SaveGame.EnergyUse = 100;
                SaveGame.MsgPrint("There is a monster in the way!");
                SaveGame.PlayerAttackMonster(y, x);
            }
            // Actually close the door
            else
            {
                more = SaveGame.CloseDoor(y, x);
            }
        }
        return more;
    }
}
