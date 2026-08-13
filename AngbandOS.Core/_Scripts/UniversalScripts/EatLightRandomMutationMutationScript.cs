namespace AngbandOS.Core.Scripts;
internal class EatLightRandomMutationMutationScript : UniversalScript, IGetKey
{
    private EatLightRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(3000) != 1)
        {
            return;
        }
        Game.MsgPrint("A shadow passes over you.");
        Game.MsgPrint(string.Empty);
        if (Game.Grid[Game.MapY.IntValue][Game.MapX.IntValue].SelfLit)
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
            if (oPtr.EffectiveAttributeSet.Get<SummationEffectiveAttributeValue>(nameof(BurnRateAttribute)).Get() > 0 && oPtr.TurnsOfLightRemaining > 0)
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