// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Get a direction and bash a door, returning true, if the command can be repeated; false, if the command succeeds or is futile.</returns>
/// </summary>
[Serializable]
internal class BashScript : Script, IScript, IRepeatableScript
{
    private BashScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the bash script and disposes of the repeatable result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteRepeatableScript();
    }

    /// <summary>
    /// Allows the player to select a direction and bashes the object found in that direction.  Returns true, if the action fails due to chance.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        // Assume it won't disturb us
        bool more = false;

        // Get the direction to bash
        if (Game.GetDirectionNoAim(out int dir))
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Map.Grid[y][x];
            // Can only bash closed doors
            if (!tile.FeatureType.IsVisibleDoor)
            {
                Game.MsgPrint("You see nothing there to bash.");
            }
            else if (tile.MonsterIndex != 0)
            {
                // Oops - a monster got in the way
                Game.EnergyUse = 100;
                Game.MsgPrint("There is a monster in the way!");
                Game.PlayerAttackMonster(y, x);
            }
            else
            {
                // Bash the door.
                more = Game.BashClosedDoor(y, x);
            }
        }
        return more;
    }
}

/// <summary>
/// Refill a light-source using a flask of oil.
/// </summary>
[Serializable]
internal class RefillLightSourceFromFlaskScript : Script, IScriptItem
{
    private RefillLightSourceFromFlaskScript(Game game) : base(game) { }
    public void ExecuteScriptItem(Item item)
    {
        // Get an item if we don't already have one
        if (!Game.SelectItem(out Item? fuelSource, "Refill with which flask? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(LanternFuelItemFilter))))
        {
            Game.MsgPrint("You have no flasks of oil.");
            return;
        }

        // Get the item from the inventory or from the floor.
        if (fuelSource == null)
        {
            return;
        }

        // Make sure our item is suitable fuel
        if (!Game.ItemMatchesFilter(fuelSource, Game.SingletonRepository.Get<ItemFilter>(nameof(LanternFuelItemFilter))))
        {
            Game.MsgPrint("You can't refill a lantern from that!");
            return;
        }
        // Refilling takes half a turn
        Game.EnergyUse = 50;

        // Add the fuel
        item.TurnsOfLightRemaining += fuelSource.TurnsOfLightRemaining;
        Game.MsgPrint("You fuel your lamp.");

        // Check for overfilling
        if (item.TurnsOfLightRemaining >= Constants.FuelLamp)
        {
            item.TurnsOfLightRemaining = Constants.FuelLamp;
            Game.MsgPrint("Your lamp is full.");
        }

        // Update the inventory
        fuelSource.ItemIncrease(-1);
        fuelSource.ItemDescribe();
        fuelSource.ItemOptimize();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
    }
}

/// <summary>
/// Refill a torch from another torch.
/// </summary>
[Serializable]
internal class RefillLightSourceFromTorchScript : Script, IScriptItem
{
    private RefillLightSourceFromTorchScript(Game game) : base(game) { }
    public void ExecuteScriptItem(Item item)
    {
        // Get an item if we don't already have one
        if (!Game.SelectItem(out Item? fuelSource, "Refuel with which torch? ", false, true, true, base.Game.SingletonRepository.Get<ItemFilter>(nameof(ItemFilters.TorchFuelItemFilter))))
        {
            Game.MsgPrint("You have no extra torches.");
            return;
        }
        if (fuelSource == null)
        {
            return;
        }

        // Check that our fuel is suitable
        if (!Game.ItemMatchesFilter(fuelSource, base.Game.SingletonRepository.Get<ItemFilter>(nameof(ItemFilters.TorchFuelItemFilter))))
        {
            Game.MsgPrint("You can't refill a torch with that!");
            return;
        }
        // Refueling takes half a turn
        Game.EnergyUse = 50;

        // Add the fuel
        item.TurnsOfLightRemaining += fuelSource.TurnsOfLightRemaining + 5;
        Game.MsgPrint("You combine the torches.");

        // Check for overfilling
        if (item.TurnsOfLightRemaining >= Constants.FuelTorch)
        {
            item.TurnsOfLightRemaining = Constants.FuelTorch;
            Game.MsgPrint("Your torch is fully fueled.");
        }
        else
        {
            Game.MsgPrint("Your torch glows more brightly.");
        }

        // Update the player's inventory
        fuelSource.ItemIncrease(-1);
        fuelSource.ItemDescribe();
        fuelSource.ItemOptimize();
        base.Game.SingletonRepository.Get<FlaggedAction>(nameof(FlaggedActions.UpdateTorchRadiusFlaggedAction)).Set();
    }
}