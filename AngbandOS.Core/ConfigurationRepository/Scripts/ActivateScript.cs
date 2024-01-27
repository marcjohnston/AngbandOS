// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.ConfigurationRepository.ItemMatchingCriterion;

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Activate the special feature of an item.
/// </summary>
[Serializable]
internal class ActivateScript : Script, IScript, IRepeatableScript, ISuccessfulScript
{
    private ActivateScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the activate script and disposes of the successful result.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }

    /// <summary>
    /// Executes the activate script, disposes of the successful result and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteSuccessfulScript();
        return false;
    }

    /// <summary>
    /// Allows the user to select an item and activates the special feature of that item.  Returns false, in all cases.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        // No item passed in, so get one; filtering to activatable items only
        if (!SaveGame.SelectItem(out Item? item, "Activate which item? ", true, true, false, SaveGame.SingletonRepository.ItemFilters.Get(nameof(KnownAndActivableItemFilter))))
        {
            SaveGame.MsgPrint("You have nothing to activate.");
            return false;
        }
        // Get the item from the index
        if (item == null)
        {
            return false;
        }

        // Activating an item uses 100 energy
        SaveGame.EnergyUse = 100;

        // Get the level of the item
        int itemLevel = item.Factory.Level;
        if (item.FixedArtifact != null)
        {
            itemLevel = item.FixedArtifact.Level;
        }

        // Work out the chance of using the item successfully based on its level and the
        // player's skill
        int chance = SaveGame.SkillUseDevice;
        if (SaveGame.TimedConfusion.TurnsRemaining != 0)
        {
            chance /= 2;
        }

        chance -= itemLevel > 50 ? 50 : itemLevel;

        // Always give a slight chance of success
        if (chance < Constants.UseDevice && SaveGame.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
        {
            chance = Constants.UseDevice;
        }

        // If we fail our use item roll just tell us and quit
        if (chance < Constants.UseDevice || SaveGame.Rng.DieRoll(chance) < Constants.UseDevice)
        {
            SaveGame.MsgPrint("You failed to activate it properly.");
            return false;
        }

        // If the item is still recharging, then just tell us and quit
        if (item.RechargeTimeLeft != 0)
        {
            SaveGame.MsgPrint("It whines, glows and fades...");
            return false;
        }

        // We passed the checks, so the item is activated
        SaveGame.MsgPrint("You activate it...");
        SaveGame.PlaySound(SoundEffectEnum.ActivateArtifact);

        // If it is a random artifact then use its ability and quit
        if (string.IsNullOrEmpty(item.RandartName) == false)
        {
            ActivateRandomArtifact(item);
            return true;
        }

        // If it's a fixed artifact then use its ability
        if (item.FixedArtifact != null && typeof(IFixedArtifactActivatible).IsAssignableFrom(item.FixedArtifact.GetType()))
        {
            IFixedArtifactActivatible activatibleFixedArtifact = (IFixedArtifactActivatible)item.FixedArtifact;
            activatibleFixedArtifact.ActivateItem(item);
            return true;
        }

        // If it wasn't an artifact, then check the other types of activatable item Planar
        // weapon teleports you
        if (item.RareItemTypeIndex == RareItemTypeEnum.WeaponPlanarWeapon)
        {
            SaveGame.TeleportPlayer(100);
            item.RechargeTimeLeft = 50 + SaveGame.Rng.DieRoll(50);
            return true;
        }

        // Check to see if the item can be activated.
        if (item.Factory.Activate)
        {
            IItemActivatable activatibleItem = (IItemActivatable)item;
            activatibleItem.DoActivate();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Activate a randomly generated artifact.
    /// </summary>
    /// <param name="item"> The artifact being activated.</param>
    private void ActivateRandomArtifact(Item item)
    {
        // If we don't have a random artifact, abort
        if (string.IsNullOrEmpty(item.RandartName))
        {
            return;
        }
        Activation artifactPower = item.BonusPowerSubType;

        if (!String.IsNullOrEmpty(artifactPower.PreActivationMessage))
        {
            SaveGame.MsgPrint(artifactPower.PreActivationMessage);
        }
        if (artifactPower.Activate())
        {
            item.RechargeTimeLeft = artifactPower.RechargeTime();
        }
    }
}
