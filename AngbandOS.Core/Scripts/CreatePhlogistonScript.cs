// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CreatePhlogistonScript : Script, IScript
{
    private CreatePhlogistonScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Create phlogiston to refill a lantern or torch with.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        LightsourceInventorySlot lightsourceInventorySlot = (LightsourceInventorySlot)SaveGame.SingletonRepository.InventorySlots.Get(nameof(LightsourceInventorySlot));
        Item? item = SaveGame.GetInventoryItem(lightsourceInventorySlot.WeightedRandom.ChooseOrDefault());
        if (item == null)
        {
            SaveGame.MsgPrint("You are not wielding a light source.");
            return;
        }
        LightSourceItemFactory? lightSourceItemFactory = item.TryGetFactory<LightSourceItemFactory>();
        if (lightSourceItemFactory == null)
        {
            return;
        }
        // Maximum phlogiston is the capacity of the light source
        int? maxPhlogiston = lightSourceItemFactory.MaxPhlogiston;

        // Probably using an orb or a star essence (or maybe not holding a light source at all)
        if (maxPhlogiston == null)
        {
            SaveGame.MsgPrint("You are not wielding anything which uses phlogiston.");
            return;
        }

        // Item is already full
        if (item.TypeSpecificValue >= maxPhlogiston)
        {
            SaveGame.MsgPrint("No more phlogiston can be put in this item.");
            return;
        }

        // Add half the max fuel of the item to its current fuel
        item.TypeSpecificValue += maxPhlogiston.Value / 2;
        SaveGame.MsgPrint("You add phlogiston to your light item.");

        // Make sure it doesn't overflow
        if (item.TypeSpecificValue >= maxPhlogiston)
        {
            item.TypeSpecificValue = maxPhlogiston.Value;
            SaveGame.MsgPrint("Your light item is full.");
        }

        // We need to update our light after this
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateTorchRadiusFlaggedAction)).Set();
    }
}
