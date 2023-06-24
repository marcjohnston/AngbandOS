// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class RefillScript : Script
    {
        private RefillScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            // Make sure we actually have a light source to refuel.           
            BaseInventorySlot? chosenLightSourceInventorySlot = SaveGame.SingletonRepository.InventorySlots.ToWeightedRandom(inventorySlot => inventorySlot.ProvidesLight).Choose();

            // Check to ensure there is an inventory slot for light sources.
            if (chosenLightSourceInventorySlot == null)
            {
                SaveGame.MsgPrint("You are not wielding a light.");
                return false;
            }

            // Now choose a light source item.
            int? i = chosenLightSourceInventorySlot.WeightedRandom.Choose();
            if (i == null)
            {
                SaveGame.MsgPrint("You are not wielding a light.");
                return false;
            }

            Item? lightSource = SaveGame.GetInventoryItem(i.Value);
            if (lightSource == null)
            {
                SaveGame.MsgPrint("You are not wielding a light.");
                return false;
            }

            LightSourceItemFactory lightSourceItem = (LightSourceItemFactory)lightSource.Factory;
            lightSourceItem.Refill(SaveGame, lightSource);
            return false;
        }
    }
}
