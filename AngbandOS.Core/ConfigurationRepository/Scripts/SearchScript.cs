// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Search around the player for secret doors and traps
/// </summary>
[Serializable]
internal class SearchScript : Script
{
    private SearchScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        // The basic chance is equal to our searching skill
        int chance = SaveGame.SkillSearching;
        // If we can't see it's hard to search
        if (SaveGame.TimedBlindness.TurnsRemaining != 0 || SaveGame.NoLight())
        {
            chance /= 10;
        }
        // If we're confused it's hard to search
        if (SaveGame.TimedConfusion.TurnsRemaining != 0 || SaveGame.TimedHallucinations.TurnsRemaining != 0)
        {
            chance /= 10;
        }
        // Check the eight squares around us
        for (int y = SaveGame.MapY - 1; y <= SaveGame.MapY + 1; y++)
        {
            for (int x = SaveGame.MapX - 1; x <= SaveGame.MapX + 1; x++)
            {
                // Check if we succeed
                if (SaveGame.Rng.RandomLessThan(100) < chance)
                {
                    // If there's a trap, then find it
                    GridTile tile = SaveGame.Grid[y][x];
                    if (tile.FeatureType.Name == "Invis")
                    {
                        // Pick a random trap to replace the undetected one with
                        SaveGame.PickTrap(y, x);
                        SaveGame.MsgPrint("You have found a trap.");
                        SaveGame.Disturb(false);
                    }
                    if (tile.FeatureType.Name == "SecretDoor")
                    {
                        // Replace the secret door with a visible door
                        SaveGame.MsgPrint("You have found a secret door.");
                        SaveGame.GainExperience(1);
                        SaveGame.ReplaceSecretDoor(y, x);
                        SaveGame.Disturb(false);
                    }
                    // Check the items on the tile
                    foreach (Item item in tile.Items)
                    {
                        // If one of them is a chest, determine if it is trapped
                        if (item.Category != ItemTypeEnum.Chest)
                        {
                            continue;
                        }
                        if (item.TypeSpecificValue <= 0)
                        {
                            continue;
                        }
                        if (SaveGame.SingletonRepository.ChestTrapConfigurations[item.TypeSpecificValue].NotTrapped)
                        {
                            continue;
                        }
                        // It was a trapped chest - if we didn't already know that then let us know
                        if (!item.IsKnown())
                        {
                            SaveGame.MsgPrint("You have discovered a trap on the chest!");
                            item.BecomeKnown();
                            SaveGame.Disturb(false);
                        }
                    }
                }
            }
        }
        return false;
    }
}
