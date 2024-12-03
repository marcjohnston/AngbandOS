// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SenseInventoryScript : Script, IScript
{
    private SenseInventoryScript(Game game) : base(game) { }

    /// <summary>
    /// Senses magical items in the inventory.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int playerLevel = Game.ExperienceLevel.IntValue;
        if (Game.ConfusedTimer.Value != 0)
        {
            return;
        }
        if (!Game.BaseCharacterClass.SenseInventoryTest(Game.ExperienceLevel.IntValue))
        {
            return;
        }
        bool detailed = Game.BaseCharacterClass.DetailedSenseInventory;

        // Enumerate each of the inventory slots.
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
        {
            // Enumerate each of the items in the inventory slot.
            foreach (int i in inventorySlot)
            {
                Item? item = Game.GetInventoryItem(i);
                if (item == null)
                {
                    continue;
                }
                bool okay = item.IdentityCanBeSensed;
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
                ItemQualityRating? qualityRating = detailed ? item.GetQualityRating() : item.GetVagueQualityRating();
                if (qualityRating == null)
                {
                    continue;
                }
                string oName = item.GetDescription(false);
                string isare = item.StackCount == 1 ? "is" : "are";
                Game.MsgPrint($"You feel the {oName} ({i.IndexToLabel()}) {inventorySlot.SenseLocation(item)} {isare} {qualityRating.Description}...");
                item.IdentSense = true;
                if (string.IsNullOrEmpty(item.Inscription))
                {
                    item.Inscription = qualityRating.Description;
                }
                Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
            }
        }
    }
}
