// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpikeClosedDoorScript : Script
{
    private SpikeClosedDoorScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        // Get the location to be spiked
        if (SaveGame.GetDirectionNoAim(out int dir))
        {
            int y = SaveGame.MapY + SaveGame.Level.KeypadDirectionYOffset[dir];
            int x = SaveGame.MapX + SaveGame.Level.KeypadDirectionXOffset[dir];
            GridTile tile = SaveGame.Level.Grid[y][x];
            // Make sure it can be spiked and we have spikes to do it with
            if (!tile.FeatureType.IsClosedDoor)
            {
                SaveGame.MsgPrint("You see nothing there to spike.");
            }
            else
            {
                if (!SaveGame.GetSpike(out int itemIndex))
                {
                    SaveGame.MsgPrint("You have no spikes!");
                }
                // Can't close a door if there's someone in the way
                else if (tile.MonsterIndex != 0)
                {
                    // Attempting costs a turn anyway
                    SaveGame.EnergyUse = 100;
                    SaveGame.MsgPrint("There is a monster in the way!");
                    SaveGame.PlayerAttackMonster(y, x);
                }
                else
                {
                    // Spiking a door costs a turn
                    SaveGame.EnergyUse = 100;
                    SaveGame.MsgPrint("You jam the door with a spike.");
                    // Replace the door feature with a jammed door
                    if (tile.FeatureType.IsLockedDoor)
                    {
                        tile.SetFeature(tile.FeatureType.Name.Replace("Locked", "Jammed"));
                    }
                    // If it's already jammed, strengthen it
                    if (tile.FeatureType.IsJammedDoor)
                    {
                        int strength = int.Parse(tile.FeatureType.Name.Substring(10));
                        if (strength < 7)
                        {
                            tile.SetFeature($"JammedDoor{strength + 1}");
                        }
                    }
                    // Use up the spike from the player's inventory
                    SaveGame.InvenItemIncrease(itemIndex, -1);
                    SaveGame.InvenItemDescribe(itemIndex);
                    SaveGame.InvenItemOptimize(itemIndex);
                }
            }
        }
        return false;
   }
}
