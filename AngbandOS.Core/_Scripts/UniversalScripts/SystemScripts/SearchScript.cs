﻿// AngbandOS: 2022 Marc Johnston
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
internal class SearchScript : UniversalScript, IGetKey
{
    private SearchScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the search script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        // Searching costs 100.
        Game.EnergyUse = 100;

        // The basic chance is equal to our searching skill
        int chance = Game.SkillSearching;
        // If we can't see it's hard to search
        if (Game.BlindnessTimer.Value != 0 || Game.NoLight())
        {
            chance /= 10;
        }
        // If we're confused it's hard to search
        if (Game.ConfusionTimer.Value != 0 || Game.HallucinationsTimer.Value != 0)
        {
            chance /= 10;
        }
        // Check the eight squares around us
        for (int y = Game.MapY.IntValue - 1; y <= Game.MapY.IntValue + 1; y++)
        {
            for (int x = Game.MapX.IntValue - 1; x <= Game.MapX.IntValue + 1; x++)
            {
                // Check if we succeed
                if (Game.RandomLessThan(100) < chance)
                {
                    // If there's a trap, then find it
                    GridTile tile = Game.Map.Grid[y][x];
                    if (tile.FeatureType.IsInvisibleTrap)
                    {
                        // Pick a random trap to replace the undetected one with
                        Game.PickTrap(y, x);
                        Game.MsgPrint("You have found a trap.");
                        Game.Disturb(false);
                    }
                    if (tile.FeatureType.IsSecretDoor)
                    {
                        // Replace the secret door with a visible door
                        Game.MsgPrint("You have found a secret door.");
                        Game.GainExperience(1);
                        Game.ReplaceSecretDoor(y, x);
                        Game.Disturb(false);
                    }
                    // Check the items on the tile
                    foreach (Item item in tile.Items)
                    {
                        // If one of them is a chest, determine if it is trapped
                        if (!item.IsContainer)
                        {
                            continue;
                        }
                        if (item.ContainerIsOpen || item.ContainerTraps == null || item.ContainerTraps.Length == 0)
                        {
                            continue;
                        }
                        // It was a trapped chest - if we didn't already know that then let us know
                        if (!item.IsKnown())
                        {
                            Game.MsgPrint("You have discovered a trap on the chest!");
                            item.BecomeKnown();
                            Game.Disturb(false);
                        }
                    }
                }
            }
        }
    }
}
