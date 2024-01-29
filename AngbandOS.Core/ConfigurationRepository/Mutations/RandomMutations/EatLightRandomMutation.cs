// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class EatLightRandomMutation : Mutation
{
    private EatLightRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You feel a strange kinship with Nyogtha.";
    public override string HaveMessage => "You sometimes feed off of the light around you.";
    public override string LoseMessage => "You feel the world's a brighter place.";

    public override void OnProcessWorld()
    {
        if (base.SaveGame.Rng.DieRoll(3000) != 1)
        {
            return;
        }
        SaveGame.MsgPrint("A shadow passes over you.");
        SaveGame.MsgPrint(null);
        if (SaveGame.Grid[SaveGame.MapY][SaveGame.MapX].TileFlags.IsSet(GridTile.SelfLit))
        {
            SaveGame.RestoreHealth(10);
        }
        BaseInventorySlot? inventorySlot = SaveGame.SingletonRepository.InventorySlots.ToWeightedRandom(_inventorySlot => _inventorySlot.ProvidesLight).Choose();
        if (inventorySlot == null)
        {
            return;
        }
        int index = inventorySlot.WeightedRandom.Choose();
        Item? oPtr = SaveGame.GetInventoryItem(index);
        if (oPtr != null)
        {
            LightSourceItemFactory? lightSourceItemFactory = oPtr.TryGetFactory<LightSourceItemFactory>();
            if (lightSourceItemFactory != null && lightSourceItemFactory.BurnRate > 0 && oPtr.TypeSpecificValue > 0)
            {
                SaveGame.RestoreHealth(oPtr.TypeSpecificValue / 20);
                oPtr.TypeSpecificValue /= 2;
                SaveGame.MsgPrint("You absorb energy from your light!");
                if (SaveGame.TimedBlindness.TurnsRemaining != 0)
                {
                    if (oPtr.TypeSpecificValue == 0)
                    {
                        oPtr.TypeSpecificValue++;
                    }
                }
                else if (oPtr.TypeSpecificValue == 0)
                {
                    SaveGame.Disturb(false);
                    SaveGame.MsgPrint("Your light has gone out!");
                }
                else if (oPtr.TypeSpecificValue < 100 && oPtr.TypeSpecificValue % 10 == 0)
                {
                    SaveGame.MsgPrint("Your light is growing faint.");
                }
            }
        }
        SaveGame.UnlightArea(50, 10);
    }
}