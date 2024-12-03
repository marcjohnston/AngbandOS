// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

/// <summary>
/// Represents a base class for inventory slots that represent equipment inventory slots.
/// </summary>
[Serializable]
internal abstract class EquipmentWieldSlot : WieldSlot
{
    protected EquipmentWieldSlot(Game game) : base(game) { }

    /// <summary>
    /// Returns true.
    /// </summary>
    public override bool IsEquipment => true;

    public override bool IsWieldedAsEquipment => true;

    /// Checks the quantity of an item and removes it, when the quanity is zero.
    /// </summary>
    /// <param name="oPtr"></param>
    public override void ItemOptimize(Item oPtr)
    {
        if (oPtr.Count > 0)
        {
            return;
        }
        int foundSlot = FindInventorySlot(oPtr);
        Game.SetInventoryItem(foundSlot, null);
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
    }

    /// <summary>
    /// Allows wielded equipment items to process world.  By default, initiates the hook for all items in the inventory slot to perform processing during the ProcessWorld event through
    /// the EquipmentProcessWorld method.
    /// </summary>
    public override void ProcessWorld(ProcessWorldEventArgs processWorldEventArgs)
    {
        base.ProcessWorld(processWorldEventArgs);

        // Allow each item in this inventory slot to process the world turn.
        foreach (int index in InventorySlots)
        {
            Item? oPtr = Game.GetInventoryItem(index);
            if (oPtr != null)
            {
                // Perform some universal actions for items that are worn.
                ItemCharacteristics mergedCharacteristics = oPtr.GetMergedCharacteristics();
                if (mergedCharacteristics.DreadCurse && Game.DieRoll(100) == 1)
                {
                    Game.ActivateDreadCurse();
                }


                // Items that teleport.
                if (mergedCharacteristics.Teleport && Game.RandomLessThan(100) < 1)
                {
                    if (oPtr.IsCursed && !Game.HasAntiTeleport)
                    {
                        Game.Disturb(true);
                        Game.RunScriptInt(nameof(TeleportSelfScript), 40);
                    }
                    else
                    {
                        if (Game.GetCheck("Teleport? "))
                        {
                            Game.Disturb(false);
                            Game.RunScriptInt(nameof(TeleportSelfScript), 50);
                        }
                    }
                }

                // Activated items only recharge when they are being worn.
                if (oPtr.ActivationRechargeTimeRemaining > 0)
                {
                    oPtr.ActivationRechargeTimeRemaining--;
                    if (oPtr.ActivationRechargeTimeRemaining == 0)
                    {
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineFlaggedAction)).Set();
                    }
                }

                oPtr.EquipmentProcessWorld();
            }
        }

        if (Game.Race.IsBurnedBySunlight) // TODO: This needs to use a hook.
        {
            foreach (int index in InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(index);
                if (oPtr != null && oPtr.ProvidesSunlight && !Game.HasLightResistance)
                {
                    string oName = oPtr.GetDescription(false);
                    Game.MsgPrint($"The {oName} scorches your undead flesh!");
                    processWorldEventArgs.DisableRegeneration = true;
                    oName = oPtr.GetDescription(true);
                    string ouch = $"wielding {oName}";
                    if (Game.InvulnerabilityTimer.Value == 0)
                    {
                        Game.TakeHit(1, ouch);
                    }
                }
            }
        }
    }
}