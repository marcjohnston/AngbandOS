// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Activate the special feature of an item.
/// </summary>
[Serializable]
internal class ActivateScript : Script, IScript, IRepeatableScript, ISuccessByChanceScript
{
    private ActivateScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the activate script and disposes of the successful result.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }

    /// <summary>
    /// Executes the activate script, disposes of the successful result and returns false because activation is never repeatable.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteSuccessByChanceScript();
        return false;
    }

    /// <summary>
    /// Allows the user to select an item and activates the special feature of that item.  Returns false, in all cases.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        // No item passed in, so get one; filtering to activatable items only
        if (!Game.SelectItem(out Item? item, "Activate which item? ", true, true, false, Game.SingletonRepository.Get<ItemFilter>(nameof(KnownAndActivableItemFilter))))
        {
            Game.MsgPrint("You have nothing to activate.");
            return false;
        }
        // Get the item from the index
        if (item == null)
        {
            return false;
        }

        // Activating an item uses 100 energy
        Game.EnergyUse = 100;

        // Get the level of the item
        int itemLevel = item.LevelNormallyFound;
        if (item.FixedArtifact != null)
        {
            itemLevel = item.FixedArtifact.Level;
        }

        // Work out the chance of using the item successfully based on its level and the
        // player's skill
        int chance = Game.SkillUseDevice;
        if (Game.ConfusedTimer.Value != 0)
        {
            chance /= 2;
        }

        chance -= itemLevel > 50 ? 50 : itemLevel;

        // Always give a slight chance of success
        if (chance < Constants.UseDevice && Game.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
        {
            chance = Constants.UseDevice;
        }

        // If we fail our use item roll just tell us and quit
        if (chance < Constants.UseDevice || Game.DieRoll(chance) < Constants.UseDevice)
        {
            Game.MsgPrint("You failed to activate it properly.");
            return false;
        }

        // If the item is still recharging, then just tell us and quit
        if (item.ActivationRechargeTimeRemaining != 0)
        {
            Game.MsgPrint("It whines, glows and fades...");
            return false;
        }

        // We passed the checks, so the item is activated
        Game.MsgPrint("You activate it...");
        Game.PlaySound(SoundEffectEnum.ActivateArtifact);

        // If it is a random artifact then use its ability and quit
        ItemCharacteristics mergedCharacteristics = item.GetMergedCharacteristics();
        if (mergedCharacteristics.Activation != null)
        {
            return mergedCharacteristics.Activation.Activate(item);
        }

        return false;
    }
}
