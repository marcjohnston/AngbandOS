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
    private EatLightRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You feel a strange kinship with Nyogtha.";
    public override string HaveMessage => "You sometimes feed off of the light around you.";
    public override string LoseMessage => "You feel the world's a brighter place.";

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(3000) != 1)
        {
            return;
        }
        Game.MsgPrint("A shadow passes over you.");
        Game.MsgPrint(string.Empty);
        if (Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue].SelfLit)
        {
            Game.RestoreHealth(10);
        }
        WieldSlot? inventorySlot = Game.SingletonRepository.ToWeightedRandom<WieldSlot>(_inventorySlot => _inventorySlot.ProvidesLight).ChooseOrDefault();
        if (inventorySlot == null)
        {
            return;
        }
        int index = inventorySlot.WeightedRandom.ChooseOrDefault();
        Item? oPtr = Game.GetInventoryItem(index);
        if (oPtr != null)
        {
            if (oPtr.EffectivePropertySet.BurnRate > 0 && oPtr.TurnsOfLightRemaining > 0)
            {
                Game.RestoreHealth(oPtr.TurnsOfLightRemaining / 20);
                oPtr.TurnsOfLightRemaining /= 2;
                Game.MsgPrint("You absorb energy from your light!");
                if (Game.BlindnessTimer.Value != 0)
                {
                    if (oPtr.TurnsOfLightRemaining == 0)
                    {
                        oPtr.TurnsOfLightRemaining++;
                    }
                }
                else if (oPtr.TurnsOfLightRemaining == 0)
                {
                    Game.Disturb(true);
                    Game.MsgPrint("Your light has gone out!");
                }
                else if (oPtr.TurnsOfLightRemaining < 100 && oPtr.TurnsOfLightRemaining % 10 == 0)
                {
                    Game.Disturb(true);
                    Game.MsgPrint("Your light is growing faint.");
                }
            }
        }
        Game.UnlightArea(50, 10);
    }
}