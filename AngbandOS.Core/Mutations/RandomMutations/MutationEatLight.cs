// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations
{
    [Serializable]
    internal class MutationEatLight : Mutation
    {
        public override void Initialize()
        {
            Frequency = 1;
            GainMessage = "You feel a strange kinship with Nyogtha.";
            HaveMessage = "You sometimes feed off of the light around you.";
            LoseMessage = "You feel the world's a brighter place.";
        }

        public override void OnProcessWorld(SaveGame saveGame)
        {
            if (Program.Rng.DieRoll(3000) != 1)
            {
                return;
            }
            saveGame.MsgPrint("A shadow passes over you.");
            saveGame.MsgPrint(null);
            if (saveGame.Level.Grid[saveGame.Player.MapY][saveGame.Player.MapX].TileFlags.IsSet(GridTile.SelfLit))
            {
                saveGame.Player.RestoreHealth(10);
            }
            BaseInventorySlot? inventorySlot = saveGame.SingletonRepository.InventorySlots.WeightedRandom(_inventorySlot => _inventorySlot.ProvidesLight).Choose();
            if (inventorySlot == null)
            {
                return;
            }
            int index = inventorySlot.WeightedRandom.Choose();
            Item? oPtr = saveGame.GetInventoryItem(index);
            if (oPtr != null && oPtr.Category == ItemTypeEnum.Light)
            {
                if ((oPtr.ItemSubCategory == LightType.Torch || oPtr.ItemSubCategory == LightType.Lantern) && oPtr.TypeSpecificValue > 0)
                {
                    saveGame.Player.RestoreHealth(oPtr.TypeSpecificValue / 20);
                    oPtr.TypeSpecificValue /= 2;
                    saveGame.MsgPrint("You absorb energy from your light!");
                    if (saveGame.Player.TimedBlindness.TurnsRemaining != 0)
                    {
                        if (oPtr.TypeSpecificValue == 0)
                        {
                            oPtr.TypeSpecificValue++;
                        }
                    }
                    else if (oPtr.TypeSpecificValue == 0)
                    {
                        saveGame.Disturb(false);
                        saveGame.MsgPrint("Your light has gone out!");
                    }
                    else if (oPtr.TypeSpecificValue < 100 && oPtr.TypeSpecificValue % 10 == 0)
                    {
                        saveGame.MsgPrint("Your light is growing faint.");
                    }
                }
            }
            saveGame.UnlightArea(50, 10);
        }
    }
}