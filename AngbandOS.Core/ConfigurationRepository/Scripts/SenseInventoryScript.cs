﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SenseInventoryScript : Script, IScript
{
    private SenseInventoryScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Senses magical items in the inventory.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int playerLevel = SaveGame.ExperienceLevel;
        if (SaveGame.TimedConfusion.TurnsRemaining != 0)
        {
            return;
        }
        if (!SaveGame.BaseCharacterClass.SenseInventoryTest(SaveGame.ExperienceLevel))
        {
            return;
        }
        bool detailed = SaveGame.BaseCharacterClass.DetailedSenseInventory;

        // Enumerate each of the inventory slots.
        foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
        {
            // Enumerate each of the items in the inventory slot.
            foreach (int i in inventorySlot)
            {
                Item? item = SaveGame.GetInventoryItem(i);
                if (item == null)
                {
                    continue;
                }
                bool okay = item.Factory.IdentityCanBeSensed;
                if (!okay)
                {
                    continue;
                }
                if (item.IdentSense)
                {
                    continue;
                }
                if (item.IsKnown())
                {
                    continue;
                }
                if (!inventorySlot.IdentitySenseChanceTest)
                {
                    continue;
                }
                string feel = detailed ? item.GetDetailedFeeling() : item.GetVagueFeeling();
                if (string.IsNullOrEmpty(feel))
                {
                    continue;
                }
                string oName = item.Description(false, 0);
                string isare = item.Count == 1 ? "is" : "are";
                SaveGame.MsgPrint($"You feel the {oName} ({i.IndexToLabel()}) {inventorySlot.SenseLocation(i)} {isare} {feel}...");
                item.IdentSense = true;
                if (string.IsNullOrEmpty(item.Inscription))
                {
                    item.Inscription = feel;
                }
                SaveGame.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
            }
        }
    }
}