namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class LightningResistanceTimedAction : TimedAction
{
    public LightningResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You feel less resistant to electricity.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You feel resistant to electricity!");
    }
}
