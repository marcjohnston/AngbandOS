// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class OpenScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private OpenScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the open script and disposes of the repeatable result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteGameCommandScript();
    }

    /// <summary>
    /// Executes the open script and returns true, if the open fails due to chance; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        bool isRepeatable = false;
        // Check if there's only one thing we can open
        int numDoors = Game.CountClosedDoors(out GridCoordinate? doorCoord);
        int numChests = Game.CountChests(out GridCoordinate? chestCoord, false);
        if (numDoors != 0 || numChests != 0)
        {
            bool tooMany = (numDoors != 0 && numChests != 0) || numDoors > 1 || numChests > 1;
            if (!tooMany)
            {
                // There's only one thing we can open, so assume we mean that thing
                GridCoordinate coord = numDoors == 1 ? doorCoord : chestCoord;
                Game.CommandDirection = Game.CoordsToDir(coord.Y, coord.X);
            }
        }
        // If we don't already have a direction, prompt for one
        if (Game.GetDirectionNoAim(out int dir))
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Map.Grid[y][x];
            Item? chestItem = Game.ChestCheck(y, x);
            // Make sure there is something to open in the direction we chose
            if (!tile.FeatureType.IsVisibleDoor && chestItem == null)
            {
                Game.MsgPrint("You see nothing there to open.");
            }
            // Can't open something if there's a monster in the way
            else if (tile.MonsterIndex != 0)
            {
                Game.EnergyUse = 100;
                Game.MsgPrint("There is a monster in the way!");
                Game.PlayerAttackMonster(y, x);
            }
            // Open the chest or door
            else if (chestItem != null)
            {
                bool openedSuccessfully = true;
                // Opening a chest takes an action
                Game.EnergyUse = 100;
                // If the chest is locked, we may need to pick it
                if (!chestItem.ContainerIsOpen && chestItem.ContainerTraps != null)
                {
                    openedSuccessfully = false;
                    // Our disable traps skill also doubles up as a lockpicking skill
                    int i = Game.SkillDisarmTraps;
                    // Hard to pick locks in the dark
                    if (Game.BlindnessTimer.Value != 0 || Game.NoLight())
                    {
                        i /= 10;
                    }
                    // Hard to pick locks when you're confused or hallucinating
                    if (Game.ConfusedTimer.Value != 0 || Game.HallucinationsTimer.Value != 0)
                    {
                        i /= 10;
                    }
                    // Some locks are harder to pick than others
                    int j = i - chestItem.LevelOfObjectsInContainer;
                    if (j < 2)
                    {
                        j = 2;
                    }
                    // See if we succeeded
                    if (Game.RandomLessThan(100) < j)
                    {
                        Game.MsgPrint("You have picked the lock.");
                        Game.GainExperience(1);
                        openedSuccessfully = true;
                    }
                    else
                    {
                        isRepeatable = true;
                        Game.MsgPrint("You failed to pick the lock.");
                    }
                }
                // If we successfully opened it, set of any traps and then actually open the chest
                if (openedSuccessfully)
                {
                    Game.ActivateChestTrap(y, x, chestItem);
                    Game.OpenChest(y, x, chestItem);
                }
            }
            else
            {
                isRepeatable = Game.OpenDoor(y, x);
            }
        }
        return new RepeatableResult(isRepeatable);
    }
}
