﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateTorchRadiusFlaggedAction : FlaggedAction
{
    private int OldLightLevel;
    private UpdateTorchRadiusFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    /// <summary>
    /// Compute the level of light.  The player may be wielding multiple sources of light.
    /// </summary>
    protected override void Execute()
    {
        SaveGame.LightLevel = 0;
        foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots.Where(_inventorySlot => _inventorySlot.IsEquipment))
        {
            foreach (int i in inventorySlot.InventorySlots)
            {
                Item? oPtr = SaveGame.GetInventoryItem(i);
                if (oPtr != null)
                {
                    SaveGame.LightLevel += oPtr.CalculateTorch();
                }
            }
        }
        if (SaveGame.LightLevel > 5)
        {
            SaveGame.LightLevel = 5;
        }
        if (SaveGame.LightLevel == 0 && SaveGame.HasGlow)
        {
            SaveGame.LightLevel = 1;
        }
        if (OldLightLevel != SaveGame.LightLevel)
        {
            SaveGame.SingletonRepository.FlaggedActions.Get<UpdateLightFlaggedAction>().Set();
            SaveGame.SingletonRepository.FlaggedActions.Get<UpdateMonstersFlaggedAction>().Set();
            OldLightLevel = SaveGame.LightLevel;
        }
    }
}