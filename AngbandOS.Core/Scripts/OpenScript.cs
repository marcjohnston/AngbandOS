// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class OpenScript : Script
{
    private OpenScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        bool more = false;
        // Check if there's only one thing we can open
        int numDoors = SaveGame.CountClosedDoors(out GridCoordinate? doorCoord);
        int numChests = SaveGame.CountChests(out GridCoordinate? chestCoord, false);
        if (numDoors != 0 || numChests != 0)
        {
            bool tooMany = (numDoors != 0 && numChests != 0) || numDoors > 1 || numChests > 1;
            if (!tooMany)
            {
                // There's only one thing we can open, so assume we mean that thing
                GridCoordinate coord = numDoors == 1 ? doorCoord : chestCoord;
                SaveGame.CommandDirection = SaveGame.Level.CoordsToDir(coord.Y, coord.X);
            }
        }
        // If we don't already have a direction, prompt for one
        if (SaveGame.GetDirectionNoAim(out int dir))
        {
            int y = SaveGame.MapY + SaveGame.Level.KeypadDirectionYOffset[dir];
            int x = SaveGame.MapX + SaveGame.Level.KeypadDirectionXOffset[dir];
            GridTile tile = SaveGame.Level.Grid[y][x];
            Item? chestItem = SaveGame.Level.ChestCheck(y, x);
            // Make sure there is something to open in the direction we chose
            if (!tile.FeatureType.IsClosedDoor && chestItem == null)
            {
                SaveGame.MsgPrint("You see nothing there to open.");
            }
            // Can't open something if there's a monster in the way
            else if (tile.MonsterIndex != 0)
            {
                SaveGame.EnergyUse = 100;
                SaveGame.MsgPrint("There is a monster in the way!");
                SaveGame.PlayerAttackMonster(y, x);
            }
            // Open the chest or door
            else if (chestItem != null)
            {
                more = OpenChestAtGivenLocation(y, x, chestItem);
            }
            else
            {
                more = SaveGame.OpenDoor(y, x);
            }
        }
        return more;
    }

    /// <summary>
    /// Open a chest at a given location
    /// </summary>
    /// <param name="y"> The y coordinate of the location </param>
    /// <param name="x"> The x coordinate of the location </param>
    /// <param name="itemIndex"> The index of the chest item </param>
    /// <returns> Whether or not the player should be disturbed by the action </returns>
    private bool OpenChestAtGivenLocation(int y, int x, Item chestItem)
    {
        bool openedSuccessfully = true;
        bool more = false;
        // Opening a chest takes an action
        SaveGame.EnergyUse = 100;
        // If the chest is locked, we may need to pick it
        if (chestItem.TypeSpecificValue > 0)
        {
            openedSuccessfully = false;
            // Our disable traps skill also doubles up as a lockpicking skill
            int i = SaveGame.SkillDisarmTraps;
            // Hard to pick locks in the dark
            if (SaveGame.TimedBlindness.TurnsRemaining != 0 || SaveGame.Level.NoLight())
            {
                i /= 10;
            }
            // Hard to pick locks when you're confused or hallucinating
            if (SaveGame.TimedConfusion.TurnsRemaining != 0 || SaveGame.TimedHallucinations.TurnsRemaining != 0)
            {
                i /= 10;
            }
            // Some locks are harder to pick than others
            int j = i - chestItem.TypeSpecificValue;
            if (j < 2)
            {
                j = 2;
            }
            // See if we succeeded
            if (Program.Rng.RandomLessThan(100) < j)
            {
                SaveGame.MsgPrint("You have picked the lock.");
                SaveGame.GainExperience(1);
                openedSuccessfully = true;
            }
            else
            {
                more = true;
                SaveGame.MsgPrint("You failed to pick the lock.");
            }
        }
        // If we successfully opened it, set of any traps and then actually open the chest
        if (openedSuccessfully)
        {
            SaveGame.ChestTrap(y, x, chestItem);
            SaveGame.OpenChest(y, x, chestItem);
        }
        return more;
    }
}
