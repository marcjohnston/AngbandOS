// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TunnelScript : Script
{
    private TunnelScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        bool more = false;
        // Get the direction in which we wish to tunnel
        if (SaveGame.GetDirectionNoAim(out int dir))
        {
            // Pick up the tile that the player wishes to tunnel through
            int tileY = SaveGame.MapY + SaveGame.KeypadDirectionYOffset[dir];
            int tileX = SaveGame.MapX + SaveGame.KeypadDirectionXOffset[dir];
            GridTile tile = SaveGame.Grid[tileY][tileX];
            // Check if it can be tunneled through
            if (tile.FeatureType.IsPassable || tile.FeatureType.Name == "YellowSign")
            {
                SaveGame.MsgPrint("You cannot tunnel through air.");
            }
            else if (tile.FeatureType.IsClosedDoor)
            {
                SaveGame.MsgPrint("You cannot tunnel through doors.");
            }
            // Can't tunnel if there's a monster there - so attack the monster instead
            else if (tile.MonsterIndex != 0)
            {
                SaveGame.EnergyUse = 100;
                SaveGame.MsgPrint("There is a monster in the way!");
                SaveGame.PlayerAttackMonster(tileY, tileX);
            }
            else
            {
                // Tunnel through the tile
                more = SaveGame.TunnelThroughTile(tileY, tileX);
            }
        }
        return more;
    }
}
